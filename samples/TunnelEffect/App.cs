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
using SDL2Sharp;
using SDL2Sharp.Extensions;

namespace TunnelEffect
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

        protected override void OnInitializing(string[] args)
        {
            Subsystems = Subsystems.Video;
        }

        protected override void OnInitialized(string[] args)
        {
            _window = new Window("Tunnel Effect", 640, 480, WindowFlags.Resizable);
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
            var startTime = DateTime.UtcNow;
            var lastFrameTime = DateTime.UtcNow;
            var lastFrameRateUpdateTime = DateTime.UtcNow;
            var frameRateUpdateInterval = TimeSpan.FromMilliseconds(500d);
            var frameRate = 0d;
            var frameRateText = $"FPS: {frameRate:0.00}";
            var frameCounter = 0;
            var screenWidth = 0;
            var screenHeight = 0;
            Texture screenTexture = null!;
            var textureWidth = 0;
            var textureHeight = 0;
            uint[,] texture = null!;
            int[,] distanceTable = null!;
            int[,] angleTable = null!;

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
                        textureWidth = textureHeight = NextPowerOfTwo(Math.Max(screenWidth, screenHeight));
                        texture = GenerateXorTexture(textureWidth, textureHeight);
                        distanceTable = GenerateDistanceTable(textureWidth, textureHeight);
                        angleTable = GenerateAngleTable(textureWidth, textureHeight);
                        _rendererInvalidated = false;
                    }

                    renderer.RenderDrawColor = _backgroundColor;
                    renderer.RenderBlendMode = BlendMode.None;
                    renderer.RenderClear();

                    var currentTime = DateTime.UtcNow;
                    var elapsedTime = currentTime - startTime;
                    var animation = elapsedTime.TotalSeconds;
                    var shiftX = (int)(screenWidth * 1.0 * animation);
                    var shiftY = (int)(screenHeight * 0.25 * animation);
                    var lookX = (textureWidth - screenWidth) / 2;
                    var lookY = (textureHeight - screenHeight) / 2;

                    var surface = screenTexture.Lock<uint>();
                    for (var y = 0; y < surface.Height; y++)
                    {
                        for (var x = 0; x < surface.Width; x++)
                        {
                            var cx = Math.Abs((distanceTable[y + lookY, x + lookX] + shiftX + lookX) % textureWidth);
                            var cy = Math.Abs((angleTable[y + lookY, x + lookX] + shiftY + lookY) % textureHeight);
                            surface[y, x] = texture[cy, cx];
                        }
                    }
                    screenTexture.Unlock();

                    renderer.RenderCopy(screenTexture);

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

                    renderer.RenderDrawColor = _frameRateColor;
                    renderer.RenderTextBlended(8, 8, _frameRateFont, frameRateText);
                    renderer.RenderPresent();
                    frameCounter++;
                    lastFrameTime = currentFrameTime;
                }
            }
            finally
            {
                renderer?.Dispose();
            }
        }

        private static uint[,] GenerateXorTexture(int width, int height)
        {
            var texture = new uint[height, width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    byte r = 0x0;
                    byte g = 0x0;
                    byte b = (byte)((x * 256 / width) ^ (y * 256 / height));
                    byte a = 0xFF;
                    uint rgba = (uint)(r << 24 | g << 16 | b << 8 | a);
                    texture[y, x] = rgba;
                }
            }
            return texture;
        }

        private static int[,] GenerateAngleTable(int textureWidth, int textureHeight)
        {
            var angleTable = new int[textureHeight, textureWidth];
            for (var y = 0; y < textureHeight; y++)
            {
                for (var x = 0; x < textureWidth; x++)
                {
                    angleTable[y, x] = (int)(0.5 * textureWidth * Math.Atan2(y - textureHeight / 2.0, x - textureWidth / 2.0) / Math.PI);
                }
            }
            return angleTable;
        }

        private static int[,] GenerateDistanceTable(int textureWidth, int textureHeight)
        {
            const double ratio = 32d;
            var distanceTable = new int[textureHeight, textureWidth];
            for (var y = 0; y < textureHeight; y++)
            {
                for (var x = 0; x < textureWidth; x++)
                {
                    unchecked
                    {
                        distanceTable[y, x] = (int)(ratio * textureHeight / Math.Sqrt((x - textureWidth / 2d) * (x - textureWidth / 2d) + (y - textureHeight / 2d) * (y - textureHeight / 2d)) % textureHeight);
                    }
                }
            }
            return distanceTable;
        }

        private void OnWindowSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            _rendererInvalidated = true;
        }

        private static int NextPowerOfTwo(int value)
        {
            --value;
            value |= (value >> 1);
            value |= (value >> 2);
            value |= (value >> 4);
            value |= (value >> 8);
            value |= (value >> 16);
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
