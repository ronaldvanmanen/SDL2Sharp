using System;
using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void* SDL_realloc_func(void* mem, [NativeTypeName("size_t")] UIntPtr size);
}
