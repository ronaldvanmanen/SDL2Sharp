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

using System;
using SDL2Sharp.Internals;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class Font : IDisposable
    {
        private _TTF_Font* _handle;

        public Font(string path, int pointSize)
        {
            using (var marshaledPath = new MarshaledString(path))
            {
                _handle = TTF.OpenFont(marshaledPath, pointSize);
            }
        }

        ~Font()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool _)
        {
            if (_handle is null) return;
            TTF.CloseFont(_handle);
            _handle = null;
        }

        public Surface RenderSolid(string text, Color color)
        {
            ThrowWhenDisposed();

            using (var marshaledText = new MarshaledString(text))
            {
                return new Surface(TTF.RenderText_Solid(_handle, marshaledText, color));
            }
        }

        public Surface RenderBlended(string text, Color color)
        {
            ThrowWhenDisposed();

            using (var marshaledText = new MarshaledString(text))
            {
                return new Surface(TTF.RenderText_Blended(_handle, marshaledText, color));
            }
        }

        public static implicit operator _TTF_Font*(Font font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }

            return font._handle;
        }

        private void ThrowWhenDisposed()
        {
            if (_handle is null)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
