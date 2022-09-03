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
using System.Diagnostics;
using Microsoft.Toolkit.HighPerformance;
using SDL2Sharp;
using SDL2Sharp.Extensions;
using static System.Math;
using static SDL2Sharp.Extensions.MathExtensions;

namespace TunnelEffect
{
    internal sealed class App : Application
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

        private Renderer _renderer = null!;

        private Texture<Rgba8888> _screenTexture = null!;

        private Memory2D<Rgba8888> _sourceImage = null!;

        private Memory2D<Transform> _transformTable = null!;

        private Stopwatch _realTime = null!;

        private Stopwatch _frameTime = null!;

        private int _frameCount;

        private double _frameRate;

        protected override void OnInitializing()
        {
            Subsystems = Subsystems.Video;
        }

        protected override void OnInitialized()
        {
            _window = new Window("Tunnel Effect", 640, 480, WindowFlags.Resizable);
            _window.KeyDown += OnWindowKeyDown;
            _window.SizeChanged += OnWindowSizeChanged;
            _realTime = new Stopwatch();
            _frameTime = new Stopwatch();
            _frameCount = 0;
            _frameRate = double.NaN;

            OnWindowSizeChanged(null, new WindowSizeChangedEventArgs(_window.Width, _window.Height));

            _realTime.Start();
        }

        protected override void OnQuiting()
        {
            _realTime.Stop();
            _renderer?.Dispose();
            _window?.Dispose();
        }

        protected override void OnIdle()
        {
            _frameTime.Start();
            Render(_realTime.Elapsed);
            _frameTime.Stop();
            _frameCount++;

            if (_frameTime.ElapsedMilliseconds >= 1000d)
            {
                _frameRate = _frameCount * 1000d / _frameTime.ElapsedMilliseconds;
                _frameCount = 0;
                _frameTime.Reset();
            }
        }

        private void Render(TimeSpan realTime)
        {
            var screenImage = _screenTexture.Lock();
            var screenWidth = screenImage.Width;
            var screenHeight = screenImage.Height;

            var sourceImage = _sourceImage.Span;
            var sourceWidth = _sourceImage.Width;
            var sourceHeight = _sourceImage.Height;
            var sourceWidthMask = sourceWidth - 1;
            var sourceHeightMask = sourceHeight - 1;

            var transformTable = _transformTable.Span;

            var shiftX = (int)(screenWidth * 1.0 * realTime.TotalSeconds);
            var shiftY = (int)(screenHeight * 0.25 * realTime.TotalSeconds);
            var lookX = (sourceWidth - screenWidth) / 2;
            var lookY = (sourceHeight - screenHeight) / 2;
            var shiftLookX = shiftX + lookX;
            var shiftLookY = shiftY + lookY;

            for (var screenY = 0; screenY < screenHeight; ++screenY)
            {
                var transformY = screenY + lookY;
                for (var screenX = 0; screenX < screenWidth; ++screenX)
                {
                    var transformX = screenX + lookX;
                    var transform = transformTable[transformY, transformX];
                    var sourceX = (transform.Distance + shiftLookX) & sourceWidthMask;
                    var sourceY = (transform.Angle + shiftLookY) & sourceHeightMask;
                    screenImage[screenY, screenX] = sourceImage[sourceY, sourceX];
                }
            }

            _screenTexture.Unlock();

            _renderer.BlendMode = BlendMode.None;
            _renderer.DrawColor = _backgroundColor;
            _renderer.Clear();
            _renderer.Copy(_screenTexture);
            _renderer.DrawColor = _frameRateColor;
            _renderer.DrawTextBlended(8, 8, _frameRateFont, $"FPS: {_frameRate:0.0}");
            _renderer.Present();
        }

        private static Memory2D<Rgba8888> GenerateXorImage(int size)
        {
            return GenerateXorImage(size, size);
        }

        private static Memory2D<Rgba8888> GenerateXorImage(int width, int height)
        {
            var image = new Rgba8888[height, width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    image[y, x] = new Rgba8888(
                        r: 0x00,
                        g: 0x00,
                        b: (byte)((x * 256 / width) ^ (y * 256 / height)),
                        a: 0xFF
                    );
                }
            }
            return new Memory2D<Rgba8888>(image);
        }

        private static Memory2D<Transform> GenerateTransformTable(int size)
        {
            return GenerateTransformTable(size, size);
        }

        private static Memory2D<Transform> GenerateTransformTable(int width, int height)
        {
            const double ratio = 32d;
            var transformTable = new Transform[height, width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    unchecked
                    {
                        var angle = (int)(0.5 * width * Atan2(y - height / 2.0, x - width / 2.0) / PI);
                        var distance = (int)(ratio * height / Sqrt((x - width / 2d) * (x - width / 2d) + (y - height / 2d) * (y - height / 2d))) % height;
                        transformTable[y, x] = new Transform(angle, distance);
                    }
                }
            }
            return new Memory2D<Transform>(transformTable);
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
            _screenTexture?.Dispose();

            _renderer?.Dispose();

            _renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
            var screenSize = _renderer.OutputSize;
            _screenTexture = _renderer.CreateTexture<Rgba8888>(TextureAccess.Streaming, screenSize);
            var sourceImageSize = NextPowerOfTwo(Max(screenSize.Width, screenSize.Height));
            _sourceImage = GenerateXorImage(sourceImageSize);
            _transformTable = GenerateTransformTable(sourceImageSize);

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
