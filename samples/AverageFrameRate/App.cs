// SDL2Sharp
//
// Copyright (C) 2021-2024 Ronald van Manen <rvanmanen@gmail.com>
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
using System.Threading;
using SDL2Sharp;
using static System.Math;

namespace AverageFrameRate
{
    internal sealed class App : Application
    {
        private static readonly Color _drawColor = new(255, 255, 255, 0);

        private static readonly Color _textColor = new(0, 0, 0, 255);

        private Window _window = null!;

        private Thread _renderingThread = null!;

        private volatile bool _rendererInvalidated = false;

        private volatile bool _rendering = false;

        protected override void OnInitialized()
        {
            _window = new Window("Average Frame Rate", 640, 480, WindowFlags.Shown | WindowFlags.Resizable);
            _window.SizeChanged += OnWindowSizeChanged;
            _renderingThread = new Thread(Render);
            _rendererInvalidated = true;
            _rendering = true;
            _renderingThread.Start();
        }

        protected override void OnQuiting()
        {
            _rendererInvalidated = false;
            _rendering = false;
            _renderingThread?.Join();
            _window?.Dispose();
        }

        private void Render()
        {
            Font font = new Font("lazy.ttf", 28);
            Renderer renderer = null!;
            DateTime lastUpdateTime = DateTime.UtcNow;
            TimeSpan updateInterval = TimeSpan.FromMilliseconds(500d);
            int frameCount = 0;

            try
            {
                while (_rendering)
                {
                    var currentTime = DateTime.UtcNow;
                    var elapsedTime = currentTime - lastUpdateTime;
                    if (_rendererInvalidated || elapsedTime > updateInterval)
                    {
                        if (_rendererInvalidated)
                        {
                            renderer?.Dispose();
                            renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
                            renderer.DrawColor = _drawColor;
                            _rendererInvalidated = false;
                        }

                        renderer.Clear();

                        var frameRate = frameCount / elapsedTime.TotalSeconds;
                        var text = $"Average frame rate = {frameRate:0.00}";
                        using (var textSurface = font.RenderBlended(text, _textColor))
                        using (var textTexture = renderer.CreateTextureFromSurface(textSurface))
                        {
                            var outputSize = renderer.OutputSize;
                            var x = Abs(outputSize.Width - textTexture.Width) / 2;
                            var y = Abs(outputSize.Height - textTexture.Height) / 2;
                            var dest = new Rectangle(x, y, textTexture.Width, textTexture.Height);
                            renderer.Copy(textTexture, dest);
                        }

                        lastUpdateTime = currentTime;
                        frameCount = 0;
                    }

                    renderer.Present();
                    frameCount++;
                }
            }
            finally
            {
                renderer?.Dispose();
                font?.Dispose();
            }
        }

        private void OnWindowSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            _rendererInvalidated = true;
        }

        private static int Main()
        {
            var app = new App();
            var exitCode = app.Run();
            return exitCode;
        }
    }
}
