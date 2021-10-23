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
using SDL2Sharp.Extensions;

namespace BitmapViewer
{
    internal unsafe class App : Application
    {
        private Window _window = null!;

        private Renderer _renderer = null!;

        private Texture _bitmapTexture = null!;

        protected override void OnInitializing(string[] args)
        {
            Subsystems = Subsystems.Video;
        }

        protected override void OnInitialized(string[] args)
        {
            try
            {
                _window = new Window("Bitmap Viewer", 640, 480, WindowFlags.Resizable);
                _renderer = _window.CreateRenderer(RendererFlags.Accelerated);
                _bitmapTexture = _renderer.CreateTextureFromBitmap(args[0]);
                _window.SizeChanged += OnSizeChanged;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Could not run sample: {e.Message}");
                Quit(1);
            }
        }

        protected override void OnQuiting(int exitCode)
        {
            _window.SizeChanged -= OnSizeChanged;
            _bitmapTexture?.Dispose();
            _renderer?.Dispose();
            _window?.Dispose();
        }

        protected override void OnIdle()
        {
            Render();
        }

        private void OnSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            _renderer.Clear();
            _renderer.Copy(_bitmapTexture);
            _renderer.Present();
        }

        private static int Main(string[] args)
        {
            var app = new App();
            var exitCode = app.Run(args);
            return exitCode;
        }
    }
}
