using System;
using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void* SDL_calloc_func([NativeTypeName("size_t")] UIntPtr nmemb, [NativeTypeName("size_t")] UIntPtr size);
}
