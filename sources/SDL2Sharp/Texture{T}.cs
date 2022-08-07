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

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Toolkit.HighPerformance;
using SDL2Sharp.Interop;
using SDL2Sharp.Extensions;

namespace SDL2Sharp
{
    public sealed unsafe class Texture<TPixelFormat> : Texture where TPixelFormat : struct
    {
        internal Texture(SDL_Texture* texture)
        : base(texture)
        { }

        public Span2D<TPixelFormat> Lock()
        {
            return Lock(0, 0, Width, Height);
        }

        public Span2D<TPixelFormat> Lock(Rectangle rectangle)
        {
            return Lock(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public Span2D<TPixelFormat> Lock(int x, int y, int width, int height)
        {
            ThrowWhenDisposed();

            var rect = new SDL_Rect { x = x, y = y, w = width, h = height };
            void* pixels;
            int pitch;
            Error.ThrowOnFailure(
                SDL.LockTexture(this, &rect, &pixels, &pitch)
            );

            // In SDL pitch is synonymous to stride, and is defined as the
            // length of a row of pixels in bytes. Span2D, however, defines
            // pitch as the difference between stride and width.
            var bytesPerPixel = Format.GetBytesPerPixel();
            var bytes = new Span2D<TPixelFormat>(pixels, height, width, (int)(pitch - width * bytesPerPixel));
            return bytes;
        }

        public new Surface<TPixelFormat> LockToSurface()
        {
            ThrowWhenDisposed();

            SDL_Surface* surfaceHandle;
            Error.ThrowOnFailure(
                SDL.LockTextureToSurface(this, null, &surfaceHandle)
            );
            return new Surface<TPixelFormat>(surfaceHandle, false);
        }

        public new Surface<TPixelFormat> LockToSurface(Rectangle rectangle)
        {
            return LockToSurface(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public new Surface<TPixelFormat> LockToSurface(int x, int y, int width, int height)
        {
            ThrowWhenDisposed();

            var rect = new SDL_Rect { x = x, y = y, w = width, h = height };
            SDL_Surface* surfaceHandle;
            Error.ThrowOnFailure(
                SDL.LockTextureToSurface(this, &rect, &surfaceHandle)
            );
            return new Surface<TPixelFormat>(surfaceHandle, false);
        }

        public void Unlock()
        {
            ThrowWhenDisposed();

            SDL.UnlockTexture(this);
        }

        public void Update(Image<TPixelFormat> image)
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref image.DangerousGetReference());
            var pitch = image.Width * Marshal.SizeOf<TPixelFormat>();
            Update(null, pointer, pitch);
        }

        public void Update(Span2D<TPixelFormat> pixels)
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var pitch = pixels.Width * Marshal.SizeOf<TPixelFormat>();
            Update(null, pointer, pitch);
        }

        public void Update(TPixelFormat[,] pixels)
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var width = pixels.GetLength(1);
            var pitch = width * Marshal.SizeOf<TPixelFormat>();
            Update(null, pointer, pitch);
        }

        private void Update(SDL_Rect* rect, void* pixels, int pitch)
        {
            Error.ThrowOnFailure(
                SDL.UpdateTexture(this, rect, pixels, pitch)
            );
        }
    }
}
