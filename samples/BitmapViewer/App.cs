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
using SDL2Sharp;

namespace BitmapViewer
{
    internal unsafe class App : Application
    {
        private Window _window = null!;

        private Renderer _renderer = null!;

        private Texture _bitmapTexture = null!;

        public App()
        : base(Subsystem.Video)
        { }

        protected override void OnStartup(string[] args)
        {
            _window = new Window("Bitmap Viewer", 640, 480);
            _renderer = _window.CreateRenderer(RendererFlags.Accelerated);
            _bitmapTexture = _renderer.CreateTextureFromBitmap(args[0]);
        }

        protected override void OnShutdown()
        {
            _bitmapTexture?.Dispose();
            _renderer?.Dispose();
            _window?.Dispose();
        }

        protected override void OnIdle()
        {
            _renderer.Clear();
            _renderer.Copy(_bitmapTexture);
            _renderer.Present();
        }

        private static int Main(string[] args)
        {
            App app = null!;

            try
            {
                app = new App();
                app.Run(args);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not run sample: {0}", e.Message);
                return 1;
            }
            finally
            {
                app?.Dispose();
            }
        }
    }
}
