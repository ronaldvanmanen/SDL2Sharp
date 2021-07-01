namespace SDL2Sharp
{
    public partial struct SDL_ControllerTouchpadEvent
    {
        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("Uint32")]
        public uint timestamp;

        [NativeTypeName("SDL_JoystickID")]
        public int which;

        [NativeTypeName("Sint32")]
        public int touchpad;

        [NativeTypeName("Sint32")]
        public int finger;

        public float x;

        public float y;

        public float pressure;
    }
}
