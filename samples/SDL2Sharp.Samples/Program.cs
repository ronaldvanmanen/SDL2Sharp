using System;

namespace SDL2Sharp.Samples
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            SDL.LibraryDirectory = (Environment.Is64BitProcess)
                ? @"..\..\..\..\packages\sdl2-2.0.14-win32-x64"
                : @"..\..\..\..\packages\sdl2-2.0.14-win32-x86";

            if (SDL.Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO) != 0)
            {
                SDL.Log($"Unable to initialize SDL: {SDL.GetErrorString()}");
                return 1;
            }

            /* ... */

            SDL.Quit();

            return 0;
        }
    }
}
