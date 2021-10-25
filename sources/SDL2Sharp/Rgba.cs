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

using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public readonly struct Rgba
    {
        private readonly byte _a;

        private readonly byte _b;

        private readonly byte _g;

        private readonly byte _r;

        public byte R => _r;

        public byte G => _g;

        public byte B => _b;

        public byte A => _a;

        public Rgba(byte r, byte g, byte b, byte a)
        {
            _a = a;
            _b = b;
            _g = g;
            _r = r;
        }
    }
}
