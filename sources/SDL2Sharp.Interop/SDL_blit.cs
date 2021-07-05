using System.Runtime.InteropServices;

namespace SDL2Sharp.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int SDL_blit([NativeTypeName("struct SDL_Surface *")] SDL_Surface* src, SDL_Rect* srcrect, [NativeTypeName("struct SDL_Surface *")] SDL_Surface* dst, SDL_Rect* dstrect);
}
