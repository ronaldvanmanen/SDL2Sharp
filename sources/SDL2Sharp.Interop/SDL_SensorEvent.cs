namespace SDL2Sharp.Interop
{
    public unsafe partial struct SDL_SensorEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        [NativeTypeName("Sint32")]
        public int which;

        [NativeTypeName("float [6]")]
        public fixed float data[6];
    }
}
