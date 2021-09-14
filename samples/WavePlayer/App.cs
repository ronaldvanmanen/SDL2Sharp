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
using SDL2Sharp;
using SDL2Sharp.Interop;

namespace WavePlayer
{
    internal sealed unsafe class App : Application
    {
        private WaveFile _waveFile = null!;

        private AudioDevice _audioDevice = null!;

        private int _wavePosition = 0;

        public App()
        : base(Subsystem.Audio)
        { }

        protected override void OnStartup(string[] args)
        {
            _waveFile = new WaveFile(args[0]);
            _audioDevice = new AudioDevice(_waveFile.Spec, OnAudioDeviceCallback);
            _audioDevice.Unpause();
        }

        protected override void OnShutdown()
        {
            _audioDevice?.Dispose();
            _waveFile?.Dispose();
        }

        protected override void OnIdle()
        {
            if (_wavePosition >= _waveFile.Length)
            {
                Quit();
            }
        }

        private void OnAudioDeviceCallback(object userdata, Span<byte> stream)
        {
            var sliceLength = (int)Math.Min(_waveFile.Length - _wavePosition, stream.Length);
            if (sliceLength <= 0)
            {
                return;
            }
            var slice = _waveFile.Buffer.Slice(_wavePosition, sliceLength);
            stream.Fill(_waveFile.Spec.Silence);
            //slice.CopyTo(stream);
            slice.MixAudioFormat(stream, _waveFile.Spec.Format, SDL.SDL_MIX_MAXVOLUME);
            _wavePosition += sliceLength;
        }

        private static int Main(string[] args)
        {
            App application = null!;

            try
            {
                application = new App();
                application.Run(args);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not run sample: {0}", e.Message);
                Console.WriteLine();
                return 1;
            }
            finally
            {
                application?.Dispose();
            }
        }
    }
}
