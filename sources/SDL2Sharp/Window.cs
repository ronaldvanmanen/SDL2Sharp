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
using System.Diagnostics.CodeAnalysis;
using SDL2Sharp.Internals;
using SDL2Sharp.Interop;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace SDL2Sharp
{
    public sealed unsafe class Window : IDisposable
    {
        public event EventHandler? Shown;

        public event EventHandler? Hidden;

        public event EventHandler? Exposed;

        public event EventHandler<WindowMovedEventArgs>? Moved;

        public event EventHandler<WindowResizedEventArgs>? Resized;

        public event EventHandler<WindowSizeChangedEventArgs>? SizeChanged;

        public event EventHandler? Minimized;

        public event EventHandler? Maximized;

        public event EventHandler? Restored;

        public event EventHandler? Enter;

        public event EventHandler? Leave;

        public event EventHandler? FocusGained;

        public event EventHandler? FocusLost;

        public event EventHandler? Close;

        public event EventHandler? TakeFocus;

        public event EventHandler? HitTest;

        public event EventHandler<KeyEventArgs>? KeyDown;

        public event EventHandler<KeyEventArgs>? KeyUp;

        public event EventHandler<MouseMotionEventArgs>? MouseMotion;

        public event EventHandler<MouseWheelEventArgs>? MouseWheel;

        private static readonly List<Window> _all = new();

        private SDL_Window* _handle;

        public static IReadOnlyList<Window> All => _all;

        public uint Id
        {
            get
            {
                ThrowWhenDisposed();

                return SDL.GetWindowID(_handle);
            }
        }

        public string Title
        {
            get
            {
                ThrowWhenDisposed();

                return new string(SDL.GetWindowTitle(_handle));
            }
            set
            {
                ThrowWhenDisposed();

                using (var marshaledValue = new MarshaledString(value))
                {
                    SDL.SetWindowTitle(_handle, marshaledValue);
                }
            }
        }

        public Point Position
        {
            get
            {
                ThrowWhenDisposed();

                int x, y;
                SDL.GetWindowPosition(_handle, &x, &y);
                return new Point(x, y);
            }
            set
            {
                ThrowWhenDisposed();

                SDL.SetWindowPosition(_handle, value.X, value.Y);
            }
        }

        public int Width
        {
            get
            {
                ThrowWhenDisposed();

                int width;
                SDL.GetWindowSize(_handle, &width, null);
                return width;
            }
        }

        public int Height
        {
            get
            {
                ThrowWhenDisposed();

                int height;
                SDL.GetWindowSize(_handle, null, &height);
                return height;
            }
        }

        public Size Size
        {
            get
            {
                ThrowWhenDisposed();

                int width, height;
                SDL.GetWindowSize(_handle, &width, &height);
                return new Size(width, height);
            }
            set
            {
                ThrowWhenDisposed();

                SDL.SetWindowSize(_handle, value.Width, value.Height);
            }
        }

        public Size MinimumSize
        {
            get
            {
                ThrowWhenDisposed();

                int width, height;
                SDL.GetWindowMinimumSize(_handle, &width, &height);
                return new Size(width, height);
            }
            set
            {
                ThrowWhenDisposed();

                SDL.SetWindowMinimumSize(_handle, value.Width, value.Height);
            }
        }

        public Size MaximumSize
        {
            get
            {
                ThrowWhenDisposed();

                int width, height;
                SDL.GetWindowMaximumSize(_handle, &width, &height);
                return new Size(width, height);
            }
            set
            {
                ThrowWhenDisposed();

                SDL.SetWindowMaximumSize(_handle, value.Width, value.Height);
            }
        }

        public Size ClientSize
        {
            get
            {
                ThrowWhenDisposed();

                int borderTop, borderLeft, borderBottom, borderRight;
                Error.ThrowOnFailure(
                    SDL.GetWindowBordersSize(_handle, &borderTop, &borderLeft, &borderBottom, &borderRight)
                );
                int windowWidth, windowHeight;
                SDL.GetWindowSize(_handle, &windowWidth, &windowHeight);
                var clientWidth = windowWidth - borderRight - borderLeft;
                var clientHeight = windowHeight - borderBottom - borderTop;
                return new Size(clientWidth, clientHeight);
            }
        }

        public PixelFormatEnum PixelFormat
        {
            get
            {
                ThrowWhenDisposed();

                var pixelFormat = SDL.GetWindowPixelFormat(_handle);
                Error.ThrowOnFailure(pixelFormat);
                return (PixelFormatEnum)pixelFormat;
            }
        }

        public Surface Surface
        {
            get
            {
                ThrowWhenDisposed();

                var surfaceHandle = SDL.GetWindowSurface(_handle);
                Error.ThrowOnFailure(surfaceHandle);
                return new Surface(surfaceHandle, false);
            }
        }

        public bool IsBordered
        {
            get
            {
                const uint flag = (uint)SDL_WindowFlags.SDL_WINDOW_BORDERLESS;
                var flags = SDL.GetWindowFlags(_handle);
                return (flags & flag) == 0;
            }
            set
            {
                ThrowWhenDisposed();

                SDL.SetWindowBordered(_handle, value ? SDL_bool.SDL_TRUE : SDL_bool.SDL_FALSE);
            }
        }


        public bool IsResizable
        {
            get
            {
                ThrowWhenDisposed();

                const uint flag = (uint)SDL_WindowFlags.SDL_WINDOW_RESIZABLE;
                var flags = SDL.GetWindowFlags(_handle);
                return (flags & flag) != 0;
            }
            set
            {
                ThrowWhenDisposed();

                SDL.SetWindowResizable(_handle, value ? SDL_bool.SDL_TRUE : SDL_bool.SDL_FALSE);
            }
        }

        public bool IsFullScreen
        {
            get
            {
                ThrowWhenDisposed();

                const uint flag = (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
                var flags = SDL.GetWindowFlags(_handle);
                return (flags & flag) != 0;
            }
            set
            {
                ThrowWhenDisposed();

                const uint flag = (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
                Error.ThrowOnFailure(
                    SDL.SetWindowFullscreen(_handle, value ? flag : 0u)
                );
            }
        }

        public bool IsFullScreenDesktop
        {
            get
            {
                ThrowWhenDisposed();

                const uint flag = (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP;
                var flags = SDL.GetWindowFlags(_handle);
                return (flags & flag) != 0;
            }
            set
            {
                ThrowWhenDisposed();

                const uint flag = (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP;
                Error.ThrowOnFailure(
                    SDL.SetWindowFullscreen(_handle, value ? flag : 0u)
                );
            }
        }

        public bool IsVisible
        {
            get
            {
                ThrowWhenDisposed();

                const uint flag = (uint)SDL_WindowFlags.SDL_WINDOW_SHOWN;
                var flags = SDL.GetWindowFlags(_handle);
                return (flags & flag) != 0;
            }
        }

        public Window(string title, int width, int height)
        : this(title, (int)SDL.SDL_WINDOWPOS_UNDEFINED, (int)SDL.SDL_WINDOWPOS_UNDEFINED, width, height, (uint)0)
        { }

        public Window(string title, int width, int height, WindowFlags flags)
        : this(title, (int)SDL.SDL_WINDOWPOS_UNDEFINED, (int)SDL.SDL_WINDOWPOS_UNDEFINED, width, height, (uint)flags)
        { }

        public Window(string title, int x, int y, int width, int height)
        : this(title, x, y, width, height, (uint)0)
        { }

        public Window(string title, int x, int y, int width, int height, WindowFlags flags)
        : this(title, x, y, width, height, (uint)flags)
        { }

        private Window(string title, int x, int y, int width, int height, uint flags)
        {
            using (var marshaledTitle = new MarshaledString(title))
            {
                _handle = Error.ReturnOrThrowOnFailure(
                    SDL.CreateWindow(marshaledTitle, x, y, width, height, flags)
                );

                if (!IsBordered)
                {
                    var hitTestCallback = Marshal.GetFunctionPointerForDelegate(HitTestCallback);

                    Error.ThrowOnFailure(
                        SDL.SetWindowHitTest(_handle, hitTestCallback, null)
                    );
                }
            }

            _all.Add(this);
        }

        ~Window()
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

            SDL.DestroyWindow(_handle);
            _all.Remove(this);
            _handle = null;
        }

        public void Show()
        {
            ThrowWhenDisposed();

            SDL.ShowWindow(_handle);
        }

        public void Hide()
        {
            ThrowWhenDisposed();

            SDL.HideWindow(_handle);
        }

        public void Raise()
        {
            ThrowWhenDisposed();

            SDL.RaiseWindow(_handle);
        }

        public void Maximize()
        {
            ThrowWhenDisposed();

            SDL.MaximizeWindow(_handle);
        }

        public void Minimize()
        {
            ThrowWhenDisposed();

            SDL.MinimizeWindow(_handle);
        }

        public void Restore()
        {
            ThrowWhenDisposed();

            SDL.RestoreWindow(_handle);
        }

        public Renderer CreateRenderer()
        {
            return CreateRenderer(RendererFlags.None);
        }

        public Renderer CreateRenderer(RendererFlags flags)
        {
            if (!TryCreateRenderer(flags, out var renderer, out var error))
            {
                throw error;
            }

            return renderer;
        }

        public bool TryCreateRenderer(out Renderer renderer)
        {
            return TryCreateRenderer(RendererFlags.None, out renderer);
        }

        public bool TryCreateRenderer(RendererFlags flags, out Renderer renderer)
        {
            return TryCreateRenderer(flags, out renderer, out _);
        }

        public bool TryCreateRenderer(RendererFlags flags, out Renderer renderer, out Error error)
        {
            ThrowWhenDisposed();

            var handle = SDL.CreateRenderer(_handle, -1, (uint)flags);
            if (handle is null)
            {
                error = new Error(new string(SDL.GetError()));
                renderer = null!;
                return false;
            }
            else
            {
                error = null!;
                renderer = new Renderer(handle);
                return true;
            }
        }

        public void Update()
        {
            ThrowWhenDisposed();

            Error.ThrowOnFailure(
                SDL.UpdateWindowSurface(_handle)
            );
        }

        private void ThrowWhenDisposed()
        {
            if (_handle is null)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        internal void HandleKeyDownEvent(SDL_KeyboardEvent @event)
        {
            OnKeyDown(
                new KeyEventArgs(
                    (Scancode)@event.keysym.scancode,
                    (KeyCode)@event.keysym.sym,
                    (KeyModifiers)@event.keysym.mod,
                    @event.repeat
                )
            );
        }

        internal void HandleKeyUpEvent(SDL_KeyboardEvent @event)
        {
            OnKeyUp(
                new KeyEventArgs(
                    (Scancode)@event.keysym.scancode,
                    (KeyCode)@event.keysym.sym,
                    (KeyModifiers)@event.keysym.mod,
                    @event.repeat
                )
            );
        }

        internal void HandleMouseMotionEvent(SDL_MouseMotionEvent @event)
        {
            OnMouseMotion(
                new MouseMotionEventArgs(
                    @event.x,
                    @event.y,
                    @event.xrel,
                    @event.yrel
                )
            );
        }

        internal void HandleMouseWheelEvent(SDL_MouseWheelEvent @event)
        {
            OnMouseWheelEvent(
                new MouseWheelEventArgs(
                    @event.which,
                    (MouseWheelDirection)@event.direction,
                    @event.x,
                    @event.y,
                    @event.preciseX,
                    @event.preciseY
                )
            );
        }

        internal void HandleWindowEvent(SDL_WindowEvent windowEvent)
        {
            switch ((SDL_WindowEventID)windowEvent.@event)
            {
                case SDL_WindowEventID.SDL_WINDOWEVENT_SHOWN:
                    OnShown();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_HIDDEN:
                    OnHidden();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_EXPOSED:
                    OnExposed();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_MOVED:
                    OnMoved(windowEvent.data1, windowEvent.data2);
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED:
                    OnResized(windowEvent.data1, windowEvent.data2);
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED:
                    OnSizeChanged(windowEvent.data1, windowEvent.data2);
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_MINIMIZED:
                    OnMinimized();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_MAXIMIZED:
                    OnMaximized();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_RESTORED:
                    OnRestored();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_ENTER:
                    OnEnter();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_LEAVE:
                    OnLeave();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_GAINED:
                    OnFocusGained();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_LOST:
                    OnFocusLost();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE:
                    OnClose();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_TAKE_FOCUS:
                    OnTakeFocus();
                    break;
                case SDL_WindowEventID.SDL_WINDOWEVENT_HIT_TEST:
                    OnHitTest();
                    break;
            }
        }

        private void OnShown()
        {
            Shown?.Invoke(this, EventArgs.Empty);
        }

        private void OnHidden()
        {
            Hidden?.Invoke(this, EventArgs.Empty);
        }

        private void OnExposed()
        {
            Exposed?.Invoke(this, EventArgs.Empty);
        }

        private void OnMoved(int x, int y)
        {
            Moved?.Invoke(this, new WindowMovedEventArgs(x, y));
        }

        private void OnResized(int width, int height)
        {
            Resized?.Invoke(this, new WindowResizedEventArgs(width, height));
        }

        private void OnSizeChanged(int width, int height)
        {
            SizeChanged?.Invoke(this, new WindowSizeChangedEventArgs(width, height));
        }

        private void OnMinimized()
        {
            Minimized?.Invoke(this, EventArgs.Empty);
        }

        private void OnMaximized()
        {
            Maximized?.Invoke(this, EventArgs.Empty);
        }

        private void OnRestored()
        {
            Restored?.Invoke(this, EventArgs.Empty);
        }

        private void OnEnter()
        {
            Enter?.Invoke(this, EventArgs.Empty);
        }

        private void OnLeave()
        {
            Leave?.Invoke(this, EventArgs.Empty);
        }

        private void OnFocusGained()
        {
            FocusGained?.Invoke(this, EventArgs.Empty);
        }

        private void OnFocusLost()
        {
            FocusLost?.Invoke(this, EventArgs.Empty);
        }

        private void OnClose()
        {
            Close?.Invoke(this, EventArgs.Empty);
        }

        private void OnTakeFocus()
        {
            TakeFocus?.Invoke(this, EventArgs.Empty);
        }

        private void OnHitTest()
        {
            HitTest?.Invoke(this, EventArgs.Empty);
        }

        private void OnKeyDown(KeyEventArgs eventArgs)
        {
            KeyDown?.Invoke(this, eventArgs);
        }

        private void OnKeyUp(KeyEventArgs eventArgs)
        {
            KeyUp?.Invoke(this, eventArgs);
        }

        private void OnMouseMotion(MouseMotionEventArgs eventArgs)
        {
            MouseMotion?.Invoke(this, eventArgs);
        }

        private void OnMouseWheelEvent(MouseWheelEventArgs eventArgs)
        {
            MouseWheel?.Invoke(this, eventArgs);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int HitTestCallbackDelegate(SDL_Window* win, SDL_Point* area, void* data);

        private static unsafe SDL_HitTestResult HitTestCallback(SDL_Window* win, SDL_Point* area, void* data)
        {
            int x = area->x;
            int y = area->y;

            int windowWidth = 0, windowHeight = 0;
            SDL.GetWindowSize(win, &windowWidth, &windowHeight);

            int windowTop = 0;
            int windowLeft = 0;
            int windowBottom = windowTop + windowHeight;
            int windowRight = windowLeft + windowWidth;

            int borderTop = 0, borderLeft = 0, borderBottom = 0, borderRight = 0;
            SDL.GetWindowBordersSize(win, &borderTop, &borderLeft, &borderBottom, &borderRight);

            int clientAreaTop = windowTop + borderTop;
            int clientAreaLeft = windowLeft + borderLeft;
            int clientAreaBottom = windowBottom - borderBottom;
            int clientAreaRight = windowRight - borderRight;

            if (y > windowTop && y < clientAreaTop)
            {
                return SDL_HitTestResult.SDL_HITTEST_DRAGGABLE;
            }

            if (y >= windowTop && y <= clientAreaTop)
            {
                if (x >= windowLeft && x <= clientAreaLeft)
                {
                    return SDL_HitTestResult.SDL_HITTEST_RESIZE_TOPLEFT;
                }

                if (x >= clientAreaRight && x <= windowRight)
                {
                    return SDL_HitTestResult.SDL_HITTEST_RESIZE_TOPRIGHT;
                }

                return SDL_HitTestResult.SDL_HITTEST_RESIZE_TOP;
            }

            if (y >= clientAreaBottom && y <= windowBottom)
            {
                if (x >= windowLeft && x <= clientAreaLeft)
                {
                    return SDL_HitTestResult.SDL_HITTEST_RESIZE_BOTTOMLEFT;
                }

                if (x >= clientAreaRight && x <= windowRight)
                {
                    return SDL_HitTestResult.SDL_HITTEST_RESIZE_BOTTOMRIGHT;
                }

                return SDL_HitTestResult.SDL_HITTEST_RESIZE_BOTTOM;
            }

            if (x >= windowLeft && x <= clientAreaLeft)
            {
                return SDL_HitTestResult.SDL_HITTEST_RESIZE_LEFT;
            }

            if (x >= clientAreaRight && x <= windowRight)
            {
                return SDL_HitTestResult.SDL_HITTEST_RESIZE_RIGHT;
            }

            return SDL_HitTestResult.SDL_HITTEST_NORMAL;
        }
    }
}
