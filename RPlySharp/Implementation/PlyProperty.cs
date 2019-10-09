namespace RPlySharp
{
    internal class PlyProperty : IPlyProperty
    {
        /// <summary>name of this property</summary>
        public string Name { get; set; }
        /// <summary>type of this property (list or type of scalar value)</summary>
        public PlyType Type { get; set; }
        /// <summary>type of list property count and values</summary>
        public PlyType ValueType { get; set; }
        /// <summary>type of list property count and values</summary>
        public PlyType LengthType { get; set; }
        /// <summary>function to be called when this property is called</summary>
        public ReadCallback ReadCallback { get; set; }
    }
}
