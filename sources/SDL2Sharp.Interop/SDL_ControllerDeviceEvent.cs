namespace SDL2Sharp.Interop
{
    public partial struct SDL_ControllerDeviceEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        [NativeTypeName("Sint32")]
        public int which;
    }
}
