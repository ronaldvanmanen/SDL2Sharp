namespace SDL2Sharp.Interop
{
    public partial struct SDL_QuitEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;
    }
}
