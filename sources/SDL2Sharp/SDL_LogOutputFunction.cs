using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void SDL_LogOutputFunction(void* userdata, int category, SDL_LogPriority priority, [NativeTypeName("const char *")] sbyte* message);
}
