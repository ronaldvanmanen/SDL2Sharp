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
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using SDL2Sharp;
using SDL2Sharp.Extensions;

namespace SwirlStars
{
    internal sealed class App : Application
    {
        private static readonly TimeSpan HideCursorDelay = TimeSpan.FromSeconds(1);

        private static readonly Font _frameRateFont = new("lazy.ttf", 28);

        private static readonly Color _frameRateColor = new(255, 255, 255, 255);

        private static readonly Color _backgroundColor = new(0, 0, 0, 255);

        private static readonly Random _randomizer = new();

        private Window _window = null!;

        private Renderer _renderer = null!;

        private Stopwatch _realTime = null!;

        private Stopwatch _frameTime = null!;

        private int _frameCount;

        private double _frameRate;

        private DateTime _cursorLastActive = DateTime.UtcNow;

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
            _stars = new List<Star>(GenerateStars(256));
        }

        private static IEnumerable<Star> GenerateStars(int count)
        {
            for (var i = 0; i < count; ++i)
            {
                var star = new Star();
                ResetStar(star);
                yield return star;
            }
        }

        private static void ResetStar(Star star)
        {
            star.Position = new Vector3(
                x: -500f + 1000f * _randomizer.NextSingle(),
                y: -500f + 1000f * _randomizer.NextSingle(),
                z: 100f + 900f * _randomizer.NextSingle());
            star.Velocity = new Vector3(
                x: 0f,
                y: 0f,
                z: -(.5f + 4.5f * _randomizer.NextSingle()));
            star.Color = new Rgb32f(
                r: _randomizer.NextSingle(),
                g: _randomizer.NextSingle(),
                b: _randomizer.NextSingle()
            );
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
            var screenCenterX = screenSize.Width / 2f;
            var screenCenterY = screenSize.Height / 2f;
            const int maxSubFrameCount = 20;
            for (var subFrame = 0; subFrame < maxSubFrameCount; subFrame++)
            {
                foreach (var star in _stars)
                {
                    star.Position += star.Velocity / maxSubFrameCount;

                    var screenX = star.Position.X / star.Position.Z * 100f + screenCenterX;
                    var screenY = star.Position.Y / star.Position.Z * 100f + screenCenterY;
                    if (screenX < 0f || screenX >= screenSize.Width ||
                        screenY < 0f || screenY >= screenSize.Height ||
                        star.Position.Z < 0f || star.Position.Z > 1000f)
                    {
                        ResetStar(star);
                    }

                    var starBrightness = 1f - Vector3.Distance(Vector3.Zero, star.Position) / 1000f;
                    var starDimmedColor = star.Color * starBrightness;
                    var starDrawColor = starDimmedColor.ToColor();
                    _renderer.DrawColor = starDrawColor;
                    _renderer.DrawPoint(screenX, screenY);
                }
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
