using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    public class BLPWriter : ImageWriter
    {
        /// <summary>
        /// The mipmap level for the next written image.
        /// </summary>
        private int imageIndex = 0;
        /// <summary>
        /// The stream metadata to write.
        /// </summary>
        private BLPStreamMetadata streamMetadata = null;
        /// <summary>
        /// Mipmap manager adapter class. Turns varying manager interfaces into a
        /// standard writer interface.
        /// </summary>
        private abstract class MipmapWriter
        {
            public virtual void WriteMipmapManager(ImageOutputStream ios)
            {
            }

            public virtual void StartMipmapSequence(ImageOutputStream ios)
            {
            }

            public abstract void SetMipmapDataChunk(int mipmap, byte mmData);
        }

        /// <summary>
        /// Mipmap to place mipmap data with.
        /// </summary>
        private MipmapWriter mipmapWriter = null;
        /// <summary>
        /// The mipmapProcessor being used.
        /// </summary>
        private MipmapProcessor mipmapProcessor = null;
        /// <summary>
        /// Image output stream to write to.
        /// </summary>
        private ImageOutputStream iosOutput = null;
        /// <summary>
        /// Image output stream is internally managed.
        /// </summary>
        private bool internalOutput = false;
        /// <summary>
        /// Output is unsuitable to write images.
        /// </summary>
        private bool badOutput = false;
        /// <summary>
        /// List to hold mipmap data that cannot immediately be written.
        /// </summary>
        private IList<byte> mmDataList = null;
        /// <summary>
        /// MipmapWriter is ready to write mipmap data.
        /// </summary>
        private bool canWriteMipmaps = false;
        public BLPWriter(ImageWriterSpi originatingProvider): base(originatingProvider)
        {
        }

        public override IIOMetadata GetDefaultStreamMetadata(ImageWriteParam param)
        {
            BLPStreamMetadata smd = new BLPStreamMetadata();
            if (param is BLPWriteParam)
            {
                BLPWriteParam blpParam = (BLPWriteParam)param;
                smd.SetMipmaps(blpParam.IsAutoMipmap());
                ImageTypeSpecifier its = blpParam.GetDestinationType();
                if (its != null)
                {
                    ColorModel cm = its.GetColorModel();
                    if (cm is BLPIndexColorModel)
                    {
                        smd.SetEncoding(BLPEncodingType.INDEXED, (byte)cm.GetComponentSize(cm.GetNumColorComponents()));
                    }
                    else if (cm is IndexColorModel)
                    {
                        smd.SetEncoding(BLPEncodingType.INDEXED, (byte)0);
                    }
                    else
                    {
                        smd.SetEncoding(BLPEncodingType.JPEG, (byte)(cm.HasAlpha() ? 8 : 0));
                    }
                }
            }

            return smd;
        }

        public override IIOMetadata GetDefaultImageMetadata(ImageTypeSpecifier imageType, ImageWriteParam param)
        {
            return null;
        }

        public override IIOMetadata ConvertStreamMetadata(IIOMetadata inData, ImageWriteParam param)
        {
            return GetDefaultStreamMetadata(param);
        }

        public override IIOMetadata ConvertImageMetadata(IIOMetadata inData, ImageTypeSpecifier imageType, ImageWriteParam param)
        {
            return null;
        }

        public override ImageWriteParam GetDefaultWriteParam()
        {
            return new BLPWriteParam();
        }

        /// <summary>
        /// Sends all attached warning listeners a warning message. The messages will
        /// be localized for each warning listener.
        /// </summary>
        /// <param name="msg">
        ///            the warning message to send to all warning listeners.</param>
        /// <param name="level">
        ///            the mipmap level the warning occured for.</param>
        protected virtual void ProcessWarningOccurred(LocalizedFormatedString msg, int level)
        {
            if (warningListeners == null)
                return;
            else if (msg == null)
                throw new ArgumentException("msg is null.");
            int numListeners = warningListeners.Count;
            for (int i = 0; i < numListeners; i++)
            {
                IIOWriteWarningListener listener = warningListeners[i];
                Locale locale = (Locale)warningLocales[i];
                if (locale == null)
                {
                    locale = Locale.GetDefault();
                }

                listener.WarningOccurred(this, level, msg.ToString(locale));
            }
        }

        public override void Write(IIOMetadata streamMetadata, IIOImage image, ImageWriteParam param)
        {

            // validate paramters
            if (image.HasRaster())
                throw new NotSupportedException("Cannot encode raster.");
            else if (output == null)
                throw new InvalidOperationException("No output.");
            else if (badOutput)
                throw new IIOException("Cannot write to stream.");

            // process output
            if (iosOutput == null)
            {

                // identify output type
                if (output is File)
                {
                    iosOutput = new FileImageOutputStream((File)output);
                    internalOutput = true;
                }
                else if (output is Path)
                {
                    iosOutput = new FileImageOutputStream(((Path)output).ToFile());
                    internalOutput = true;
                }
                else if (output is ImageOutputStream)
                {
                    iosOutput = (ImageOutputStream)output;
                }
                else
                {
                    throw new InvalidOperationException("Unsupported output.");
                }


                // check stream is empty
                if (iosOutput.Length() > 0)
                {
                    badOutput = true;
                    throw new IIOException("Stream not empty.");
                }
            }

            RenderedImage im = image.GetRenderedImage();

            // Prepare default param if required.
            if (param == null)
            {
                param = GetDefaultWriteParam();
                param.SetDestinationType(new ImageTypeSpecifier(im));
            }


            // get image processing values
            Rectangle sourceRegion = new Rectangle(0, 0, im.GetWidth(), im.GetHeight());
            int sourceXSubsampling = 1;
            int sourceYSubsampling = 1;
            int sourceBands = null;
            Point destOff = new Point();
            Rectangle sourceRegionParam = param.GetSourceRegion();
            if (sourceRegionParam != null)
                sourceRegion = sourceRegion.Intersection(param.GetSourceRegion());
            destOff = param.GetDestinationOffset();
            sourceXSubsampling = param.GetSourceXSubsampling();
            sourceYSubsampling = param.GetSourceYSubsampling();
            sourceBands = param.GetSourceBands();
            int subsampleXOffset = param.GetSubsamplingXOffset();
            int subsampleYOffset = param.GetSubsamplingYOffset();
            sourceRegion.x += subsampleXOffset;
            sourceRegion.y += subsampleYOffset;
            sourceRegion.width -= subsampleXOffset;
            sourceRegion.height -= subsampleYOffset;

            // create source Raster
            int width = sourceRegion.width;
            int height = sourceRegion.height;
            Raster imRas = im.GetData(sourceRegion);
            int numBands = imRas.GetNumBands();

            // validate source bands
            if (sourceBands != null)
            {
                for (int i = 0; i < sourceBands.length; i++)
                {
                    int bandOff = sourceBands[i];
                    if (bandOff < 0 || numBands <= bandOff)
                    {
                        throw new ArgumentException("Bad source bands.");
                    }
                }
            }


            // translate raster and apply bands
            imRas = imRas.CreateChild(sourceRegion.x, sourceRegion.y, width, height, 0, 0, sourceBands);

            // apply subsampling to width and height
            width = (width + sourceXSubsampling - 1) / sourceXSubsampling;
            height = (height + sourceYSubsampling - 1) / sourceYSubsampling;

            // create and fill destination WritableRaster
            WritableRaster destWR = imRas.CreateCompatibleWritableRaster(destOff.x, destOff.y, width + destOff.x, height + destOff.y);
            Object transferCache = null;
            for (int y = 0; y < height; y += 1)
            {
                for (int x = 0; x < width; x += 1)
                {
                    transferCache = imRas.GetDataElements(x * sourceXSubsampling, y * sourceYSubsampling, transferCache);
                    destWR.SetDataElements(x, y, transferCache);
                }
            }


            // create destination BufferedImage
            ColorModel srcCM = im.GetColorModel();
            BufferedImage destImg = new BufferedImage(srcCM, destWR, srcCM.IsAlphaPremultiplied(), null);
            int destW = destImg.GetWidth();
            int destH = destImg.GetHeight();

            // stream setup
            if (imageIndex == 0)
            {

                // process stream metadata
                if (!(streamMetadata is BLPStreamMetadata))
                {
                    streamMetadata = ConvertStreamMetadata(streamMetadata, param);
                }

                this.streamMetadata = (BLPStreamMetadata)streamMetadata;

                // resolve output image dimensions
                bool rescaleDest = false;
                ScaleOptimization autoScale = ScaleOptimization.CLAMP;
                if (param is BLPWriteParam)
                    autoScale = ((BLPWriteParam)param).GetScaleOptimization();
                int worst = Math.Max(destW, destH);
                int max_dimension = this.streamMetadata.GetVersion() < 2 ? LEGACY_MAX_DIMENSION : this.streamMetadata.GetDimensionMaximum();
                if (worst > max_dimension)
                {
                    switch autoScale
                    {
                        case RATIO:
                            destW = (int)(((long)destW * max_dimension + worst / 2) / worst);
                            destH = (int)(((long)destH * max_dimension + worst / 2) / worst);
                            rescaleDest = true;
                            break;
                        case CLAMP:
                            destW = Math.Min(destW, max_dimension);
                            destH = Math.Min(destH, max_dimension);
                            rescaleDest = true;
                            break;
                        default:
                            break;
                    }
                }

                this.streamMetadata.SetHeight(destH);
                this.streamMetadata.SetWidth(destW);
                if (!(param is BLPWriteParam))
                {
                    this.streamMetadata.SetEncoding(BLPEncodingType.JPEG, srcCM.HasAlpha() ? (byte)8 : (byte)0);
                }


                // rescale output image if required
                if (rescaleDest)
                {
                    ProcessWarningOccurred(new LocalizedFormatedString("com.hiveworkshop.text.blp", "WriteResize", destImg.GetWidth(), destImg.GetHeight(), destW, destH), imageIndex);
                    BufferedImage destImgNew = new BufferedImage(srcCM, destImg.GetRaster().CreateCompatibleWritableRaster(destW, destH), srcCM.IsAlphaPremultiplied(), null);
                    Graphics2D graphics = destImgNew.CreateGraphics();
                    RenderingHints rh = new RenderingHints(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_NEAREST_NEIGHBOR);
                    graphics.SetRenderingHints(rh);
                    graphics.DrawImage(destImg.GetScaledInstance(destW, destH, Image.SCALE_AREA_AVERAGING), 0, 0, destW, destH, null);
                    graphics.Dispose();
                    destImg = destImgNew;
                }


                // construct mipmap manager
                if (this.streamMetadata.GetVersion() < 1)
                {

                    // external mipmaps
                    Path path;
                    if (output is File)
                        path = ((File)output).ToPath();
                    else if (output is Path)
                        path = (Path)output;
                    else
                        throw new InvalidOperationException("Version 0 can only be written to Path of File.");
                    ExternalMipmapManager emm = new ExternalMipmapManager(path);
                    mipmapWriter = new AnonymousMipmapWriter(this);
                }
                else
                {

                    // internal mipmaps
                    InternalMipmapManager imm = new InternalMipmapManager();
                    mipmapWriter = new AnonymousMipmapWriter1(this);
                }


                // construct mipmap processor
                BLPEncodingType encodingType = this.streamMetadata.GetEncodingType();
                switch encodingType
                {
                    case INDEXED:
                        mipmapProcessor = new IndexedMipmapProcessor(this.streamMetadata.GetAlphaBits());
                        break;
                    case JPEG:
                        mipmapProcessor = new JPEGMipmapProcessor(this.streamMetadata.GetAlphaBits());
                        break;
                    case UNKNOWN:
                    default:
                        throw new IIOException("Unsupported encoding type.");
                }


                // write out header
                iosOutput.Seek(0);
                this.streamMetadata.WriteObject(iosOutput);
                mipmapWriter.WriteMipmapManager(iosOutput);
                mmDataList = new List<byte>(this.streamMetadata.GetMipmapCount());
            }


            // mipmap count test
            int mmCount = this.streamMetadata.GetMipmapCount();
            if (imageIndex >= mmCount)
                throw new IIOException("Image limit reached.");

            // image scale test
            int mmH = this.streamMetadata.GetHeight(imageIndex);
            int mmW = this.streamMetadata.GetWidth(imageIndex);
            if (destW != mmW || destH != mmH)
                throw new IIOException(String.Format("Invalid image dimensions: Got %d*%d pixels requires %d*%d pixels.", destW, destH, mmW, mmH));

            // encode image
            ProcessImageStarted(imageIndex);
            byte mmData = mipmapProcessor.EncodeMipmap(destImg, param, (warn) => this.ProcessWarningOccurred(warn, imageIndex);
            );

            // write out mipmap data
            if (mipmapProcessor.MustPostProcess())
            {
                mmDataList.Add(mmData);
            }
            else
            {
                if (!canWriteMipmaps && mipmapProcessor.CanDecode())
                {
                    mipmapProcessor.WriteObject(iosOutput);
                    mipmapWriter.StartMipmapSequence(iosOutput);
                    canWriteMipmaps = true;
                }

                mipmapWriter.SetMipmapDataChunk(imageIndex, mmData);
                mipmapWriter.WriteMipmapManager(iosOutput);
            }

            imageIndex += 1;
            ProcessImageComplete();

            // resolve auto mipmap
            bool autoMipmap = true;
            if (param is BLPWriteParam)
            {
                autoMipmap = ((BLPWriteParam)param).IsAutoMipmap();
            }


            // apply auto mipmaps
            if (autoMipmap)
            {
                RenderingHints rh = new RenderingHints(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_NEAREST_NEIGHBOR);
                while (imageIndex < mmCount)
                {

                    // create scaled image
                    ProcessImageStarted(imageIndex);
                    mmH = this.streamMetadata.GetHeight(imageIndex);
                    mmW = this.streamMetadata.GetWidth(imageIndex);
                    BufferedImage mmImg = new BufferedImage(srcCM, destImg.GetRaster().CreateCompatibleWritableRaster(mmW, mmH), srcCM.IsAlphaPremultiplied(), null);
                    Graphics2D graphics = mmImg.CreateGraphics();
                    graphics.SetRenderingHints(rh);
                    graphics.DrawImage(destImg.GetScaledInstance(mmW, mmH, Image.SCALE_AREA_AVERAGING), 0, 0, mmW, mmH, null);
                    graphics.Dispose();

                    // encode image
                    mmData = mipmapProcessor.EncodeMipmap(mmImg, param, (warn) => this.ProcessWarningOccurred(warn, imageIndex);
                    );

                    // write out mipmap data
                    if (mipmapProcessor.MustPostProcess())
                    {
                        mmDataList.Add(mmData);
                    }
                    else
                    {
                        mipmapWriter.SetMipmapDataChunk(imageIndex, mmData);
                        mipmapWriter.WriteMipmapManager(iosOutput);
                    }

                    imageIndex += 1;
                    ProcessImageComplete();
                }
            }

            if (imageIndex == mmCount)
            {

                // post process mipmaps
                if (mipmapProcessor.MustPostProcess())
                {
                    mmDataList = mipmapProcessor.PostProcessMipmapData(mmDataList, (warn) => this.ProcessWarningOccurred(warn, -1);
                    );
                    mipmapProcessor.WriteObject(iosOutput);
                    mipmapWriter.StartMipmapSequence(iosOutput);
                    canWriteMipmaps = true;
                    for (int i = 0; i < mmCount; i += 1)
                    {
                        mipmapWriter.SetMipmapDataChunk(i, mmDataList[i]);
                    }

                    mipmapWriter.WriteMipmapManager(iosOutput);
                    mmDataList.Clear();
                }


                // close internal image output stream
                if (internalOutput)
                {
                    iosOutput.Close();
                    internalOutput = false;
                }
            }
        }

        private sealed class AnonymousMipmapWriter : MipmapWriter
        {
            public AnonymousMipmapWriter(MipmapWriter parent)
            {
                this.parent = parent;
            }

            private readonly MipmapWriter parent;
            public override void SetMipmapDataChunk(int mipmap, byte mmData)
            {
                emm.SetMipmapDataChunk(mipmap, mmData);
            }
        }

        private sealed class AnonymousMipmapWriter1 : MipmapWriter
        {
            public AnonymousMipmapWriter1(MipmapWriter parent)
            {
                this.parent = parent;
            }

            private readonly MipmapWriter parent;
            private long objectPos = -1L;
            public override void WriteMipmapManager(ImageOutputStream ios)
            {
                if (objectPos == -1L)
                {
                    objectPos = ios.GetStreamPosition();
                }
                else
                {
                    ios.Seek(objectPos);
                }

                imm.WriteObject(ios);
            }

            public override void StartMipmapSequence(ImageOutputStream ios)
            {
                imm.SetMipmapDataChunkBlockOffset(ios);
            }

            public override void SetMipmapDataChunk(int mipmap, byte mmData)
            {
                imm.SetMipmapDataChunk(iosOutput, mipmap, mmData);
            }
        }

        public override void SetOutput(Object output)
        {
            base.SetOutput(output);

            // close internal image output stream
            if (internalOutput)
            {
                try
                {
                    iosOutput.Close();
                }
                catch (IOException e)
                {
                    ProcessWarningOccurred(new LocalizedFormatedString("com.hiveworkshop.text.blp", "ISCloseFail", e.GetMessage()), -1);
                }
            }


            // warn if incomple file was written
            if (!badOutput && streamMetadata != null && imageIndex != streamMetadata.GetMipmapCount())
            {
                ProcessWarningOccurred(new LocalizedFormatedString("com.hiveworkshop.text.blp", "IncompleteFile"), -1);
            }


            // reset state
            imageIndex = 0;
            streamMetadata = null;
            mipmapWriter = null;
            mipmapProcessor = null;
            iosOutput = null;
            internalOutput = false;
            badOutput = false;
            mmDataList = null;
            canWriteMipmaps = false;
        }

        public override void Dispose()
        {
            SetOutput(null);
        }
    }
}