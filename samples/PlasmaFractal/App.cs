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
using static System.Math;
using static SDL2Sharp.Extensions.MathExtensions;

namespace PlasmaFractal
{
    internal unsafe class App : Application
    {
        private static readonly Font _frameRateFont = new Font("lazy.ttf", 28);

        private static readonly Color _frameRateColor = new Color(255, 255, 255, 255);

        private static readonly Color _backgroundColor = new Color(0, 0, 0, 255);

        private Window _window = null!;

        private Thread _renderingThread = null!;

        private volatile bool _rendererInvalidated = false;

        private volatile bool _rendering = false;

        private volatile bool _reversePaletteRotation = false;

        protected override void OnInitializing(string[] args)
        {
            Subsystems = Subsystems.Video;
        }

        protected override void OnInitialized(string[] args)
        {
            _window = new Window("Plasma Fractal", 512, 512, WindowFlags.Shown | WindowFlags.Resizable);
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
            Image<byte> sourceImage = null!;

            var lastFrameTime = DateTime.UtcNow;
            var lastFrameRateUpdateTime = DateTime.UtcNow;
            var frameRateUpdateInterval = TimeSpan.FromMilliseconds(500d);
            var frameRate = 0d;
            var frameRateText = $"FPS: {frameRate:0.00}";
            var frameCounter = 0;
            var screenWidth = 0;
            var screenHeight = 0;

            var palette = new Palette<Rgba>(256);
            for (var i = 0; i < 32; ++i)
            {
                var l = (byte)(i * 255 / 31);
                var h = (byte)(255 - l);
                palette[i] = new Rgba(l, 0, 0, 0xFF);
                palette[i + 32] = new Rgba(h, 0, 0, 0xFF);
                palette[i + 64] = new Rgba(0, l, 0, 0xFF);
                palette[i + 96] = new Rgba(0, h, 0, 0xFF);
                palette[i + 128] = new Rgba(0, 0, l, 0xFF);
                palette[i + 160] = new Rgba(0, 0, h, 0xFF);
                palette[i + 192] = new Rgba(l, 0, l, 0xFF);
                palette[i + 224] = new Rgba(h, 0, h, 0xFF);
            }

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
                        screenImage = new Image<Rgba>(screenWidth, screenHeight);
                        sourceImage = GenerateDiamondSquareImage(screenWidth, screenHeight);

                        _rendererInvalidated = false;
                    }

                    Parallel.For(0, screenImage.Height, y =>
                    {
                        for (var x = 0; x < screenImage.Width; ++x)
                        {
                            screenImage[y, x] = palette[sourceImage[y, x]];
                        }
                    });

                    var currentFrameTime = DateTime.UtcNow;
                    var elapsedTime = currentFrameTime - lastFrameTime;
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

                    if (_reversePaletteRotation)
                    {
                        palette.RotateRight();
                    }
                    else
                    {
                        palette.RotateLeft();
                    }
                }
            }
            finally
            {
                renderer?.Dispose();
            }
        }

        private void OnWindowKeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is Window window)
            {
                if (e.KeyCode == KeyCode.F11 || (e.KeyCode == KeyCode.Return && e.Alt))
                {
                    window.IsFullScreenDesktop = !window.IsFullScreenDesktop;
                }

                if (e.KeyCode == KeyCode.R)
                {
                    _reversePaletteRotation = !_reversePaletteRotation;
                }
            }
        }

        private void OnWindowSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            _rendererInvalidated = true;
        }

        private static readonly Random _random = new Random();

        private static Image<byte> GenerateDiamondSquareImage(int width, int height)
        {
            var size = NextPowerOfTwo(Max(width, height)) + 1;
            var image = GenerateDiamondSquareImage(size);
            return image.Crop(0, 0, height, width);
        }

        private static Image<byte> GenerateDiamondSquareImage(int size)
        {
            var image = new Image<byte>(size, size);

            var randomness = 256;

            image[0, 0] = (byte)_random.Next(0, randomness);
            image[0, size - 1] = (byte)_random.Next(0, randomness);
            image[size - 1, 0] = (byte)_random.Next(0, randomness);
            image[size - 1, size - 1] = (byte)_random.Next(0, randomness);

            randomness /= 2;

            for (var stepSize = size - 1; stepSize > 1; stepSize /= 2)
            {
                var halfStepSize = stepSize / 2;

                for (var y = halfStepSize; y < image.Height; y += stepSize)
                {
                    for (var x = halfStepSize; x < image.Width; x += stepSize)
                    {
                        Diamond(image, x, y, halfStepSize, randomness);
                    }
                }

                for (var y = 0; y < image.Height; y += halfStepSize)
                {
                    for (var x = (y % stepSize) == 0 ? halfStepSize : 0; x < image.Width; x += stepSize)
                    {
                        Square(image, x, y, halfStepSize, randomness);
                    }
                }

                randomness /= 2;
            }
            return image;
        }

        private static void Diamond(Image<byte> map, int centerX, int centerY, int distance, int randomness)
        {
            var sum = 0;
            var count = 0;
            var top = centerY - distance;
            if (top >= 0 && top < map.Height)
            {
                var left = centerX - distance;
                if (left >= 0 && left < map.Width)
                {
                    sum += map[top, left];
                    count++;
                }

                var right = centerX + distance;
                if (right >= 0 && right < map.Height)
                {
                    sum += map[top, right];
                    count++;
                }
            }

            var bottom = centerY + distance;
            if (bottom >= 0 && bottom < map.Height)
            {
                var left = centerX - distance;
                if (left >= 0 && left < map.Width)
                {
                    sum += map[bottom, left];
                    count++;
                }

                var right = centerX + distance;
                if (right >= 0 && right < map.Height)
                {
                    sum += map[bottom, right];
                    count++;
                }
            }

            var average = sum / count;
            var random = _random.Next(-randomness, randomness);
            var value = Clamp(average + random, 0, 255);

            map[centerY, centerX] = (byte)value;
        }

        private static void Square(Image<byte> map, int centerX, int centerY, int distance, int randomness)
        {
            var sum = 0;
            var count = 0;
            var top = centerY - distance;
            if (top >= 0 && top < map.Height)
            {
                sum += map[top, centerX];
                count++;
            }

            var left = centerX - distance;
            if (left >= 0 && left < map.Width)
            {
                sum += map[centerY, left];
                count++;
            }

            var bottom = centerY + distance;
            if (bottom >= 0 && bottom < map.Height)
            {
                sum += map[bottom, centerX];
                count++;
            }

            var right = centerX + distance;
            if (right >= 0 && right < map.Height)
            {
                sum += map[centerY, right];
                count++;
            }

            var average = sum / count;
            var random = _random.Next(-randomness, randomness);
            var value = Clamp(average + random, 0, 255);

            map[centerY, centerX] = (byte)value;
        }

        private static int Main(string[] args)
        {
            var app = new App();
            var exitCode = app.Run(args);
            return exitCode;
        }
    }
}
