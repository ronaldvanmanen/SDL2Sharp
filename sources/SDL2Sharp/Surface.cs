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
using Microsoft.Toolkit.HighPerformance;
using SDL2Sharp.Internals;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class Surface : IDisposable
    {
        private SDL_Surface* _handle;

        private readonly bool _freeHandle;

        public PixelFormat Format => new PixelFormat(_handle->format);

        public int Width => _handle->w;

        public int Height => _handle->h;

        public int Pitch => _handle->pitch;

        public Span2D<byte> Pixels
        {
            get
            {
                // In SDL pitch is synonymous to stride, and is defined as the
                // length of a row of pixels in bytes. Span2D, however, defines
                // pitch as the difference between stride and width in pixels.
                return new Span2D<byte>(_handle->pixels, _handle->h, _handle->w,
                    _handle->pitch - _handle->w * _handle->format->BytesPerPixel);
            }
        }

        public bool MustLock => ((_handle->flags & SDL.SDL_RLEACCEL) != 0);

        public static Surface LoadBitmap(string filename)
        {
            using (var file = new MarshaledString(filename))
            using (var mode = new MarshaledString("rb"))
            {
                var source = SDL.RWFromFile(file, mode);
                Error.ThrowOnFailure(source);
                var bitmap = SDL.LoadBMP_RW(source, 1);
                Error.ThrowOnFailure(bitmap);
                return new Surface(bitmap);
            }
        }

        public Surface(SDL_Surface* handle)
        : this(handle, true)
        { }

        public Surface(SDL_Surface* handle, bool freeHandle)
        {
            if (handle is null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _freeHandle = freeHandle;
        }

        public Surface(int width, int height, int depth, PixelFormatEnum format)
        : this(SDL.CreateRGBSurfaceWithFormat(0, width, height, depth, (uint)format))
        { }

        public Surface(int width, int height, int depth, uint redMask, uint greenMask, uint blueMask, uint alphaMask)
        : this(SDL.CreateRGBSurface(0, width, height, depth, redMask, greenMask, blueMask, alphaMask))
        { }

        public Surface(void* pixels, int width, int height, int depth, int pitch, PixelFormatEnum format)
        : this(SDL.CreateRGBSurfaceWithFormatFrom(pixels, width, height, depth, pitch, (uint)format))
        { }

        public Surface(void* pixels, int width, int height, int depth, int pitch, uint redMask, uint greenMask, uint blueMask, uint alphaMask)
        : this(SDL.CreateRGBSurfaceFrom(pixels, width, height, depth, pitch, redMask, greenMask, blueMask, alphaMask))
        { }

        ~Surface()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool _)
        {
            if (_handle is null)
            {
                return;
            }

            if (_freeHandle)
            {
                SDL.FreeSurface(_handle);
            }

            _handle = null;
        }

        public void Blit(Surface surface)
        {
            ThrowWhenDisposed();

            if (surface is null)
            {
                throw new ArgumentNullException(nameof(surface));
            }

            Error.ThrowOnFailure(
                SDL.Blit(_handle, null, surface._handle, null)
            );
        }

        public Surface Convert(PixelFormatEnum format)
        {
            ThrowWhenDisposed();

            return new Surface(SDL.ConvertSurfaceFormat(_handle, (uint)format, 0));
        }

        public void FillRect(uint color)
        {
            ThrowWhenDisposed();

            Error.ThrowOnFailure(
                SDL.FillRect(_handle, null, color)
            );
        }

        public void Lock()
        {
            ThrowWhenDisposed();

            Error.ThrowOnFailure(
                SDL.LockSurface(_handle)
            );
        }

        public void Unlock()
        {
            ThrowWhenDisposed();

            SDL.UnlockSurface(_handle);
        }

        private void ThrowWhenDisposed()
        {
            if (_handle is null)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        public static implicit operator SDL_Surface*(Surface surface)
        {
            if (surface is null)
            {
                throw new ArgumentNullException(nameof(surface));
            }

            return surface._handle;
        }
    }
}
