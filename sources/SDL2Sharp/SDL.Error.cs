using System;
using System.Text;

namespace SDL2Sharp
{
    public static unsafe partial class SDL
    {
        public static string GetErrorString()
        {
            return new string(GetError());
        }
    }
}
