using System;

namespace RPlySharp
{
    internal delegate int InputHandler(IPly ply, double[] value);

    internal delegate int InputChunk(IPly ply, byte[] anyData, int size);

    internal class InputDriver
    {
        public InputHandler[] InputHandlers { get; private set; } = new InputHandler[16];
        public InputChunk InputChunk { get; set; }
        public string Name { get; set; }
    }

    internal delegate int OutputHandler(IPly ply, double[] value);

    internal delegate int OutputChunk(IPly ply, byte[] anyData, int size);

    internal class OutputDriver
    {
        public OutputHandler[] OutputHandlers { get; private set; } = new OutputHandler[16];
        public OutputChunk OutputChunk { get; set; }
        public string Name { get; set; }
    }
}
