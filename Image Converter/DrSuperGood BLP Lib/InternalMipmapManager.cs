using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Object for managing internally stored BLP mipmap data chunks. This is used by
    /// BLP version 1 and later.
    /// <p>
    /// The location and size of mipmap data chunks within a stream are managed.
    /// Methods are provided to read or write mipmap data chunks in a stream. Methods
    /// are provided to configure mipmap chunk management.
    /// </summary>
    /// <remarks>@authorImperialGood</remarks>
    class InternalMipmapManager
    {
        private readonly int chunkOffsets = new int[MIPMAP_MAX];
        private readonly int chunkSizes = new int[MIPMAP_MAX];
        private long chunkStreamPos = 0L;
        public InternalMipmapManager()
        {
        }

        /// <summary>
        /// Extracts a mipmap data chunk for the requested mipmap level from the
        /// given stream and returns it as unprocessed data. A warning handler must
        /// be provided to process any warnings that occur during extraction.
        /// <p>
        /// If the chunk size is too big to process a warning will be emitted and as
        /// much data as allowed will be returned. If the chunk extends beyond the
        /// EOF a warning will be emitted and as much data as available be be
        /// returned.
        /// <p>
        /// Chunks with 0 size generate no I/O.
        /// </summary>
        /// <param name="src">
        ///            stream to source mipmap data chunks from.</param>
        /// <param name="mipmap">
        ///            the mipmap level.</param>
        /// <param name="warning">
        ///            warning handler function.</param>
        /// <returns>a byte array containing the mipmap data chunk.</returns>
        /// <exception cref="IOException">
        ///             if an IOException occurs.</exception>
        public virtual byte GetMipmapDataChunk(ImageInputStream src, int mipmap, Consumer<LocalizedFormatedString> warning)
        {
            long offset = chunkOffsets[mipmap] & 4294967295L;
            long sizeLong = chunkSizes[mipmap] & 4294967295L;

            // process chunk size
            int size;
            int sizeMax = Integer.MAX_VALUE;
            if (sizeLong > sizeMax)
            {
                warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadChunkSize", sizeLong, sizeMax));
                size = sizeMax;
            }
            else
            {
                size = (int)sizeLong;
            }


            // allocate buffer
            byte buff = new byte[size];

            // set stream to correct position
            if (size > 0)
                src.Seek(offset);

            // read data
            int len = size;
            int off = 0;
            while (len > 0)
            {
                int read = src.Read(buff, off, len);

                // end of file before full read
                if (read == -1)
                {
                    warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadChunkPos", size, off));
                    buff = Arrays.CopyOf(buff, off);
                    break;
                }

                len -= read;
                off += read;
            }

            return buff;
        }

        /// <summary>
        /// Inserts a mipmap data chunk for the requested mipmap level to the given
        /// stream. An empty array can be used to remove chunks.
        /// <p>
        /// The mipmap data chunk block offset must be set before calling this.
        /// Failure to do so may cause file corruption.
        /// <p>
        /// For best results the mipmaps should be set only once in rising numeric
        /// order.
        /// </summary>
        /// <param name="dst">
        ///            stream to place mipmap data chunks to.</param>
        /// <param name="mipmap">
        ///            the mipmap level.</param>
        /// <param name="chunk">
        ///            a byte array containing the mipmap data chunk.</param>
        /// <exception cref="IOException">
        ///             if an IOException occurs.</exception>
        public virtual void SetMipmapDataChunk(ImageOutputStream dst, int mipmap, byte chunk)
        {
            int len = chunk.length;

            // TODO compact/defragment stream
            // chunk logical position
            chunkSizes[mipmap] = len;
            long offset = len > 0 ? chunkStreamPos : 0;
            if (offset > 4294967295L)
                throw new IOException("Stream offset too big.");
            chunkOffsets[mipmap] = (int)offset;

            // write chunk
            if (len > 0)
            {
                dst.Seek(chunkStreamPos);
                dst.Write(chunk);
            }

            chunkStreamPos += len;
        }

        /// <summary>
        /// Set the offset of the mipmap data chunk block to the current stream
        /// position.
        /// <p>
        /// This method is intended to be called before any mipmap data chunks are
        /// set. Calling it while any mipmap data chunks are set will result in
        /// undefined behavior.
        /// </summary>
        /// <param name="src">
        ///            stream to place mipmap data chunks to.</param>
        /// <exception cref="IOException">
        ///             if an IOException occurs.</exception>
        public virtual void SetMipmapDataChunkBlockOffset(ImageInputStream src)
        {
            long offset = src.GetStreamPosition();
            if (offset > 4294967295L)
                throw new IOException("Stream offset too big.");
            chunkStreamPos = offset;
        }

        /// <summary>
        /// Flushes the stream to the minimum position needed to read the requested
        /// mipmap or higher.
        /// </summary>
        /// <param name="src">
        ///            stream to flush.</param>
        /// <param name="mipmap">
        ///            the mipmap level.</param>
        /// <exception cref="IOException">
        ///             if an IOException occurs.</exception>
        public virtual void FlushToMipmap(ImageInputStream src, int mipmap)
        {

            // find lowest offset to allow the mipmaps to be read
            long pos = Long.MAX_VALUE;
            for (int i = mipmap + 1; i < MIPMAP_MAX; i += 1)
            {
                long newpos = chunkOffsets[i] & 4294967295L;
                if (newpos < pos)
                    pos = newpos;
            }

            src.FlushBefore(pos);
        }

        public virtual void ReadObject(ImageInputStream @in)
        {
            @in.SetByteOrder(ByteOrder.LITTLE_ENDIAN);

            // read mipmap chunk descriptions
            @in.ReadFully(chunkOffsets, 0, chunkOffsets.length);
            @in.ReadFully(chunkSizes, 0, chunkSizes.length);

            // find end of mipmap block
            long pos = 0;
            for (int i = 0; i < MIPMAP_MAX; i += 1)
            {
                long newpos = chunkOffsets[i] & 4294967295L;
                if (chunkSizes[i] != 0 && newpos > pos)
                    pos = newpos;
            }

            chunkStreamPos = pos;
        }

        public virtual void WriteObject(ImageOutputStream @out)
        {
            @out.SetByteOrder(ByteOrder.LITTLE_ENDIAN);

            // write mipmap chunk descriptions
            @out.WriteInts(chunkOffsets, 0, chunkOffsets.length);
            @out.WriteInts(chunkSizes, 0, chunkSizes.length);
        }
    }
}