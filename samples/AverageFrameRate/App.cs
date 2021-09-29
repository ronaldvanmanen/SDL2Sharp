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
using System.Threading;
using SDL2Sharp;
using SDL2TTFSharp.Interop;

namespace AverageFrameRate
{
    internal unsafe class App : Application
    {
        private AutoResetEvent _quitEvent = null!;

        private AutoResetEvent _rendererInvalidatedEvent = null!;

        private Window _window = null!;

        private Thread _renderThread = null!;

        public App()
        : base(Subsystem.Video)
        { }

        protected override void OnInit(string[] args)
        {
            _quitEvent = new AutoResetEvent(false);
            _rendererInvalidatedEvent = new AutoResetEvent(false);
            _window = new Window("Average Frame Rate", 640, 480, WindowFlags.Shown | WindowFlags.Resizable);
            _window.SizeChanged += OnSizeChanged;
            _renderThread = new Thread(Render);
            _renderThread.Start();
        }

        protected override void OnQuit()
        {
            _quitEvent.Set();
            _renderThread?.Join();
            _window?.Dispose();
            _rendererInvalidatedEvent?.Dispose();
            _quitEvent?.Dispose();
        }

        private void Render()
        {
            WaitHandle[] waitHandles = new WaitHandle[] { _quitEvent, _rendererInvalidatedEvent };
            DateTime lastUpdateTime = DateTime.UtcNow;
            TimeSpan updateInterval = TimeSpan.FromMilliseconds(1000d);
            Color textColor = new Color(0, 0, 0, 255);
            Color drawColor = new Color(255, 255, 255, 0);
            Int32 frameCount = 0;
            Renderer renderer = null!;
            Font font = null!;

            try
            {
                renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
                renderer.RenderDrawColor = drawColor;
                font = new Font("lazy.ttf", 28);

                while (true)
                {
                    var waitHandleIndex = WaitHandle.WaitAny(waitHandles, 0);
                    if (waitHandleIndex == 0)
                    {
                        return;
                    }

                    if (waitHandleIndex == 1)
                    {
                        renderer.Dispose();
                        renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
                        renderer.RenderDrawColor = drawColor;
                    }

                    frameCount++;

                    var currentTime = DateTime.UtcNow;
                    var elapsedTime = currentTime - lastUpdateTime;
                    var frameRate = frameCount / elapsedTime.TotalSeconds;
                    var frameRateText = $"Average frame rate = {frameRate:0.00}";
                    using (var frameRateSurface = font.RenderSolid(frameRateText, textColor))
                    {
                        using (var frameRateTexture = renderer.CreateTextureFromSurface(frameRateSurface))
                        {
                            var outputSize = renderer.OutputSize;
                            var x = Math.Abs(outputSize.Width - frameRateTexture.Width) / 2;
                            var y = Math.Abs(outputSize.Height - frameRateTexture.Height) / 2;
                            var dest = new Rectangle(x, y, frameRateTexture.Width, frameRateTexture.Height);

                            renderer.RenderClear();
                            renderer.RenderCopy(frameRateTexture, dest);
                        }
                    }

                    lastUpdateTime = currentTime;
                    frameCount = 0;
                    renderer.RenderPresent();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            finally
            {
                font?.Dispose();
                renderer?.Dispose();
            }
        }

        private void OnSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            _rendererInvalidatedEvent.Set();
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
