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
using SDL2Sharp.Extensions;
using SDL2Sharp.Interop;

namespace WavePlayer
{
    internal sealed class App : Application
    {
        private static readonly Font _frameRateFont = new("lazy.ttf", 28);

        private static readonly Color _frameRateColor = new(255, 255, 255, 255);

        private static readonly Color _backgroundColor = new(0, 0, 0, 255);

        private static readonly Color _waveColor = new(255, 255, 0, 255);

        private static readonly Color _channelSeparatorColor = new(0, 0, 255, 255);

        private Window _window = null!;

        private Thread _renderingThread = null!;

        private volatile bool _rendererInvalidated = false;

        private volatile bool _rendering = false;

        private WaveFile _waveFile = null!;

        private AudioDevice _audioDevice = null!;

        private int _wavePosition = 0;

        protected override void OnInitialized()
        {
            Environment.SetEnvironmentVariable("SDL_AUDIODRIVER", "directsound");

            try
            {
                _window = new Window("Wave Player", 640, 480, WindowFlags.Shown | WindowFlags.Resizable);
                _window.SizeChanged += OnWindowSizeChanged;
                _renderingThread = new Thread(Render);
                _rendererInvalidated = true;
                _rendering = true;
                _waveFile = new WaveFile(Environment.GetCommandLineArgs()[1]);
                _audioDevice = new AudioDevice(
                    _waveFile.Frequency,
                    _waveFile.Format,
                    _waveFile.Channels,
                    _waveFile.Samples,
                    OnAudioDeviceCallback,
                    null!,
                    AudioDeviceAllowedChanges.None);
                _renderingThread.Start();
                _audioDevice.Unpause();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Could not run sample: {e.Message}");
                Quit(1);
            }
        }

        protected override void OnQuiting()
        {
            _audioDevice?.Pause();
            _rendererInvalidated = false;
            _rendering = false;
            _renderingThread?.SafeJoin();
            _audioDevice?.Dispose();
            _waveFile?.Dispose();
            _window?.Dispose();
        }

        private void OnAudioDeviceCallback(object userdata, Span<byte> stream)
        {
            stream.Fill(_waveFile.Silence);
            var sliceLength = (int)Math.Min(_waveFile.Length - _wavePosition, stream.Length);
            if (sliceLength <= 0)
            {
                return;
            }
            var slice = _waveFile.Buffer.Slice(_wavePosition, sliceLength);
            stream.MixAudioFormat(slice, _waveFile.Format, SDL.SDL_MIX_MAXVOLUME);
            _wavePosition += sliceLength;
        }

        private void OnWindowSizeChanged(object? sender, WindowSizeChangedEventArgs e)
        {
            _rendererInvalidated = true;
        }

        private void Render()
        {
            Renderer renderer = null!;
            var frameRateUpdatedTime = DateTime.Now;
            var frameRateUpdateInterval = TimeSpan.FromMilliseconds(500d);
            var frameRate = 0d;
            var frameRateText = $"FPS: {frameRate:0.00}";
            var frameCounter = 0;
            var channelCount = (int)_waveFile.Channels;
            var waves = new Point[channelCount][];
            var sampleFormat = _waveFile.Format;
            var sampleSize = sampleFormat.BitSize() / 8;

            try
            {
                while (_rendering)
                {
                    if (_rendererInvalidated)
                    {
                        renderer?.Dispose();
                        renderer = _window.CreateRenderer(RendererFlags.Accelerated/* | RendererFlags.PresentVSync*/);
                        for (var channel = 0; channel < channelCount; ++channel)
                        {
                            waves[channel] = new Point[renderer.OutputSize.Width];
                        };
                        _rendererInvalidated = false;
                    }

                    renderer.DrawColor = _backgroundColor;

                    renderer.Clear();

                    var currentTime = DateTime.Now;
                    var elapsedTime = currentTime - frameRateUpdatedTime;
                    if (elapsedTime > frameRateUpdateInterval)
                    {
                        frameRate = frameCounter / elapsedTime.TotalSeconds;
                        frameRateText = $"FPS: {frameRate:0.00}";
                        frameRateUpdatedTime = currentTime;
                        frameCounter = 0;
                    }

                    renderer.DrawColor = _frameRateColor;

                    renderer.DrawTextBlended(8, 8, _frameRateFont, frameRateText);

                    renderer.DrawColor = _waveColor;

                    var channelHeight = renderer.OutputSize.Height / channelCount;
                    var halfGraphHeight = channelHeight * 9 / 20;
                    for (var channel = 0; channel < channelCount; ++channel)
                    {
                        var centerLine = channel * channelHeight + channelHeight / 2;
                        var sampleOffset = _wavePosition + sampleSize * channel;
                        for (var x = 0; x < renderer.OutputSize.Width; ++x)
                        {
                            var y = centerLine;

                            if (sampleOffset < _waveFile.Buffer.Length)
                            {
                                var normalizedSample = _waveFile.Buffer.ToNormalizedSingle(sampleOffset, sampleFormat);
                                y = (int)(centerLine + normalizedSample * halfGraphHeight);
                            }

                            waves[channel][x] = new Point(x, y);

                            sampleOffset += sampleSize * channelCount;
                        }

                        renderer.DrawLines(waves[channel]);
                    }

                    renderer.DrawColor = _channelSeparatorColor;

                    for (var channel = 0; channel <= channelCount; ++channel)
                    {
                        var y = channel * channelHeight;
                        renderer.DrawLine(0, y, renderer.OutputSize.Width, y);
                    }

                    renderer.Present();

                    frameCounter++;
                }
            }
            finally
            {
                renderer?.Dispose();
            }
        }

        private static int Main()
        {
            var app = new App();
            var exitCode = app.Run();
            return exitCode;
        }
    }
}
