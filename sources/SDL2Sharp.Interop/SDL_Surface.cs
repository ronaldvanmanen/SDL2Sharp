namespace SDL2Sharp.Interop
{
    public unsafe partial struct SDL_Surface
    {
        [NativeTypeName("Uint32")]
        public uint flags;

        public SDL_PixelFormat* format;

        public int w;

        public int h;

        public int pitch;

        public void* pixels;

        public void* userdata;

        public int locked;

        public void* list_blitmap;

        public SDL_Rect clip_rect;

        [NativeTypeName("struct SDL_BlitMap *")]
        public SDL_BlitMap* map;

        public int refcount;

        public partial struct SDL_BlitMap
        {
        }
    }
}
