namespace RPlySharp
{
    internal class PlyElement : IPlyElement
    {
        /// <summary>name of this property</summary>
        public string Name { get; set; }
        /// <summary>number of elements of this type in file</summary>
        public int InstanceCount { get; set; }
        /// <summary>property descriptions for this element</summary>
        public IPlyProperty[] Properties { get; set; }
    }
}
