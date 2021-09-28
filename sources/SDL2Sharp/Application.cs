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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SDL2Sharp.Interop;
using SDL2TTFSharp.Interop;

namespace SDL2Sharp
{
    public abstract unsafe class Application : IDisposable
    {
        private static Application _instance = null!;

        public static Application Current => _instance;

        public IReadOnlyList<Window> Windows => WindowsInternal.AsReadOnly();

        internal List<Window> WindowsInternal { get; } = new List<Window>();

        protected Application()
        : this(Subsystem.All)
        { }

        protected Application(Subsystem subsystems)
        {
            _instance = this;
            Error.ThrowOnFailure(SDL.Init((uint)subsystems));
            Error.ThrowOnFailure(TTF.Init());
            SDL.SetEventFilter(&EventFilter, null);
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
                OnInit(arguments);

                while (true)
                {
                    SDL_Event @event;

                    while (0 != SDL.PollEvent(&@event))
                    {
                        var eventType = (SDL_EventType)@event.type;
                        switch (eventType)
                        {
                            case SDL_EventType.SDL_QUIT:
                                return;
                        }
                    }

                    OnIdle();
                }
            }
            finally
            {
                OnQuit();
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

        protected virtual void OnInit(string[] arguments) { }

        protected virtual void OnQuit() { }

        protected virtual void OnIdle() { }

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static int EventFilter(void* userdata, SDL_Event* @event)
        {
            var eventType = (SDL_EventType)@event->type;
            if (eventType == SDL_EventType.SDL_WINDOWEVENT)
            {
                var windowEventID = (SDL_WindowEventID)@event->window.@event;
                var windows = Application.Current.WindowsInternal;
                var window = windows.FirstOrDefault(w => w.Id == @event->window.windowID);
                if (window != null)
                {
                    window.ProcessEvent(@event->window);

                    return 0;
                }
            }

            return 1;
        }
    }
}
