using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Implementation class for the BLP image reader.
    /// <p>
    /// Supports opening of BLP versions 0 and 1. Mipmap levels translate into image
    /// number.
    /// <p>
    /// Default resulting BufferedImage objects may come in a variety of image types
    /// based on the content of the blp file. The image type chosen aims to preserve
    /// the underlying data structure.
    /// <p>
    /// No image metadata can be extracted to preserve JPEG content image quality.
    /// <p>
    /// Raster is not supported. Read progress updates are not supported, but all
    /// other listeners work.
    /// </summary>
    /// <remarks>@authorImperialGood</remarks>
    public class BLPReader : ImageReader
    {
        /// <summary>
        /// BLP stream metadata object. Represents the contents of the BLP file
        /// header and is used to decode all mipmap levels.
        /// </summary>
        private BLPStreamMetadata streamMeta = null;
        /// <summary>
        /// Internally managed ImageInputStream.
        /// </summary>
        private ImageInputStream intSrc = null;
        /// <summary>
        /// Mipmap manager adapter class. Turns varying manager interfaces into a
        /// standard reader interface.
        /// </summary>
        private abstract class MipmapReader
        {
            public abstract byte GetMipmapDataChunk(int mipmap);
            public virtual void FlushTo(int mipmap)
            {
            }
        }

        /// <summary>
        /// Mipmap reader to get mipmap data chunks from.
        /// </summary>
        private MipmapReader mipmapReader;
        /// <summary>
        /// Mipmap processor for content.
        /// </summary>
        private MipmapProcessor mipmapProcessor = null;
        public virtual string TempGetInfo()
        {
            LoadHeader();
            return streamMeta.ToString();
        }

        public BLPReader(ImageReaderSpi originatingProvider): base(originatingProvider)
        {
        }

        /// <summary>
        /// Loads the BLP header from an input source. The header is only loaded once
        /// with the results cached for performance.
        /// </summary>
        /// <exception cref="IOException">
        ///             - is header cannot be loaded</exception>
        private void LoadHeader()
        {

            // only do something if header has not already been loaded
            if (streamMeta != null)
                return;

            // check if a source has been set
            if (input == null)
                throw new InvalidOperationException("no input source has been set");

            // check if input is a file system path
            Path path = null;
            if (input is Path)
            {

                // directly use path
                path = (Path)input;
            }
            else if (input is File)
            {

                // use path of file
                path = ((File)input).ToPath();
            }


            // resolve input stream
            ImageInputStream src;
            if (input is ImageInputStream)
            {

                // ImageInputStream provided
                src = (ImageInputStream)input;
            }
            else if (path != null)
            {

                // create internally managed ImageInputStream
                intSrc = new FileImageInputStream(path.ToFile());

                // validate Path
                if (intSrc == null)
                    throw new InvalidOperationException("Cannot create ImageInputStream from path.");
                src = intSrc;
            }
            else

                // invalid input has been assigned
                throw new InvalidOperationException("bad input state");

            // start from beginning of stream
            src.Seek(0);
            BLPStreamMetadata streamMeta = new BLPStreamMetadata();
            streamMeta.SetWarningHandler(this.ProcessWarningOccurred());
            streamMeta.ReadObject(src);

            // read mipmap location data
            MipmapReader mipmapReader;
            if (streamMeta.GetVersion() > 0)
            {

                // mipmap chunks within same file
                InternalMipmapManager imm = new InternalMipmapManager();
                imm.ReadObject(src);
                BLPReader thisref = this;
                mipmapReader = new AnonymousMipmapReader(this);
            }
            else if (path != null)
            {

                // file must have ".blp" extension
                ExternalMipmapManager emm = new ExternalMipmapManager(path);
                mipmapReader = new AnonymousMipmapReader1(this);
            }
            else
            {

                // no path to locate mipmap chunk files
                throw new IIOException("BLP0 image can only be loaded from Path or File input.");
            }


            // read content header
            if (streamMeta.GetEncodingType() == BLPEncodingType.JPEG)
            {
                mipmapProcessor = new JPEGMipmapProcessor(streamMeta.GetAlphaBits());
            }
            else if (streamMeta.GetEncodingType() == BLPEncodingType.INDEXED)
            {
                mipmapProcessor = new IndexedMipmapProcessor(streamMeta.GetAlphaBits());
            }
            else
            {
                throw new IIOException("Unsupported content type.");
            }

            mipmapProcessor.ReadObject(src, this.ProcessWarningOccurred());

            // if seeking forward only then header data can now be discarded
            if (seekForwardOnly)
                mipmapReader.FlushTo(0);
            this.streamMeta = streamMeta;
            this.mipmapReader = mipmapReader;
        }

        private sealed class AnonymousMipmapReader : MipmapReader
        {
            public AnonymousMipmapReader(MipmapReader parent)
            {
                this.parent = parent;
            }

            private readonly MipmapReader parent;
            public override byte GetMipmapDataChunk(int mipmap)
            {
                return imm.GetMipmapDataChunk(src, mipmap, thisref.ProcessWarningOccurred());
            }

            public override void FlushTo(int mipmap)
            {
                imm.FlushToMipmap(src, mipmap);
            }
        }

        private sealed class AnonymousMipmapReader1 : MipmapReader
        {
            public AnonymousMipmapReader1(MipmapReader parent)
            {
                this.parent = parent;
            }

            private readonly MipmapReader parent;
            public override byte GetMipmapDataChunk(int mipmap)
            {
                return emm.GetMipmapDataChunk(mipmap);
            }
        }

        /// <summary>
        /// Checks if the given image index is valid.
        /// </summary>
        /// <param name="imageIndex">
        ///            the image index to check.</param>
        /// <exception cref="IndexOutOfBoundsException">
        ///             if the image does not exist.</exception>
        private void CheckImageIndex(int imageIndex)
        {

            // test if image mipmap level exists
            if (streamMeta.GetMipmapCount() <= imageIndex)
                throw new IndexOutOfBoundsException(String.Format("Mipmap level does not exist: %d.", imageIndex));

            // test for seekForwardOnly functionality
            if (imageIndex < minIndex)
                throw new IndexOutOfBoundsException(String.Format("Violation of seekForwardOnly: at %d wanting %d.", minIndex, imageIndex));
        }

        public override void SetInput(Object input, bool seekForwardOnly, bool ignoreMetadata)
        {

            // parent performs type checks and generates exceptions
            base.SetInput(input, seekForwardOnly, ignoreMetadata);

            // close internal ImageInputStream
            if (intSrc != null)
            {
                try
                {
                    intSrc.Close();
                }
                catch (IOException e)
                {
                    ProcessWarningOccurred(new LocalizedFormatedString("com.hiveworkshop.text.blp", "ISCloseFail", e.GetMessage()));
                }

                intSrc = null;
            }

            streamMeta = null;
            mipmapReader = null;
        }

        /// <summary>
        /// Sends all attached warning listeners a warning message. The messages will
        /// be localized for each warning listener.
        /// </summary>
        /// <param name="msg">
        ///            the warning message to send to all warning listeners.</param>
        protected virtual void ProcessWarningOccurred(LocalizedFormatedString msg)
        {
            if (warningListeners == null)
                return;
            else if (msg == null)
                throw new ArgumentException("msg is null.");
            int numListeners = warningListeners.Count;
            for (int i = 0; i < numListeners; i++)
            {
                IIOReadWarningListener listener = warningListeners[i];
                Locale locale = (Locale)warningLocales[i];
                if (locale == null)
                {
                    locale = Locale.GetDefault();
                }

                listener.WarningOccurred(this, msg.ToString(locale));
            }
        }

        public override int GetHeight(int imageIndex)
        {
            LoadHeader();
            CheckImageIndex(imageIndex);
            return streamMeta.GetHeight(imageIndex);
        }

        public override IIOMetadata GetImageMetadata(int imageIndex)
        {
            CheckImageIndex(imageIndex);
            return null;
        }

        public override Iterator<ImageTypeSpecifier> GetImageTypes(int imageIndex)
        {
            LoadHeader();
            CheckImageIndex(imageIndex);
            return mipmapProcessor.GetSupportedImageTypes(streamMeta.GetWidth(imageIndex), streamMeta.GetHeight(imageIndex));
        }

        public override int GetNumImages(bool allowSearch)
        {
            LoadHeader();
            return streamMeta.GetMipmapCount();
        }

        public override IIOMetadata GetStreamMetadata()
        {
            LoadHeader();
            return streamMeta;
        }

        public override int GetWidth(int imageIndex)
        {
            LoadHeader();
            CheckImageIndex(imageIndex);
            return streamMeta.GetWidth(imageIndex);
        }

        public override BufferedImage Read(int imageIndex, ImageReadParam param)
        {
            LoadHeader();
            CheckImageIndex(imageIndex);

            // seek forward functionality
            if (seekForwardOnly && minIndex < imageIndex)
            {
                minIndex = imageIndex;
                mipmapReader.FlushTo(minIndex);
            }

            if (!mipmapProcessor.CanDecode())
                throw new IIOException("Mipmap processor cannot decode.");
            ProcessImageStarted(imageIndex);

            // get mipmap image data
            byte mmData = mipmapReader.GetMipmapDataChunk(imageIndex);

            // unpack mipmap image data into a mipmap image
            int width = streamMeta.GetWidth(imageIndex);
            int height = streamMeta.GetHeight(imageIndex);
            BufferedImage srcImg = mipmapProcessor.DecodeMipmap(mmData, param, width, height, this.ProcessWarningOccurred());

            // imageIndex);
            BufferedImage destImg;

            // return src image if direct read mode is specified or no
            // ImageReadParam is present
            if (param == null || (param is BLPReadParam && ((BLPReadParam)param).IsDirectRead()))
                destImg = srcImg;
            else
            {
                destImg = GetDestination(param, GetImageTypes(imageIndex), width, height);
                CheckReadParamBandSettings(param, srcImg.GetSampleModel().GetNumBands(), destImg.GetSampleModel().GetNumBands());
                Rectangle srcRegion = new Rectangle();
                Rectangle destRegion = new Rectangle();
                ComputeRegions(param, width, height, destImg, srcRegion, destRegion);

                // extract param settings
                int srcBands = param.GetSourceBands();
                int destBands = param.GetDestinationBands();
                int ssX = param.GetSourceXSubsampling();
                int ssY = param.GetSourceYSubsampling();
                WritableRaster srcRaster = srcImg.GetRaster().CreateWritableChild(srcRegion.x, srcRegion.y, srcRegion.width, srcRegion.height, 0, 0, srcBands);
                WritableRaster destRaster = destImg.GetRaster().CreateWritableChild(destRegion.x, destRegion.y, destRegion.width, destRegion.height, 0, 0, destBands);

                // copy pixels
                Object dataElements = null;
                for (int y = 0; y < destRegion.height; y += 1)
                {
                    for (int x = 0; x < destRegion.width; x += 1)
                    {
                        int srcXOff = ssX * x;
                        int srcYOff = ssY * y;
                        dataElements = srcRaster.GetDataElements(srcXOff, srcYOff, null);
                        destRaster.SetDataElements(x, y, dataElements);
                    }
                }
            }

            ProcessImageComplete();
            return destImg;
        }

        public override void Dispose()
        {

            // force cleanup of existing state
            SetInput(null);
        }

        public override ImageReadParam GetDefaultReadParam()
        {
            return new BLPReadParam();
        }
    }
}