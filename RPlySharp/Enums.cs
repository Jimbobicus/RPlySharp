namespace RPlySharp
{
    public enum StorageMode
    {
        BigEndian,
        LittleEndian,
        Ascii,
        Default
    }

    public enum PlyType
    {
        Int8,
        UInt8,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Float32,
        Float64,
        Char,
        UChar,
        Short,
        UShort,
        Int,
        UInt,
        Float,
        Double,
        List
    }

    internal enum IoMode
    {
        Read, Write
    }
}
