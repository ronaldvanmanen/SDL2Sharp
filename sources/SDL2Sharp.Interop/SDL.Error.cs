namespace SDL2Sharp.Interop
{
    public static unsafe partial class SDL
    {
        public static string GetErrorString()
        {
            return new string(GetError());
        }
    }
}
