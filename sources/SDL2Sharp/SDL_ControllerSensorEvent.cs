namespace SDL2Sharp
{
    public unsafe partial struct SDL_ControllerSensorEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        [NativeTypeName("SDL_JoystickID")]
        public int which;

        [NativeTypeName("Sint32")]
        public int sensor;

        [NativeTypeName("float [3]")]
        public fixed float data[3];
    }
}
