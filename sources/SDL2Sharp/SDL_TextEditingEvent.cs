namespace SDL2Sharp
{
    public unsafe partial struct SDL_TextEditingEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        [NativeTypeName("Uint32")]
        public uint windowID;

        [NativeTypeName("char [32]")]
        public fixed sbyte text[32];

        [NativeTypeName("Sint32")]
        public int start;

        [NativeTypeName("Sint32")]
        public int length;
    }
}
