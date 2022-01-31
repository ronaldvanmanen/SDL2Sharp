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

using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class AudioDeviceSpec
    {
        public AudioDeviceSpec(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples)
        {
            Frequency = frequency;
            Format = format;
            Channels = channels;
            Silence = 0;
            Samples = samples;
            Padding = 0;
            Size = 0;
        }

        public AudioDeviceSpec(SDL_AudioSpec audioSpec)
        {
            Frequency = audioSpec.freq;
            Format = (AudioFormat)audioSpec.format;
            Channels = (AudioChannelLayout)audioSpec.channels;
            Silence = audioSpec.silence;
            Samples = audioSpec.samples;
            Padding = audioSpec.padding;
            Size = audioSpec.size;
        }

        public int Frequency { get; set; }

        public AudioFormat Format { get; set; }

        public AudioChannelLayout Channels { get; set; }

        public byte Silence { get; private set; }

        public ushort Samples { get; set; }

        public ushort Padding { get; set; }

        public uint Size { get; private set; }
    }
}
