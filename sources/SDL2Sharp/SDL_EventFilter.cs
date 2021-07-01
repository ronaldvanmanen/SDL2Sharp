using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int SDL_EventFilter(void* userdata, SDL_Event* @event);
}
