using System;
using System.Collections.Generic;

namespace RPlySharp
{
    
    /// <summary>
    /// Ply file handle.
    /// </summary>
    internal class PlyFile : IPly
    {
        public const int WordSize = 256;
        public const int LineSize = 1024;
        public const int BufferSize = 8 * 1024;

        /// <summary>read or write</summary>
        public IoMode IoMode { get; set; }
        /// <summary>mode of file associated with handle</summary>
        public StorageMode StorageMode { get; set; }
        /// <summary>elements description for this file</summary>
        public PlyElement[] Elements { get; set; }
        /// <summary>comments for this file</summary>
        public string[] Comments { get; set; }
        /// <summary>obj_info items for this file</summary>
        public byte[][] ObjInfo { get; set; }
        /// <summary> file pointer associated with ply file</summary>
        public System.IO.FileStream File { get; set; }
        /// <summary>last character read from ply file</summary>
        public int C { get; private set; }
        /// <summary>last word/chunk of data read from ply file</summary>
        public byte[] Buffer { get; private set; }
        /// <summary>interval of untouched good data in buffer</summary>
        public int BufferFirst { get; private set; }
        /// <summary>start of parsed token (line or word) in buffer</summary>
        public int BufferToken { get; private set; }
        /// <summary>interval of untouched good data in buffer</summary>
        public int BufferLast { get; private set; }
        /// <summary>input driver used to get property fields from file </summary>
        public InputDriver InputDriver { get; set; }
        /// <summary>output driver used to insert property fields into file </summary>
        public OutputDriver OutputDriver { get; set; }
        /// <summary>storage space for callback arguments</summary>
        public PlyArgument Argument { get; set; }
        /// <summary>element type being written</summary>
        public PlyType WriteElementType { get; set; }
        /// <summary>property type being written</summary>
        public PlyType WritePropertyType { get; set; }
        /// <summary>index of instance of current element being written</summary>
        public int WriteInstanceIndex { get; set; }
        /// <summary>index of list property value being written</summary>
        public int WriteValueIndex { get; set; }
        /// <summary>number of values in list property being written</summary>
        public int WriteLength { get; set; }
        /// <summary>callback for error messages</summary>
        public ErrorCallback ErrorCallback { get; set; }

        internal static PlyFile Alloc()
        {
            throw new NotImplementedException();
        }
    }
}