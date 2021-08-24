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
using static SDL2Sharp.Interop.SDL;

namespace SDL2Sharp.Samples.WavePlayer
{
    internal static unsafe class Program
    {
        private static int Main(string[] args)
        {
            Subsystem subsystem = null!;
            WaveFile waveFile = null!;
            AudioDevice audioDevice = null!;
            int wavePosition = 0;

            try
            {
                subsystem = new Subsystem(SDL_INIT_AUDIO);
                waveFile = new WaveFile("Roland-GR-1-Trumpet-C5.wav");
                audioDevice = new AudioDevice(waveFile.Spec, (userdata, stream) => 
                {
                    var sliceLength = (int)Math.Min(waveFile.Length - wavePosition, stream.Length);
                    if (sliceLength <= 0)
                    {
                        return;
                    }
                    var slice = waveFile.Buffer.Slice(wavePosition, sliceLength);
                    stream.Fill(waveFile.Spec.Silence);
                    //slice.CopyTo(stream);
                    slice.MixAudioFormat(stream, waveFile.Spec.Format, SDL_MIX_MAXVOLUME);
                    wavePosition += sliceLength;
                });
                audioDevice.Unpause();
                SpinWait.SpinUntil(() => wavePosition >= waveFile.Length);
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
                audioDevice?.Dispose();
                waveFile?.Dispose();
                subsystem?.Dispose();
            }
        }
    }
}
