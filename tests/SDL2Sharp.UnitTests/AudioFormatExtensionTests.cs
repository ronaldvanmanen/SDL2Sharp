﻿// SDL2Sharp
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

using SDL2Sharp.Extensions;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    public static class AudioFormatExtensionTests
    {
        [Fact]
        public static void BitSizeTest()
        {
            Assert.Equal(32, AudioFormat.AUDIO_F32.BitSize());
            Assert.Equal(32, AudioFormat.AUDIO_F32LSB.BitSize());
            Assert.Equal(32, AudioFormat.AUDIO_F32MSB.BitSize());
            Assert.Equal(32, AudioFormat.AUDIO_F32SYS.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_S16.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_S16LSB.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_S16MSB.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_S16SYS.BitSize());
            Assert.Equal(32, AudioFormat.AUDIO_S32.BitSize());
            Assert.Equal(32, AudioFormat.AUDIO_S32LSB.BitSize());
            Assert.Equal(32, AudioFormat.AUDIO_S32MSB.BitSize());
            Assert.Equal(32, AudioFormat.AUDIO_S32SYS.BitSize());
            Assert.Equal(8, AudioFormat.AUDIO_S8.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_U16.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_U16LSB.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_U16MSB.BitSize());
            Assert.Equal(16, AudioFormat.AUDIO_U16SYS.BitSize());
            Assert.Equal(8, AudioFormat.AUDIO_U8.BitSize());
        }
    }
}
