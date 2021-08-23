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
using SDL2Sharp.Interop;

namespace SDL2Sharp.Samples.BitmapViewer
{
    internal static unsafe class Program
    {
        private static int Main(string[] args)
        {
            Subsystem subsystem = null!;
            Window window = null!;
            Renderer renderer = null!;
            Texture bitmapTexture = null!;

            try
            {
                subsystem = new Subsystem(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO);
                window = new Window("SDL2Sharp", 640, 480, SDL_WindowFlags.SDL_WINDOW_OPENGL);
                renderer = window.CreateRenderer(SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
                bitmapTexture = renderer.CreateTextureFromBitmap("Sample.bmp");

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

                    renderer.Clear();
                    renderer.Copy(bitmapTexture);
                    renderer.Present();
                }

                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not run sample: {0}\n", e.Message);
                return 1;
            }
            finally
            {
                bitmapTexture?.Dispose();
                renderer?.Dispose();
                window?.Dispose();
                subsystem?.Dispose();
            }
        }
    }
}
