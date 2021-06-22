using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// ImageWriteParam for BLP images. Adds functionality to customize encode
    /// behavior and encode quality.
    /// <p>
    /// A JPEG ImageWriterSpi can be specified to generate ImageWriters to encode
    /// JPEG content BLP files with. By default a generically obtained JPEG
    /// ImageWriterSpi will be used. Useful if multiple JPEG writers are installed
    /// and using a specific one is desired or necessary. The JPEG ImageWriter
    /// returned from the ImageWriterSpi must support writing Rasters.
    /// <p>
    /// Write operations can be specified to automatically generate mipmaps. When
    /// specified the given image will be used to automatically fill in all remaining
    /// mipmap levels. All required mipmaps, if any, will be automatically generated
    /// using an area averaging algorithm. Better mipmap results might be obtainable
    /// from other algorithms and explicitly specifying the mipmap images but this is
    /// subject to much scientific theory and debate. Automatic mipmap generation is
    /// specified on by default for ease of use.
    /// <p>
    /// Write operations can be specified to automatically optimize the full scale
    /// image dimensions to the maximum usable dimensions when no StreamMetadata is
    /// provided. Supported resizing modes include NONE, RATIO and CLAMP. NONE will
    /// use the image provided unmodified. RATIO will resize down an image to the
    /// maximum useful dimensions while keeping aspect ratio. CLAMP will resize down
    /// an image to the maximum useful dimensions, treating each dimension
    /// separately. All resizing is done using an area averaging algorithm. CLAMP is
    /// specified by default for ease of use and maximum quality as BLP file aspect
    /// ratio does not usually matter.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public class BLPWriteParam : ImageWriteParam
    {
        /// <summary>
        /// Default compression quality.
        /// <p>
        /// Suitable for general purpose use in Warcraft III.
        /// </summary>
        public static readonly float DEFAULT_QUALITY = 0.8F;
        // most Wc3 JPEG content BLP files are 80% quality
        /// <summary>
        /// The JPEG ImageWriterSpi to use to encode JPEG content.
        /// </summary>
        private ImageWriterSpi jpegSpi = null;
        /// <summary>
        /// The automatic scale optimization settings for image 0 if no
        /// StreamMetadata is specified.
        /// </summary>
        public enum ScaleOptimization
        {
            NONE,
            RATIO,
            CLAMP
        }

        /// <summary>
        /// The scale optimization setting to use on image 0 when no StreamMetadata
        /// is present.
        /// </summary>
        private ScaleOptimization scaleOpt = ScaleOptimization.CLAMP;
        /// <summary>
        /// The auto mipmap setting to use on image 0.
        /// </summary>
        private bool autoMipmap = true;
        public BLPWriteParam()
        {
            canWriteCompressed = true;
            SetCompressionMode(MODE_EXPLICIT);
            SetCompressionQuality(DEFAULT_QUALITY);
        }

        /// <summary>
        /// Get the ImageWriterSpi used to encode JPEG content BLPs.
        /// </summary>
        /// <returns>the JPEG ImageWriterSpi.</returns>
        public virtual ImageWriterSpi GetJPEGSpi()
        {
            return jpegSpi;
        }

        /// <summary>
        /// Set the ImageWriterSpi used to encode JPEG content. This can allow the
        /// ImageWriter used to encode JPEG content to be customized for reliability
        /// or performance reasons.
        /// <p>
        /// The ImageWriterSpi must be able to encode JPEG image files. Setting to
        /// null will cause a JPEG ImageWriter to be obtained automatically if
        /// installed.
        /// </summary>
        /// <param name="jpegSpi">
        ///            the ImageWriterSpi to use for JPEG content.</param>
        public virtual void SetJPEGSpi(ImageWriterSpi jpegSpi)
        {
            this.jpegSpi = jpegSpi;
        }

        /// <summary>
        /// Get the current scale optimization being used.
        /// </summary>
        /// <returns>scale optimization to be used.</returns>
        public virtual ScaleOptimization GetScaleOptimization()
        {
            return scaleOpt;
        }

        /// <summary>
        /// Set the scale optimization setting to use.
        /// <p>
        /// See ScaleOptimization enums for their mechanical details.
        /// </summary>
        /// <param name="scaleOpt">
        ///            the scale optimization setting to use.</param>
        public virtual void SetScaleOptimization(ScaleOptimization scaleOpt)
        {
            this.scaleOpt = scaleOpt;
        }

        /// <summary>
        /// Returns if auto mipmap generation is being used.
        /// </summary>
        /// <returns>true if mipmaps will be automatically generated as needed.</returns>
        public virtual bool IsAutoMipmap()
        {
            return autoMipmap;
        }

        /// <summary>
        /// Set if mipmaps should be automatically generated.
        /// <p>
        /// When true, all remaining mipmap levels will be automatically generate as
        /// from the provided image using an area averaging algorithm.
        /// </summary>
        /// <param name="autoMipmap">
        ///            the automatic mipmap generation setting to use.</param>
        public virtual void SetAutoMipmap(bool autoMipmap)
        {
            this.autoMipmap = autoMipmap;
        }
    }
}