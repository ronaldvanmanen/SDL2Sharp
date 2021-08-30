using System;

namespace SDL2Sharp
{
    [Flags]
    public enum WindowFlags
    {
        None = 0,
        FullScreen = Interop.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN,
        OpenGL = Interop.SDL_WindowFlags.SDL_WINDOW_OPENGL,
        Shown = Interop.SDL_WindowFlags.SDL_WINDOW_SHOWN,
        Hidden = Interop.SDL_WindowFlags.SDL_WINDOW_HIDDEN,
        Borderless = Interop.SDL_WindowFlags.SDL_WINDOW_BORDERLESS,
        Resizable = Interop.SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
        Minimized = Interop.SDL_WindowFlags.SDL_WINDOW_MINIMIZED,
        Maximized = Interop.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED,
        InputGrabbed = Interop.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED,
        InputFocus = Interop.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS,
        MouseFocus = Interop.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS,
        FullScreenDesktop = Interop.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP,
        Foreign = Interop.SDL_WindowFlags.SDL_WINDOW_FOREIGN,
        AllowHighDpi = Interop.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI,
        MouseCapture = Interop.SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE,
        AlwaysOnTop = Interop.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP,
        SkipTaskbar = Interop.SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR,
        Utility = Interop.SDL_WindowFlags.SDL_WINDOW_UTILITY,
        Tooptip = Interop.SDL_WindowFlags.SDL_WINDOW_TOOLTIP,
        PopupMenu = Interop.SDL_WindowFlags.SDL_WINDOW_POPUP_MENU,
        Vulkan = Interop.SDL_WindowFlags.SDL_WINDOW_VULKAN,
        Metal = Interop.SDL_WindowFlags.SDL_WINDOW_METAL,
    }
}
