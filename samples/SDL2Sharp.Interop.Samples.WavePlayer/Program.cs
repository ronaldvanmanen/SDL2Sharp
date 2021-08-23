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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SDL2Sharp.Interop.Samples.WavePlayer
{
    internal static unsafe class Program
    {
        private static byte* _audioPosition;
        
        private static uint _audioLength;

        private static ushort _audioFormat;

        private static byte _audioSilence;

        private static int Main(string[] args)
        {
            if (SDL.Init(SDL.SDL_INIT_AUDIO) != 0)
            {
                SDL.Log($"Unable to initialize SDL: {SDL.GetErrorString()}");
                return 1;
            }

            fixed (byte* file = &Encoding.ASCII.GetBytes("Roland-GR-1-Trumpet-C5.wav")[0])
            fixed (byte* mode = &Encoding.ASCII.GetBytes("rb")[0])
            {
                SDL_AudioSpec wavSpec;
                uint wavLength;
                byte* wavBuffer;

                if (SDL.LoadWAV_RW(SDL.RWFromFile((sbyte*)file, (sbyte*)mode), 1, &wavSpec, &wavBuffer, &wavLength) == null)
                {
                    SDL.Log($"Unable to load WAV: {SDL.GetErrorString()}");
                    return 1;
                }

                wavSpec.callback = &UnmanagedCallback;
                wavSpec.userdata = null;

                SDL_AudioSpec obtainedSpec;
                uint deviceID = SDL.OpenAudioDevice(null, 0, &wavSpec, &obtainedSpec, 0);
                if (deviceID == 0)
                {
                    SDL.Log($"Unable to initialize SDL: {SDL.GetErrorString()}");
                    return 1;
                }

                Console.WriteLine("WAV information:");
                Console.WriteLine();
                Console.WriteLine("Frequency (samples per second):    {0} ({1})", obtainedSpec.freq, wavSpec.freq);
                Console.WriteLine("Audio data format:                 {0} ({1})", obtainedSpec.format, wavSpec.format);
                Console.WriteLine("Number of separate sound channels: {0} ({1})", obtainedSpec.channels, wavSpec.channels);
                Console.WriteLine("Audio buffer silence:              {0} ({1})", obtainedSpec.silence, wavSpec.silence);
                Console.WriteLine("Audio buffer size in samples:      {0} ({1})", obtainedSpec.samples, wavSpec.samples);
                Console.WriteLine("Audio buffer size in bytes:        {0} ({1})", obtainedSpec.size, wavSpec.size);
                Console.WriteLine();
                Console.WriteLine("File size: {0}", wavLength);

                _audioPosition = wavBuffer;
                _audioLength = wavLength;
                _audioFormat = obtainedSpec.format;
                _audioSilence = obtainedSpec.silence;

                SDL.PauseAudioDevice(deviceID, 0);
                SpinWait.SpinUntil(() => _audioLength <= 0);
                SDL.CloseAudioDevice(deviceID);
                SDL.Quit();
            }
            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static void UnmanagedCallback(void* userdata, byte* stream, int len)
        {
            if (_audioLength == 0)
            {
                return;
            }

            SDL.memset(stream, _audioSilence, (nuint)len);
            uint audioLength = len > _audioLength ? _audioLength : (uint)len;
            SDL.MixAudioFormat(stream, _audioPosition, _audioFormat, audioLength, SDL.SDL_MIX_MAXVOLUME);
            _audioPosition += audioLength;
            _audioLength -= audioLength;
        }
    }
}
