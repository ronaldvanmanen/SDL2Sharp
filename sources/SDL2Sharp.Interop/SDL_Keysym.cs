namespace SDL2Sharp.Interop
{
    public partial struct SDL_Keysym
    {
        public SDL_Scancode scancode;

        [NativeTypeName("SDL_Keycode")]
        public int sym;

        [NativeTypeName("Uint16")]
        public ushort mod;

        [NativeTypeName("Uint32")]
        public uint unused;
    }
}
