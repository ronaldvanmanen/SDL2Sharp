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

using System;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class Renderer : IDisposable
    {
        private SDL_Renderer* _handle;

        public RendererInfo Info
        {
            get
            {
                ThrowWhenDisposed();

                var rendererInfo = new SDL_RendererInfo();
                Error.ThrowOnFailure(
                    SDL.GetRendererInfo(_handle, &rendererInfo)
                );
                return new RendererInfo(rendererInfo);
            }
        }

        public Size OutputSize
        {
            get
            {
                ThrowWhenDisposed();

                int width, height;
                Error.ThrowOnFailure(
                    SDL.GetRendererOutputSize(_handle, &width, &height)
                );
                return new Size(width, height);
            }
        }

        public Color RenderDrawColor
        {
            get
            {
                ThrowWhenDisposed();

                byte r, g, b, a;
                Error.ThrowOnFailure(
                    SDL.GetRenderDrawColor(_handle, &r, &g, &b, &a)
                );
                return new Color(r, g, b, a);
            }
            set
            {
                ThrowWhenDisposed();

                Error.ThrowOnFailure(
                    SDL.SetRenderDrawColor(_handle, value.R, value.G, value.B, value.A)
                );
            }
        }

        public BlendMode RenderBlendMode
        {
            get
            {
                ThrowWhenDisposed();

                SDL_BlendMode blendMode;
                Error.ThrowOnFailure(
                    SDL.GetRenderDrawBlendMode(_handle, &blendMode)
                );
                return (BlendMode)blendMode;
            }
            set
            {
                ThrowWhenDisposed();

                Error.ThrowOnFailure(
                    SDL.SetRenderDrawBlendMode(_handle, (SDL_BlendMode)value)
                );
            }
        }

        public Size RenderLogicalViewSize
        {
            get
            {
                ThrowWhenDisposed();

                int width, height;
                SDL.RenderGetLogicalSize(_handle, &width, &height);
                return new Size(width, height);
            }
            set
            {
                ThrowWhenDisposed();

                Error.ThrowOnFailure(
                    SDL.RenderSetLogicalSize(_handle, value.Width, value.Height)
                );
            }
        }

        public Scale RenderScale
        {
            get
            {

                float scaleX, scaleY;
                SDL.RenderGetScale(_handle, &scaleX, &scaleY);
                return new Scale(scaleX, scaleY);
            }
            set
            {
                SDL.RenderSetScale(_handle, value.X, value.Y);
            }
        }

        public Rectangle RenderViewPort
        {
            get
            {
                ThrowWhenDisposed();

                var rect = new SDL_Rect();
                SDL.RenderGetViewport(_handle, &rect);
                return new Rectangle(rect.x, rect.y, rect.w, rect.h);
            }
            set
            {
                ThrowWhenDisposed();

                var rect = new SDL_Rect { x = value.X, y = value.Y, w = value.Width, h = value.Height };
                Error.ThrowOnFailure(
                    SDL.RenderSetViewport(_handle, &rect)
                );
            }
        }

        internal Renderer(SDL_Renderer* renderer)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            _handle = renderer;
        }

        ~Renderer()
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
            SDL.DestroyRenderer(_handle);
            _handle = null;
        }

        public Texture CreateTexture(PixelFormatEnum format, TextureAccess access, int width, int height)
        {
            ThrowWhenDisposed();

            var texture = SDL.CreateTexture(_handle, (uint)format, (int)access, width, height);
            Error.ThrowOnFailure(texture);
            return new Texture(texture);
        }

        public Texture CreateTextureFromSurface(Surface surface)
        {
            ThrowWhenDisposed();

            var texture = SDL.CreateTextureFromSurface(_handle, surface);
            Error.ThrowOnFailure(texture);
            return new Texture(texture);
        }

        public void RenderClear()
        {
            ThrowWhenDisposed();

            Error.ThrowOnFailure(
                SDL.RenderClear(_handle)
            );
        }


        public void RenderCopy(Texture texture)
        {
            ThrowWhenDisposed();

            Error.ThrowOnFailure(
                SDL.RenderCopy(_handle, texture, null, null)
            );
        }

        public void RenderCopy(Texture texture, Rectangle destination)
        {
            ThrowWhenDisposed();

            var dest = new SDL_Rect
            {
                x = destination.X,
                y = destination.Y,
                w = destination.Width,
                h = destination.Height
            };

            Error.ThrowOnFailure(
                SDL.RenderCopy(_handle, texture, null, &dest)
            );
        }

        public void RenderCopy(Texture texture, Rectangle source, Rectangle destination)
        {
            ThrowWhenDisposed();

            var src = new SDL_Rect
            {
                x = source.X,
                y = source.Y,
                w = source.Width,
                h = source.Height
            };

            var dest = new SDL_Rect
            {
                x = destination.X,
                y = destination.Y,
                w = destination.Width,
                h = destination.Height
            };

            Error.ThrowOnFailure(
                SDL.RenderCopy(_handle, texture, &src, &dest)
            );
        }

        public void RenderDrawLine(int x1, int y1, int x2, int y2)
        {
            ThrowWhenDisposed();

            Error.ThrowOnFailure(
                SDL.RenderDrawLine(_handle, x1, y1, x2, y2)
            );
        }

        public void RenderDrawLines(Point[] points)
        {
            fixed (Point* point = &points[0])
            {
                Error.ThrowOnFailure(
                    SDL.RenderDrawLines(_handle, (SDL_Point*)point, points.Length)
                );
            }
        }

        public void RenderDrawPoint(int x, int y)
        {
            ThrowWhenDisposed();

            Error.ThrowOnFailure(
                SDL.RenderDrawPoint(_handle, x, y)
            );
        }

        public void RenderFillRect(int x, int y, int width, int height)
        {
            var rect = new SDL_Rect { x = x, y = y, w = width, h = height };
            Error.ThrowOnFailure(
                SDL.RenderFillRect(_handle, &rect)
            );
        }

        public void RenderFillRect(Rectangle rectangle)
        {
            RenderFillRect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public void RenderPresent()
        {
            ThrowWhenDisposed();

            SDL.RenderPresent(_handle);
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
