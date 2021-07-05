namespace SDL2Sharp.Interop
{
    [NativeTypeName("int")]
    public enum SDL_RendererFlags : uint
    {
        SDL_RENDERER_SOFTWARE = 0x00000001,
        SDL_RENDERER_ACCELERATED = 0x00000002,
        SDL_RENDERER_PRESENTVSYNC = 0x00000004,
        SDL_RENDERER_TARGETTEXTURE = 0x00000008,
    }
}
