using System;
using System.Threading;

namespace SDL2Sharp.Samples
{
    internal static unsafe class Program
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

            // Create an application window with the following settings:
            var window = SDL.CreateWindow(
                null,                                       // window title
                (int)SDL.SDL_WINDOWPOS_UNDEFINED,           // initial x position
                (int)SDL.SDL_WINDOWPOS_UNDEFINED,           // initial y position
                640,                                        // width, in pixels
                480,                                        // height, in pixels
                (uint)SDL_WindowFlags.SDL_WINDOW_OPENGL     // flags - see below
            );

            // Check that the window was successfully created
            if (window == null)
            {
                // In the case that the window could not be made...
                Console.WriteLine("Could not create window: %s\n", SDL.GetErrorString());
                return 1;
            }

            // The window is open: could enter program loop here (see SDL_PollEvent())

            Thread.Sleep(3000);  // Pause execution for 3000 milliseconds, for example

            // Close and destroy the window
            SDL.DestroyWindow(window);

            // Clean up
            SDL.Quit();

            return 0;
        }
    }
}
