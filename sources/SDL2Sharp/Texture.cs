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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Toolkit.HighPerformance;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class Texture : IDisposable
    {
        private SDL_Texture* _handle;

        public PixelFormatEnum Format
        {
            get
            {
                uint format;
                Error.ThrowOnFailure(SDL.QueryTexture(_handle, &format, null, null, null));
                return (PixelFormatEnum)format;
            }
        }

        public TextureAccess Access
        {
            get
            {
                int access;
                Error.ThrowOnFailure(SDL.QueryTexture(_handle, null, &access, null, null));
                return (TextureAccess)access;
            }
        }

        public int Width
        {
            get
            {
                int width;
                Error.ThrowOnFailure(SDL.QueryTexture(_handle, null, null, &width, null));
                return width;
            }
        }

        public int Height
        {
            get
            {
                int height;
                Error.ThrowOnFailure(SDL.QueryTexture(_handle, null, null, null, &height));
                return height;
            }
        }

        public BlendMode BlendMode
        {
            get
            {
                SDL_BlendMode blendMode;
                Error.ThrowOnFailure(
                    SDL.GetTextureBlendMode(_handle, &blendMode)
                );
                return (BlendMode)blendMode;
            }
            set
            {
                Error.ThrowOnFailure(
                    SDL.SetTextureBlendMode(_handle, (SDL_BlendMode)value)
                );
            }
        }

        public bool IsValid => 0 == SDL.QueryTexture(_handle, null, null, null, null);

        internal Texture(SDL_Texture* texture)
        {
            if (texture is null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            _handle = texture;
        }

        ~Texture()
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
            if (_handle is null) return;
            SDL.DestroyTexture(_handle);
            _handle = null;
        }

        public Span2D<byte> Lock()
        {
            return Lock(0, 0, Width, Height);
        }

        public Span2D<byte> Lock(Rectangle rectangle)
        {
            return Lock(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public Span2D<byte> Lock(int x, int y, int width, int height)
        {
            ThrowWhenDisposed();

            var rect = new SDL_Rect { x = x, y = y, w = width, h = height };
            void* pixels;
            int pitch;
            Error.ThrowOnFailure(
                SDL.LockTexture(_handle, &rect, &pixels, &pitch)
            );

            // In SDL pitch is synonymous to stride, and is defined as the
            // length of a row of pixels in bytes. Span2D, however, defines
            // pitch as the difference between stride and width.
            var bytesPerPixel = Format.GetBytesPerPixel();
            var bytes = new Span2D<byte>(pixels, height, width, (int)(pitch - width * bytesPerPixel));
            return bytes;
        }

        public Surface LockToSurface()
        {
            ThrowWhenDisposed();

            SDL_Surface* surfaceHandle;
            Error.ThrowOnFailure(
                SDL.LockTextureToSurface(_handle, null, &surfaceHandle)
            );
            return new Surface(surfaceHandle, false);
        }

        public Surface LockToSurface(Rectangle rectangle)
        {
            return LockToSurface(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public Surface LockToSurface(int x, int y, int width, int height)
        {
            ThrowWhenDisposed();

            var rect = new SDL_Rect { x = x, y = y, w = width, h = height };
            SDL_Surface* surfaceHandle;
            Error.ThrowOnFailure(
                SDL.LockTextureToSurface(_handle, &rect, &surfaceHandle)
            );
            return new Surface(surfaceHandle, false);
        }

        public void Update<TPixelFormat>(Image<TPixelFormat> image) where TPixelFormat : struct
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref image.DangerousGetReference());
            var pitch = image.Width * Marshal.SizeOf<TPixelFormat>();
            Update(null, pointer, pitch);
        }

        public void Update<TPixelFormat>(Span2D<TPixelFormat> pixels) where TPixelFormat : struct
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var pitch = pixels.Width * Marshal.SizeOf<TPixelFormat>();
            Update(null, pointer, pitch);
        }

        public void Update<TPixelFormat>(TPixelFormat[,] pixels, int width) where TPixelFormat : struct
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var pitch = width * Marshal.SizeOf<TPixelFormat>();
            Update(null, pointer, pitch);
        }

        public void Update<TPixelFormat>(TPixelFormat[] pixels, int width) where TPixelFormat : struct
        {
            ThrowWhenDisposed();

            var pointer = Unsafe.AsPointer(ref pixels.DangerousGetReference());
            var pitch = width * Marshal.SizeOf<TPixelFormat>();
            Update(null, pointer, pitch);
        }

        private void Update(SDL_Rect* rect, void* pixels, int pitch)
        {
            Error.ThrowOnFailure(
                SDL.UpdateTexture(_handle, rect, pixels, pitch)
            );
        }

        public void UpdateYUV(Span2D<byte> yPixels, Span2D<byte> uPixels, Span2D<byte> vPixels)
        {
            ThrowWhenDisposed();

            var yPlane = (byte*)Unsafe.AsPointer(ref yPixels.DangerousGetReference());
            var yPitch = yPixels.Width * sizeof(byte);
            var uPlane = (byte*)Unsafe.AsPointer(ref uPixels.DangerousGetReference());
            var uPitch = uPixels.Width * sizeof(byte);
            var vPlane = (byte*)Unsafe.AsPointer(ref vPixels.DangerousGetReference());
            var vPitch = vPixels.Width * sizeof(byte);

            UpdateYUV(null, yPlane, yPitch, uPlane, uPitch, vPlane, vPitch);
        }

        private void UpdateYUV(SDL_Rect* rect, byte* yPlane, int yPitch, byte* uPlane, int uPitch, byte* vPlane, int vPitch)
        {
            Error.ThrowOnFailure(
                SDL.UpdateYUVTexture(_handle, rect, yPlane, yPitch, uPlane, uPitch, vPlane, vPitch)
            );
        }

        public void Unlock()
        {
            ThrowWhenDisposed();

            SDL.UnlockTexture(_handle);
        }

        public static implicit operator SDL_Texture*(Texture texture)
        {
            if (texture is null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            return texture._handle;
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
