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

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Toolkit.HighPerformance;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class PackedTexture<TPackedColor> : Texture where TPackedColor : struct
    {
        internal PackedTexture(SDL_Texture* texture)
        : base(texture)
        { }

        public void WithLock(WithLockPackedImageCallback<TPackedColor> callback)
        {
            WithLock(0, 0, Width, Height, callback);
        }

        public void WithLock(Rectangle rectangle, WithLockPackedImageCallback<TPackedColor> callback)
        {
            WithLock(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, callback);
        }

        public void WithLock(int x, int y, int width, int height, WithLockPackedImageCallback<TPackedColor> callback)
        {
            ThrowWhenDisposed();

            var rect = new SDL_Rect { x = x, y = y, w = width, h = height };
            void* pixels;
            int pitchInBytes;
            Error.ThrowOnFailure(
                SDL.LockTexture(this, &rect, &pixels, &pitchInBytes)
            );

            var bytesPerPixel = Marshal.SizeOf<TPackedColor>();
            var pitch = pitchInBytes / bytesPerPixel;
            var image = new PackedImage<TPackedColor>(pixels, height, width, pitch);
            callback(image);
            SDL.UnlockTexture(this);
        }

        public void WithLock(WithLockSurfaceCallback<TPackedColor> callback)
        {
            WithLock(0, 0, Width, Height, callback);
        }

        public void WithLock(Rectangle rectangle, WithLockSurfaceCallback<TPackedColor> callback)
        {
            WithLock(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, callback);
        }

        public void WithLock(int x, int y, int width, int height, WithLockSurfaceCallback<TPackedColor> callback)
        {
            ThrowWhenDisposed();

            var rect = new SDL_Rect { x = x, y = y, w = width, h = height };
            SDL_Surface* surfaceHandle;
            Error.ThrowOnFailure(
                SDL.LockTextureToSurface(this, &rect, &surfaceHandle)
            );
            var surface = new Surface<TPackedColor>(surfaceHandle, false);
            callback.Invoke(surface);
            SDL.UnlockTexture(this);
        }

        public void Update(PackedMemoryImage<TPackedColor> image)
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref image.DangerousGetReference());
            var pitch = image.Width * Marshal.SizeOf<TPackedColor>();
            Update(null, pointer, pitch);
        }

        public void Update(PackedImage<TPackedColor> pixels)
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var pitch = pixels.Width * Marshal.SizeOf<TPackedColor>();
            Update(null, pointer, pitch);
        }

        public void Update(Span2D<TPackedColor> pixels)
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var pitch = pixels.Width * Marshal.SizeOf<TPackedColor>();
            Update(null, pointer, pitch);
        }

        public void Update(TPackedColor[,] pixels)
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var width = pixels.GetLength(1);
            var pitch = width * Marshal.SizeOf<TPackedColor>();
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
