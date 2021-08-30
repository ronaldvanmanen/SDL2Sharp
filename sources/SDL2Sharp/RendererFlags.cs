
using System;

namespace SDL2Sharp
{
    [Flags]
    public enum RendererFlags : uint
    {
        None = 0,
        Software = Interop.SDL_RendererFlags.SDL_RENDERER_SOFTWARE,
        Accelerated = Interop.SDL_RendererFlags.SDL_RENDERER_ACCELERATED,
        PresentVSync = Interop.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC,
        TargetTexture = Interop.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE,
    }
}
