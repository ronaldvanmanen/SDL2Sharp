using System.Runtime.InteropServices;

namespace SDL2Sharp.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void SDL_AudioCallback(void* userdata, [NativeTypeName("Uint8 *")] byte* stream, int len);
}
