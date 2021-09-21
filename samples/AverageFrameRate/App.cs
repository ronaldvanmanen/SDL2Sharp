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
using System.Globalization;
using SDL2Sharp;
using SDL2TTFSharp.Interop;

namespace BitmapViewer
{
    internal unsafe class App : Application
    {
        private Window _window = null!;

        private Renderer _renderer = null!;

        private Font _font = null!;

        private readonly Color _foregroundColor = new Color(0, 0, 0, 255);

        private readonly Color _backgroundColor = new Color(255, 255, 255, 0);

        private DateTime _lastFrameTime;

        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000d);

        private int _frameCount;

        public App()
        : base(Subsystem.Video)
        { }

        protected override void OnStartup(string[] args)
        {
            _window = new Window("Average Frame Rate", 640, 480);
            _renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
            _font = new Font("lazy.ttf", 28);
            _lastFrameTime = DateTime.UtcNow;
            _frameCount = 0;
        }

        protected override void OnShutdown()
        {
            _font?.Dispose();
            _renderer?.Dispose();
            _window?.Dispose();
        }

        protected override void OnIdle()
        {
            _frameCount++;

            var currentFrameTime = DateTime.UtcNow;
            var elapsedTime = currentFrameTime - _lastFrameTime;
            if (elapsedTime > _updateInterval)
            {
                var frameRate = _frameCount / elapsedTime.TotalSeconds;
                var frameRateText = $"Average frame rate = {frameRate:0.00}";
                using (var frameRateSurface = _font.RenderSolid(frameRateText, _foregroundColor))
                using (var frameRateTexture = _renderer.CreateTextureFromSurface(frameRateSurface))
                {
                    var clientSize = _window.ClientSize;
                    var x = Math.Abs(clientSize.Width - frameRateTexture.Width) / 2;
                    var y = Math.Abs(clientSize.Height - frameRateTexture.Height) / 2;
                    var origin = new Point(x, y);

                    _renderer.SetDrawColor(_backgroundColor);
                    _renderer.Clear();
                    _renderer.Copy(frameRateTexture, origin);
                    _renderer.Present();
                }

                _lastFrameTime = currentFrameTime;
                _frameCount = 0;
            }
            else
            {
                _renderer.Present();
            }
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
