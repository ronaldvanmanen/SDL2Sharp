// SDL2Sharp
//
// Copyright (C) 2022 Ronald van Manen <rvanmanen@gmail.com>
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

using System.Diagnostics;
using SDL2Sharp;
using SDL2Sharp.Extensions;

namespace SwirlStars
{
    internal sealed class App : Application
    {
        private static readonly TimeSpan HideCursorDelay = TimeSpan.FromSeconds(1);

        private static readonly Font _frameRateFont = new Font("lazy.ttf", 28);

        private static readonly Color _frameRateColor = new Color(255, 255, 255, 255);

        private static readonly Color _backgroundColor = new Color(0, 0, 0, 255);

        private Window _window = null!;

        private Renderer _renderer = null!;

        private Stopwatch _realTime = null!;

        private Stopwatch _frameTime = null!;

        private int _frameCount;

        private double _frameRate;

        private DateTime _cursorLastActive = DateTime.UtcNow;

        private Random _random = null!;

        private List<Star> _stars = null!;

        protected override void OnInitializing()
        {
            Subsystems = Subsystems.Video;
        }

        protected override void OnInitialized()
        {
            _window = new Window("Swirl Stars", 640, 480, WindowFlags.Shown | WindowFlags.Resizable);
            _window.KeyDown += OnWindowKeyDown;
            _window.SizeChanged += OnWindowSizeChanged;
            _window.MouseMotion += OnWindowMouseMotion;
            _renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
            _realTime = new Stopwatch();
            _frameTime = new Stopwatch();
            _frameCount = 0;
            _frameRate = double.NaN;
            _realTime.Start();
            _random = new Random();
            _stars = new List<Star>(GenerateStars(64));
        }

        private IEnumerable<Star> GenerateStars(int count)
        {
            for (var i = 0; i < count; ++i)
            {
                var x = _random.Next(-500, 500);
                var y = _random.Next(-500, 500);
                var z = _random.Next(100, 1000);
                yield return new Star(x, y, z, new Color(255, 255, 255, 255));
            }
        }

        protected override void OnQuiting()
        {
            _realTime.Stop();
            _renderer?.Dispose();
            _window?.Dispose();
        }

        protected override void OnIdle()
        {
            if (Cursor.Shown)
            {
                var cursorInactivity = DateTime.UtcNow - _cursorLastActive;
                if (cursorInactivity >= HideCursorDelay)
                {
                    Cursor.Hide();
                }
            }

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
            _renderer.BlendMode = BlendMode.None;
            _renderer.DrawColor = _backgroundColor;
            _renderer.Clear();

            var screenSize = _renderer.OutputSize;
            var screenCenterX = screenSize.Width / 2;
            var screenCenterY = screenSize.Height / 2;
            foreach (var star in _stars)
            {
                star.Z -= 5;
                var screenX = star.X / star.Z * 100f + screenCenterX;
                var screenY = star.Y / star.Z * 100f + screenCenterY;
                if (screenX < 0 || screenX >= screenSize.Width ||
                    screenY < 0 || screenY >= screenSize.Height ||
                    star.Z < 1)
                {
                    star.X = _random.Next(-500, 500);
                    star.Y = _random.Next(-500, 500);
                    star.Z = _random.Next(100, 1000);
                }

                _renderer.DrawColor = star.Color;
                _renderer.DrawPoint(screenX, screenY);
            }

            _renderer.DrawColor = _frameRateColor;
            _renderer.DrawTextBlended(8, 8, _frameRateFont, $"FPS: {_frameRate:0.0}");
            _renderer.Present();
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
            _renderer?.Dispose();
            _renderer = _window.CreateRenderer(RendererFlags.Accelerated | RendererFlags.PresentVSync);
        }

        private void OnWindowMouseMotion(object? sender, MouseMotionEventArgs e)
        {
            if (Cursor.Hidden)
            {
                Cursor.Show();
            }

            _cursorLastActive = DateTime.UtcNow;
        }

        private static int Main(string[] args)
        {
            var app = new App();
            var exitCode = app.Run(args);
            return exitCode;
        }
    }
}
