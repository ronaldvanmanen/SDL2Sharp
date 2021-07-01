namespace SDL2Sharp
{
    public unsafe partial struct SDL_DisplayMode
    {
        [NativeTypeName("Uint32")]
        public uint format;

        public int w;

        public int h;

        public int refresh_rate;

        public void* driverdata;
    }
}
