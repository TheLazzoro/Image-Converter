using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Object for managing externally stored BLP mipmap data chunks. This is used by
    /// BLP0.
    /// <p>
    /// The retrieval and extraction of mipmap data chunks from accompanying files
    /// are managed. Methods are provided to read or write mipmap data chunks.
    /// </summary>
    /// <remarks>@authorImperialGood</remarks>
    class ExternalMipmapManager
    {
        /// <summary>
        /// Parent folder of the BLP0 file. Where the mipmaps files get saved.
        /// </summary>
        private readonly Path root;
        /// <summary>
        /// The base file name of the BLP0 file. All files for the same BLP0 file
        /// share this name.
        /// </summary>
        private readonly string name;
        /// <summary>
        /// Get the file for the specified mipmap level.
        /// </summary>
        /// <param name="mipmap">
        ///            the mipmap level.</param>
        /// <returns>the file.</returns>
        private Path GetMipmapFilePath(int mipmap)
        {
            return root.Resolve(name + String.Format(".b%02d", mipmap));
        }

        /// <summary>
        /// Constructs from a BLP0 file.
        /// <p>
        /// The Path must represent a file with the '.blp' suffix. The file itself is
        /// not manipulated and is assumed to exist.
        /// </summary>
        /// <param name="file">
        ///            a blp file.</param>
        /// <exception cref="IOException">
        ///             if the file is not acceptable.</exception>
        public ExternalMipmapManager(Path file)
        {
            string fileName = file.GetFileName().ToString();
            if (!fileName.EndsWith(".blp"))
                throw new IIOException(String.Format("Malformed file path: Got '%s' expected '*.blp'.", file.ToString()));
            root = file.GetParent();
            name = fileName.Substring(0, fileName.Length() - ".blp".Length());
        }

        /// <summary>
        /// Extracts a mipmap data chunk for the requested mipmap level and returns
        /// it as unprocessed data.
        /// </summary>
        /// <param name="mipmap">
        ///            the mipmap level.</param>
        /// <returns>a byte array containing the mipmap data chunk.</returns>
        /// <exception cref="IOException">
        ///             if an IOException occurs.</exception>
        public virtual byte GetMipmapDataChunk(int mipmap)
        {
            return Files.ReadAllBytes(GetMipmapFilePath(mipmap));
        }

        /// <summary>
        /// Writes a mipmap data chunk for the requested mipmap level. A null chunk
        /// can be used to completely remove saved chunks.
        /// </summary>
        /// <param name="mipmap">
        ///            the mipmap level.</param>
        /// <param name="chunk">
        ///            a byte array containing the mipmap data chunk.</param>
        /// <exception cref="IOException">
        ///             if an IOException occurs.</exception>
        public virtual void SetMipmapDataChunk(int mipmap, byte chunk)
        {
            Path filePath = GetMipmapFilePath(mipmap);
            if (chunk == null)
            {
                Files.DeleteIfExists(filePath);
                return;
            }

            Files.Write(filePath, chunk);
        }
    }
}