namespace SDL2Sharp
{
    public unsafe partial struct SDL_TextInputEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        [NativeTypeName("Uint32")]
        public uint windowID;

        [NativeTypeName("char [32]")]
        public fixed sbyte text[32];
    }
}
