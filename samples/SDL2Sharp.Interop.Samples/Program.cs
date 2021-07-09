// SDL2Sharp
//
// Copyright (C) 2021 Ronald van Manen <rvanmanen@gmail.com>
//
// This software is provided 'as-is', without any express or implied
// warranty.  In no event will the authors be held liable for any damages
// arising from the use of this software.
// 
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would be
//    appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be
//    misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.

using System;
using System.Text;

namespace SDL2Sharp.Interop.Samples
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

            SDL_Window* window = null;

            fixed (byte* title = &Encoding.ASCII.GetBytes("SDL2Sharp")[0])
            {
                window = SDL.CreateWindow(
                    (sbyte*)title,
                    (int)SDL.SDL_WINDOWPOS_UNDEFINED,
                    (int)SDL.SDL_WINDOWPOS_UNDEFINED,
                    640,
                    480,
                    (uint)SDL_WindowFlags.SDL_WINDOW_OPENGL
                );
            }

            if (window == null)
            {
                Console.WriteLine("Could not create window: {0}\n", SDL.GetErrorString());
                return 1;
            }

            var renderer = SDL.CreateRenderer(window, -1, (uint)SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            SDL_Texture* bitmapTexture = null;
            fixed (byte* file = &Encoding.ASCII.GetBytes("Sample.bmp")[0])
            fixed (byte* mode = &Encoding.ASCII.GetBytes("rb")[0])
            {
                var bitmapSurface = SDL.LoadBMP_RW(SDL.RWFromFile((sbyte*)file, (sbyte*)mode), 1);
                bitmapTexture = SDL.CreateTextureFromSurface(renderer, bitmapSurface);
                SDL.FreeSurface(bitmapSurface);
            }

            while (true)
            {
                SDL_Event e;
                if (0 == SDL.PollEvent(&e))
                {
                    if (e.type == (uint)SDL_EventType.SDL_QUIT)
                    {
                        break;
                    }
                }

                SDL.RenderClear(renderer);
                SDL.RenderCopy(renderer, bitmapTexture, null, null);
                SDL.RenderPresent(renderer);
            }

            SDL.DestroyTexture(bitmapTexture);
            SDL.DestroyRenderer(renderer);
            SDL.DestroyWindow(window);

            SDL.Quit();

            return 0;
        }
    }
}
