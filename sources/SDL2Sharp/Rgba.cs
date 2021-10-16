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

using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct Rgba
    {
        private byte _a;

        private byte _b;

        private byte _g;

        private byte _r;

        public byte A { get => _a; set => _a = value; }

        public byte B { get => _b; set => _b = value; }

        public byte G { get => _g; set => _g = value; }

        public byte R { get => _r; set => _r = value; }

        public Rgba(byte r, byte g, byte b, byte a)
        : this()
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
