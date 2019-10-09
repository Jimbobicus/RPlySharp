using System;
using System.IO;
using System.Text;

namespace RPlySharp
{
    using Implementation;

    
    /// <summary>
    /// Property reading callback prototype
    /// </summary>
    /// <param name="message">error message</param>
    public delegate void ErrorCallback(string message);

    /// <summary>
    /// Property reading callback prototype
    /// </summary>
    /// <param name="argument">parameters for property being processed when callback is called</param>
    /// <returns>true if should continue processing file, false if should abort.</returns>
    public delegate bool ReadCallback(params IPlyArgument[] argument);

    public interface IPly
    {
        PlyArgument Argument { get; set; }
    }
    public interface IPlyElement {}
    public interface IPlyProperty {}
    public interface IPlyArgument {}

    public class RPly
    {
        internal static ErrorCallback DefaultErrorCb = (msg) => Console.WriteLine("RPly: " + msg);
        
        /// <summary>
        /// Opens a ply file for reading (fails if file is not a ply file)
        /// </summary>
        /// <param name="name">file name</param>
        /// <param name="errorCallback">error callback function</param>
        /// <returns>The <see cref="IPly"/> reference if successful, otherwise null.</returns>
        public static IPly Open(string name, ErrorCallback errorCallback)
        {
            if (errorCallback == null)
                errorCallback = DefaultErrorCb;

            if (!PlyUtil.TypeCheck())
            {
                errorCallback("Incompatible type system");
                return null;
            }

            FileStream fp = null;
            try { fp = File.OpenRead(name); }
            catch (Exception)
            {
                errorCallback("Unable to open file");
                return null;
            }

            var buffer = new byte[4];
            if (fp.Read(buffer, 0, 4) < 4)
            {
                fp.Close();
                errorCallback("Error reading from file");
                return null;
            }
            string magic = Encoding.ASCII.GetString(buffer);
            if (magic != "ply\n")
            {
                fp.Close();
                errorCallback("Not a PLY file. Expected magic number 'ply\\n'");
                return null;
            }
            var ply = PlyFile.Alloc();
            ply.File = fp;
            ply.IoMode = IoMode.Read;
            ply.ErrorCallback = errorCallback;

            return ply;
        }

        /// <summary>
        /// Reads and parses the header of a ply file returned by <see cref="Open"/>.
        /// </summary>
        /// <param name="ply">Handle returned by <see cref="Open"/>.</param>
        /// <returns>true if successful, false otherwise</returns>
        public static bool ReadHeader(IPly ply)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Sets up callbacks for property reading after header was parsed
        /// </summary>
        /// <param name="ply">Handle returned by <see cref="Open"/>.</param>
        /// <param name="elementName">element where property is</param>
        /// <param name="propertyName">property to associate element with</param>
        /// <param name="readCallback">function to be called for each property value</param>
        /// <param name="userData">user data that will be passed to callback</param>
        /// <returns>0 if no element or no property in element, returns the number of element instances otherwise. </returns>
        public static int SetReadCallback(IPly ply, string elementName, string propertyName, ReadCallback readCallback, object userData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns information about the element originating a callback
        /// </summary>
        /// <param name="argument">handle to argument</param>
        /// <param name="element">receives a the element handle (if non-null)</param>
        /// <param name="instanceIndex">receives the index of the current element instance (if non-null)</param>
        /// <returns>true if successful, false otherwise</returns>
        public static bool GetArgumentElement(IPlyArgument argument, out IPlyElement element, out int instanceIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns information about the property originating a callback
        /// </summary>
        /// <param name="argument">handle to argument </param>
        /// <param name="property">receives the property handle (if non-null)</param>
        /// <param name="length">receives the number of values in this property (if non-null)</param>
        /// <param name="valueIndex">receives the index of current property value (if non-null)</param>
        /// <returns>true if successful, false otherwise</returns>
        public static bool GetArgumentProperty(IPlyArgument argument, out IPlyProperty property, out int length, out int valueIndex)
        {
            throw new NotImplementedException();
        }
    }
}
