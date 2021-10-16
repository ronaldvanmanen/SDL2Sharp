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
    public abstract unsafe class Application
    {
        private static Application _instance = null!;

        public static Application Current => _instance;

        public Subsystems Subsystems { get; set; } = Subsystems.All;

        public IReadOnlyList<Window> Windows => WindowsInternal.AsReadOnly();

        internal List<Window> WindowsInternal { get; } = new List<Window>();

        private int _exitCode;

        protected Application()
        {
            if (_instance != null)
            {
                throw new InvalidOperationException();
            }

            _instance = this;
            _exitCode = 0;
        }

        public int Run(string[] arguments)
        {
            try
            {
                OnInitializing(arguments);
                DoInitialize();
                OnInitialized(arguments);

                while (true)
                {
                    SDL_Event @event;

                    while (0 != SDL.PollEvent(&@event))
                    {
                        var eventType = (SDL_EventType)@event.type;
                        switch (eventType)
                        {
                            case SDL_EventType.SDL_QUIT:
                                return _exitCode;

                            case SDL_EventType.SDL_MOUSEMOTION:
                                Dispatch(@event.motion);
                                break;

                            case SDL_EventType.SDL_WINDOWEVENT:
                                Dispatch(@event.window);
                                break;
                        }
                    }

                    OnIdle();
                }
            }
            finally
            {
                OnQuiting(_exitCode);
                DoQuit();
                OnQuited(_exitCode);
            }
        }

        public void Quit()
        {
            Quit(0);
        }

        public void Quit(int exitCode)
        {
            _exitCode = exitCode;
            var @event = new SDL_Event { type = (uint)SDL_EventType.SDL_QUIT };
            Error.ThrowOnFailure(SDL.PushEvent(&@event));
        }

        protected virtual void OnInitializing(string[] args) { }

        private void DoInitialize()
        {
            Error.ThrowOnFailure(SDL.Init((uint)Subsystems));
            Error.ThrowOnFailure(TTF.Init());
            SDL.SetEventFilter(&EventFilter, null);
        }

        protected virtual void OnInitialized(string[] args) { }

        protected virtual void OnQuiting(int exitCode) { }

        private void DoQuit()
        {
            SDL.SetEventFilter(null, null);
            TTF.Quit();
            SDL.Quit();
        }

        protected virtual void OnQuited(int exitCode) { }

        protected virtual void OnIdle() { }

        private void Dispatch(SDL_MouseMotionEvent @event)
        {
            var windows = WindowsInternal;
            var window = windows.FirstOrDefault(w => w.Id == @event.windowID);
            if (window != null)
            {
                window.HandleEvent(@event);
            }
        }

        private void Dispatch(SDL_WindowEvent @event)
        {
            var windows = WindowsInternal;
            var window = windows.FirstOrDefault(w => w.Id == @event.windowID);
            if (window != null)
            {
                window.HandleEvent(@event);
            }
        }

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static int EventFilter(void* userdata, SDL_Event* @event)
        {
            var eventType = (SDL_EventType)@event->type;
            switch (eventType)
            {
                case SDL_EventType.SDL_WINDOWEVENT:
                    Application.Current.Dispatch(@event->window);
                    return 0;
            }
            return 1;
        }
    }
}
