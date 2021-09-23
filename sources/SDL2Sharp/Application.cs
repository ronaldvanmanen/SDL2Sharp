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
using SDL2TTFSharp.Interop;

namespace SDL2Sharp
{
    public abstract unsafe class Application : IDisposable
    {
        protected Application()
        : this(Subsystem.All)
        { }

        protected Application(Subsystem subsystems)
        {
            Error.ThrowOnFailure(SDL.Init((uint)subsystems));
            Error.ThrowOnFailure(TTF.Init());
        }

        ~Application()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool _)
        {
            TTF.Quit();
            SDL.Quit();
        }

        public void Run(string[] arguments)
        {
            try
            {
                OnStartup(arguments);

                var running = true;

                while (running)
                {
                    SDL_Event e;

                    while (0 != SDL.PollEvent(&e))
                    {
                        var eventType = (SDL_EventType)e.type;
                        if (eventType == SDL_EventType.SDL_QUIT)
                        {
                            running = false;
                            break;
                        }

                        switch (eventType)
                        {
                            case SDL_EventType.SDL_WINDOWEVENT:
                                DispatchEvent(e.window);
                                break;
                        }
                    }

                    OnIdle();
                }
            }
            finally
            {
                OnShutdown();
            }
        }

        public void Quit()
        {
            var @event = new SDL_Event
            {
                type = (uint)SDL_EventType.SDL_QUIT
            };
            Error.ThrowOnFailure(SDL.PushEvent(&@event));
        }

        protected virtual void OnStartup(string[] arguments) { }

        protected virtual void OnShutdown() { }

        protected virtual void OnIdle() { }

        private static void DispatchEvent(SDL_WindowEvent windowEvent)
        {
            if (Window.TryGetWindowFromID(windowEvent.windowID, out var window))
            {
                window.ProcessEvent(windowEvent);
            }
        }
    }
}
