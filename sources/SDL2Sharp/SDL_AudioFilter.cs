using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void SDL_AudioFilter([NativeTypeName("struct SDL_AudioCVT *")] SDL_AudioCVT* cvt, [NativeTypeName("SDL_AudioFormat")] ushort format);
}
