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

namespace ParticleSystem
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

        private volatile int _mouseX;

        private volatile int _mouseY;

        protected override void OnInitializing(string[] args)
        {
            Subsystems = Subsystems.Video;
        }

        protected override void OnInitialized(string[] args)
        {
            _window = new Window("Particle System", 640, 480, WindowFlags.Shown | WindowFlags.Resizable);
            _window.KeyDown += OnWindowKeyDown;
            _window.MouseMotion += OnWindowMouseMotion;
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
            var lastFrameTime = DateTime.UtcNow;
            var lastFrameRateUpdateTime = DateTime.UtcNow;
            var frameRateUpdateInterval = TimeSpan.FromMilliseconds(500d);
            var frameRate = 0d;
            var frameRateText = $"FPS: {frameRate:0.00}";
            var frameCounter = 0;
            var particleEmitterColor = new Color(255, 0, 0, 255);
            var particleEmmiterPosition = new Point(_window.Width / 2, _window.Height / 2);
            var particleEmitter = new ParticleEmitter(particleEmitterColor, particleEmmiterPosition, 15);

            try
            {
                while (_rendering)
                {
                    if (_rendererInvalidated)
                    {
                        renderer?.Dispose();
                        renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
                        _rendererInvalidated = false;
                    }

                    var currentFrameTime = DateTime.UtcNow;
                    var elapsedTime = currentFrameTime - lastFrameTime;
                    particleEmitter.MoveTo(_mouseX, _mouseY);
                    particleEmitter.Update(currentFrameTime, elapsedTime);

                    renderer.DrawColor = _backgroundColor;
                    renderer.BlendMode = BlendMode.None;
                    renderer.Clear();

                    particleEmitter.Render(renderer);

                    var elapsedFrameRateTime = currentFrameTime - lastFrameRateUpdateTime;
                    if (elapsedFrameRateTime > frameRateUpdateInterval)
                    {
                        frameRate = frameCounter / elapsedFrameRateTime.TotalSeconds;
                        frameRateText = $"FPS: {frameRate:0.00}";
                        lastFrameRateUpdateTime = currentFrameTime;
                        frameCounter = 0;
                    }

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

        private void OnWindowMouseMotion(object? sender, MouseMotionEventArgs e)
        {
            _mouseX = e.X;
            _mouseY = e.Y;
        }

        private void OnWindowSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            _rendererInvalidated = true;
        }

        private static int Main(string[] args)
        {
            var app = new App();
            var exitCode = app.Run(args);
            return exitCode;
        }
    }
}
