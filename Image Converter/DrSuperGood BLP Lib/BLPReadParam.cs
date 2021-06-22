using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// ImageReadParam for BLP images. Adds functionality to customize decode
    /// behavior and to optimize throughput.
    /// <p>
    /// A JPEG ImageReaderSpi can be specified to generate ImageReaders to decode
    /// JPEG content BLP files with. By default a generically obtained JPEG
    /// ImageReaderSpi will be used. Useful if multiple JPEG readers are installed
    /// and using a specific one is desired or necessary. The JPEG ImageReader
    /// returned from the ImageReaderSpi must support the readRaster method.
    /// <p>
    /// Read operations can also be instructed to be direct read. In this mode all
    /// ImageReadParam behavior is ignored and the source BufferedImage is returned
    /// directly. When not in direct mode the source BufferedImage is processed using
    /// the ImageReadParam into a destination BufferedImage.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public class BLPReadParam : ImageReadParam
    {
        /// <summary>
        /// The JPEG ImageReaderSpi to use to decode JPEG content.
        /// </summary>
        protected ImageReaderSpi jpegSpi = null;
        /// <summary>
        /// Controls whether ImageReadParam mechanics can be ignored for improved
        /// performance.
        /// </summary>
        protected bool directRead = false;
        /// <summary>
        /// Get the ImageReaderSpi used to decode JPEG content BLPs.
        /// </summary>
        /// <returns>the JPEG ImageReaderSpi.</returns>
        public virtual ImageReaderSpi GetJPEGSpi()
        {
            return jpegSpi;
        }

        /// <summary>
        /// Set the ImageReaderSpi used to decode JPEG content. This can allow the
        /// ImageReader used to decode JPEG content to be customized for reliability
        /// or performance reasons.
        /// <p>
        /// The ImageReaderSpi must be able to decode JPEG image files. Setting to
        /// null will cause a JPEG ImageReader to be obtained automatically if
        /// installed.
        /// </summary>
        /// <param name="jpegSpi">
        ///            the ImageReaderSpi to use for JPEG content.</param>
        public virtual void SetJPEGSpi(ImageReaderSpi jpegSpi)
        {
            this.jpegSpi = jpegSpi;
        }

        /// <summary>
        /// Return if direct read mechanics apply. If true then all standard
        /// ImageReadParam mechanics are ignored.
        /// </summary>
        /// <returns>if direct read mode is active.</returns>
        public virtual bool IsDirectRead()
        {
            return directRead;
        }

        /// <summary>
        /// Allows the enabling of direct read mode.
        /// <p>
        /// When direct read mode is enabled, standard ImageReadParam mechanics are
        /// ignored. This allows ImageReader read operations to return a
        /// BufferedImage constructed as efficiently and simply as possible.
        /// <p>
        /// By default direct read is disabled. Using a ImageReadParam that is not of
        /// type BLPReadParam implies that direct read is disabled. If performance is
        /// required then direct read mode should be explicitly enabled using this
        /// method.
        /// </summary>
        /// <param name="directRead"></param>
        public virtual void SetDirectRead(bool directRead)
        {
            this.directRead = directRead;
        }

        /// <summary>
        /// Constructs a default BLPReadParam.
        /// <p>
        /// The ImageReadParam state is the same as its default constructor. No JPEG
        /// ImageReaderSpi overwrite is set. Direct read mode is disabled.
        /// </summary>
        public BLPReadParam()
        {
        }
    }
}