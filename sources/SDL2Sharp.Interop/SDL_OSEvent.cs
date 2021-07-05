namespace SDL2Sharp.Interop
{
    public partial struct SDL_OSEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;
    }
}
