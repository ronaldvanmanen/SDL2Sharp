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
using System.Threading;
using System.Threading.Tasks;
using SDL2Sharp;
using SDL2Sharp.Extensions;

namespace TunnelEffect
{
    internal unsafe class App : Application
    {
        private readonly struct Transform
        {
            public Transform(int angle, int distance)
            {
                Angle = angle;
                Distance = distance;
            }

            public int Angle { get; }

            public int Distance { get; }
        }

        private static readonly Font _frameRateFont = new Font("lazy.ttf", 28);

        private static readonly Color _frameRateColor = new Color(255, 255, 255, 255);

        private static readonly Color _backgroundColor = new Color(0, 0, 0, 255);

        private Window _window = null!;

        private Thread _renderingThread = null!;

        private volatile bool _rendererInvalidated = false;

        private volatile bool _rendering = false;

        protected override void OnInitializing(string[] args)
        {
            Subsystems = Subsystems.Video;
        }

        protected override void OnInitialized(string[] args)
        {
            _window = new Window("Tunnel Effect", 640, 480, WindowFlags.Resizable);
            _window.KeyDown += OnWindowKeyDown;
            _window.SizeChanged += OnWindowSizeChanged;
            _renderingThread = new Thread(Render);
            _rendererInvalidated = true;
            _rendering = true;
            _renderingThread.Start();
        }

        protected override void OnQuiting(int exitCode)
        {
            _rendererInvalidated = false;
            _rendering = false;
            _renderingThread?.Join();
            _window?.Dispose();
        }

        private void Render()
        {
            Renderer renderer = null!;
            Texture screenTexture = null!;
            Image<Rgba> screenImage = null!;
            Image<Rgba> sourceImage = null!;
            Transform[] transformTable = null!;
            var startTime = DateTime.UtcNow;
            var lastFrameTime = DateTime.UtcNow;
            var lastFrameRateUpdateTime = DateTime.UtcNow;
            var frameRateUpdateInterval = TimeSpan.FromMilliseconds(500d);
            var frameRate = 0d;
            var frameRateText = $"FPS: {frameRate:0.00}";
            var frameCounter = 0;
            var screenWidth = 0;
            var screenHeight = 0;
            var sourceImageSize = 0;

            try
            {
                while (_rendering)
                {
                    if (_rendererInvalidated)
                    {
                        screenTexture?.Dispose();
                        renderer?.Dispose();
                        renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
                        screenWidth = renderer.OutputSize.Width;
                        screenHeight = renderer.OutputSize.Height;
                        screenTexture = renderer.CreateTexture(PixelFormatEnum.RGBA8888, TextureAccess.Streaming, screenWidth, screenHeight);
                        sourceImageSize = NextPowerOfTwo(Math.Max(screenWidth, screenHeight));
                        screenImage = new Image<Rgba>(screenWidth, screenHeight);
                        sourceImage = GenerateXorImage(sourceImageSize, sourceImageSize);
                        transformTable = GenerateTransformTable(sourceImageSize, sourceImageSize);
                        _rendererInvalidated = false;
                    }

                    var currentTime = DateTime.UtcNow;
                    var elapsedTime = currentTime - startTime;
                    var animation = elapsedTime.TotalSeconds;
                    var shiftX = (int)(screenWidth * 1.0 * animation);
                    var shiftY = (int)(screenHeight * 0.25 * animation);
                    var lookX = (sourceImageSize - screenWidth) / 2;
                    var lookY = (sourceImageSize - screenHeight) / 2;

                    Parallel.For(0, screenHeight, y =>
                    {
                        for (var x = 0; x < screenWidth; x++)
                        {
                            var transform = transformTable[(y + lookY) * sourceImageSize + (x + lookX)];
                            var transformX = Math.Abs(transform.Distance + shiftX + lookX) % sourceImageSize;
                            var transformY = Math.Abs(transform.Angle + shiftY + lookY) % sourceImageSize;
                            screenImage[y * screenWidth + x] = sourceImage[transformY * sourceImageSize + transformX];
                        }
                    });

                    var currentFrameTime = DateTime.UtcNow;
                    var elapsedFrameTime = currentFrameTime - lastFrameTime;
                    var elapsedFrameRateTime = currentFrameTime - lastFrameRateUpdateTime;
                    if (elapsedFrameRateTime > frameRateUpdateInterval)
                    {
                        frameRate = frameCounter / elapsedFrameRateTime.TotalSeconds;
                        frameRateText = $"FPS: {frameRate:0.00}";
                        lastFrameRateUpdateTime = currentFrameTime;
                        frameCounter = 0;
                    }

                    renderer.BlendMode = BlendMode.None;
                    renderer.DrawColor = _backgroundColor;
                    renderer.Clear();
                    screenTexture.Update(screenImage);
                    renderer.Copy(screenTexture);
                    renderer.DrawColor = _frameRateColor;
                    renderer.DrawTextBlended(8, 8, _frameRateFont, frameRateText);
                    renderer.Present();

                    frameCounter++;
                    lastFrameTime = currentFrameTime;
                }
            }
            finally
            {
                renderer?.Dispose();
            }
        }

        private static Image<Rgba> GenerateXorImage(int width, int height)
        {
            var image = new Image<Rgba>(width, height);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    byte r = 0x0;
                    byte g = 0x0;
                    byte b = (byte)((x * 256 / width) ^ (y * 256 / height));
                    byte a = 0xFF;
                    image[y, x] = new Rgba(r, g, b, a);
                }
            }
            return image;
        }

        private static Transform[] GenerateTransformTable(int width, int height)
        {
            const double ratio = 32d;
            var table = new Transform[height * width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    unchecked
                    {
                        var angle = (int)(0.5 * width * Atan2(y - height / 2.0, x - width / 2.0) / PI);
                        var distance = (int)(ratio * height / Sqrt((x - width / 2d) * (x - width / 2d) + (y - height / 2d) * (y - height / 2d)) % height);
                        table[y * width + x] = new Transform(angle, distance);
                    }
                }
            }
            return table;
        }

        private void OnWindowKeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is Window window)
            {
                if (e.KeyCode == KeyCode.F11 || (e.KeyCode == KeyCode.Return && e.Alt))
                {
                    window.IsFullScreenDesktop = !window.IsFullScreenDesktop;
                }
            }
        }

        private void OnWindowSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            _rendererInvalidated = true;
        }

        private static int NextPowerOfTwo(int value)
        {
            --value;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 16;
            ++value;
            return value;
        }

        private static int Main(string[] args)
        {
            var app = new App();
            var exitCode = app.Run(args);
            return exitCode;
        }
    }
}
