using System;
using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void* SDL_malloc_func([NativeTypeName("size_t")] UIntPtr size);
}
