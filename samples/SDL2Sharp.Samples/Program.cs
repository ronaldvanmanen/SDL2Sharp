using System;

namespace SDL2Sharp.Samples
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            SDL.LibraryDirectory = (Environment.Is64BitProcess)
                ? @"..\..\..\..\packages\sdl2.runtime.win-x64"
                : @"..\..\..\..\packages\sdl2.runtime.win-x86";

            if (SDL.Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO) != 0)
            {
                SDL.Log($"Unable to initialize SDL: {SDL.GetErrorString()}");
                return 1;
            }

            SDL.Log("Hello World!");

            SDL.Quit();

            return 0;
        }
    }
}
