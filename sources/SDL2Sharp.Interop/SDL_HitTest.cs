using System.Runtime.InteropServices;

namespace SDL2Sharp.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate SDL_HitTestResult SDL_HitTest(SDL_Window* win, [NativeTypeName("const SDL_Point *")] SDL_Point* area, void* data);
}
