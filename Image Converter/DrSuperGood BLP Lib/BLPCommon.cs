using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Class containing static constants and methods shared by various other classes
    /// of the BLP library.
    /// </summary>
    /// <remarks>@authorImperialGood</remarks>
    public abstract class BLPCommon
    {
        // indexed content
        /// <summary>
        /// The number of bits for selecting indexed color.
        /// </summary>
        static readonly int INDEXED_PALETTE_BITS = 8;
        /// <summary>
        /// The number of indexed colors for indexed content.
        /// </summary>
        public static readonly int INDEXED_PALETTE_SIZE = 1 << INDEXED_PALETTE_BITS;
        // mipmap constants
        /// <summary>
        /// Maximum number of mipmaps a BLP file can contain. Since version 1.
        /// </summary>
        public static readonly int MIPMAP_MAX = 16;
        /// <summary>
        /// Array containing all the BLP version magic numbers in chronological
        /// order.
        /// </summary>
        private static readonly MagicInt BLP_VERSION_MAGIC = new[] { new MagicInt("BLP0"), new MagicInt("BLP1"), new MagicInt("BLP2") };
        /// <summary>
        /// Converts a BLP magic number into a version number. If the magic number is
        /// not a known BLP magic number then an invalid version of -1 is returned.
        /// </summary>
        /// <param name="magicint">
        ///            file magic number.</param>
        /// <returns>the BLP version number or -1 if not known.</returns>
        public static int ResolveVersion(MagicInt magicint)
        {

            // simple linear search
            for (int i = 0; i < BLP_VERSION_MAGIC.length; i += 1)
            {
                if (magicint.Equals(BLP_VERSION_MAGIC[i]))
                    return i;
            }


            // failure
            return -1;
        }

        /// <summary>
        /// Converts a BLP version number into a magic number.
        /// </summary>
        /// <param name="ver">
        ///            the BLP version number.</param>
        /// <returns>the BLP file magic number in big-endian order.</returns>
        /// <exception cref="IndexOutOfBoundsException">
        ///             if ver is not a supported BLP version.</exception>
        public static MagicInt ResolveMagic(int ver)
        {
            return BLP_VERSION_MAGIC[ver];
        }
    }
}