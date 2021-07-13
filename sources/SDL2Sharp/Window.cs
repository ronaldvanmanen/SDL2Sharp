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
using SDL2Sharp.Internals;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public unsafe sealed class Window : IDisposable
    {
        private SDL_Window* _window;

        public Window(string title, int width, int height)
        : this(title, (int)SDL.SDL_WINDOWPOS_UNDEFINED, (int)SDL.SDL_WINDOWPOS_UNDEFINED, width, height, (uint)0)
        { }

        public Window(string title, int width, int height, SDL_WindowFlags flags)
        : this(title, (int)SDL.SDL_WINDOWPOS_UNDEFINED, (int)SDL.SDL_WINDOWPOS_UNDEFINED, width, height, (uint)flags)
        { }

        public Window(string title, int x, int y, int width, int height)
        : this(title, x, y, width, height, (uint)0)
        { }

        public Window(string title, int x, int y, int width, int height, SDL_WindowFlags flags)
        : this(title, x, y, width, height, (uint)flags)
        { }

        private Window(string title, int x, int y, int width, int height, uint flags)
        {
            using (var marshaledTitle = new MarshaledString(title))
            {
                _window = Error.ReturnOrThrowOnFailure(
                    SDL.CreateWindow(marshaledTitle, x, y, width, height, flags)
                );
            }
        }

        public void Dispose()
        {
            if (_window == null) return;
            SDL.DestroyWindow(_window);
            _window = null;
        }

        public Renderer CreateRenderer()
        {
            return CreateRenderer((uint)0);
        }

        public Renderer CreateRenderer(SDL_RendererFlags flags)
        {
            return CreateRenderer((uint)flags);
        }

        private Renderer CreateRenderer(uint flags)
        {
            var renderer = SDL.CreateRenderer(_window, -1, flags);
            Error.ThrowOnFailure(renderer);
            return new Renderer(renderer);
        }
    }
}
