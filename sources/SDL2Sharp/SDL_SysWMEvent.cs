namespace SDL2Sharp
{
    public unsafe partial struct SDL_SysWMEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        public SDL_SysWMmsg* msg;
    }
}
