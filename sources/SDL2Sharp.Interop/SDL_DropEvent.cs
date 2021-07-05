namespace SDL2Sharp.Interop
{
    public unsafe partial struct SDL_DropEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        [NativeTypeName("char *")]
        public sbyte* file;

        [NativeTypeName("Uint32")]
        public uint windowID;
    }
}
