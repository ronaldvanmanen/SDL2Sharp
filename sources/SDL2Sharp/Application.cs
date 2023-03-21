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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public abstract unsafe class Application
    {
        private static Application _instance = null!;

        public static Application Instance
        {
            get
            {
                return _instance;
            }
            private set
            {
                if (_instance != null)
                {
                    throw new InvalidOperationException();
                }

                _instance = value;
            }
        }

        public string[] CommandLineArgs { get; private set; }

        public Subsystems Subsystems { get; protected set; }

        public int ExitCode { get; protected set; }

        protected Application()
        {
            Instance = this;
            CommandLineArgs = Array.Empty<string>();
            Subsystems = Subsystems.All;
            ExitCode = 0;
        }

        public int Run()
        {
            return Run(Environment.GetCommandLineArgs());
        }

        public int Run(string[] commandLineArgs)
        {
            CommandLineArgs = commandLineArgs;

            try
            {
                OnInitializing();
                Error.ThrowOnFailure(SDL.Init((uint)Subsystems));
                Error.ThrowOnFailure(TTF.Init());
                SDL.SetEventFilter(&EventFilter, null);
                OnInitialized();

                while (true)
                {
                    SDL_Event @event;

                    while (0 != SDL.PollEvent(&@event))
                    {
                        var eventType = (SDL_EventType)@event.type;
                        switch (eventType)
                        {
                            case SDL_EventType.SDL_QUIT:
                                return ExitCode;

                            case SDL_EventType.SDL_KEYUP:
                                DispatchKeyUpEvent(@event.key);
                                break;

                            case SDL_EventType.SDL_KEYDOWN:
                                DispatchKeyDownEvent(@event.key);
                                break;

                            case SDL_EventType.SDL_MOUSEMOTION:
                                DispatchMouseMotionEvent(@event.motion);
                                break;

                            case SDL_EventType.SDL_MOUSEWHEEL:
                                DispatchMouseWheelEvent(@event.wheel);
                                break;

                            case SDL_EventType.SDL_WINDOWEVENT:
                                DispatchWindowEvent(@event.window);
                                break;
                        }
                    }

                    OnIdle();
                }
            }
            finally
            {
                OnQuiting();
                SDL.SetEventFilter(null, null);
                TTF.Quit();
                SDL.Quit();
                OnQuited();
            }
        }

        public void Quit()
        {
            Quit(0);
        }

        public void Quit(int exitCode)
        {
            ExitCode = exitCode;
            var @event = new SDL_Event { type = (uint)SDL_EventType.SDL_QUIT };
            Error.ThrowOnFailure(SDL.PushEvent(&@event));
        }

        protected virtual void OnInitializing() { }

        protected virtual void OnInitialized() { }

        protected virtual void OnQuiting() { }

        protected virtual void OnQuited() { }

        protected virtual void OnIdle() { }

        private static void DispatchKeyDownEvent(SDL_KeyboardEvent @event)
        {
            var window = Window.All.FirstOrDefault(w => w.Id == @event.windowID);
            if (window != null)
            {
                window.HandleKeyDownEvent(@event);
            }
        }

        private static void DispatchKeyUpEvent(SDL_KeyboardEvent @event)
        {
            var window = Window.All.FirstOrDefault(w => w.Id == @event.windowID);
            if (window != null)
            {
                window.HandleKeyUpEvent(@event);
            }
        }

        private static void DispatchMouseMotionEvent(SDL_MouseMotionEvent @event)
        {
            var window = Window.All.FirstOrDefault(w => w.Id == @event.windowID);
            if (window != null)
            {
                window.HandleMouseMotionEvent(@event);
            }
        }

        private void DispatchMouseWheelEvent(SDL_MouseWheelEvent @event)
        {
            var window = Window.All.FirstOrDefault(w => w.Id == @event.windowID);
            if (window != null)
            {
                window.HandleMouseWheelEvent(@event);
            }
        }

        private static void DispatchWindowEvent(SDL_WindowEvent @event)
        {
            var window = Window.All.FirstOrDefault(w => w.Id == @event.windowID);
            if (window != null)
            {
                window.HandleWindowEvent(@event);
            }
        }

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static int EventFilter(void* userdata, SDL_Event* @event)
        {
            var eventType = (SDL_EventType)@event->type;
            switch (eventType)
            {
                case SDL_EventType.SDL_WINDOWEVENT:
                    DispatchWindowEvent(@event->window);
                    return 0;
            }
            return 1;
        }
    }
}
