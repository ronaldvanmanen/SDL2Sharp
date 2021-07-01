namespace SDL2Sharp
{
    public unsafe partial struct SDL_Palette
    {
        public int ncolors;

        public SDL_Color* colors;

        [NativeTypeName("Uint32")]
        public uint version;

        public int refcount;
    }
}
