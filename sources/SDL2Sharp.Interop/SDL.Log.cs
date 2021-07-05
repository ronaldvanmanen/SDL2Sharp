using System.Text;

namespace SDL2Sharp.Interop
{
    public static unsafe partial class SDL
    {
        public static void Log(string message)
        {
            var bytes = Encoding.ASCII.GetBytes(message);
            fixed (byte* fixedBytes = bytes)
            {
                Log((sbyte*)fixedBytes);
            }
        }
    }
}
