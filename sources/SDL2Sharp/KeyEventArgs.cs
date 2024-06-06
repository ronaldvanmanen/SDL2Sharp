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

namespace SDL2Sharp
{
    public sealed class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(Scancode scanCode, KeyCode keyCode, KeyModifiers modifiers, int repeat)
        {
            ScanCode = scanCode;
            KeyCode = keyCode;
            Modifiers = modifiers;
            Repeat = repeat;
        }

        public Scancode ScanCode { get; }

        public KeyCode KeyCode { get; }

        public KeyModifiers Modifiers { get; }

        public bool Alt => Modifiers.HasFlag(KeyModifiers.LeftAlt) || Modifiers.HasFlag(KeyModifiers.RightAlt);

        public bool Ctrl => Modifiers.HasFlag(KeyModifiers.LeftCtrl) || Modifiers.HasFlag(KeyModifiers.RightCtrl);

        public bool Shift => Modifiers.HasFlag(KeyModifiers.LeftShift) || Modifiers.HasFlag(KeyModifiers.RightShift);

        public int Repeat { get; }
    }
}
