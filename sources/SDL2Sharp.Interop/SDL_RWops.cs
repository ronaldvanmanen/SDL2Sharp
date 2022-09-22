// SDL2Sharp
//
// Copyright (C) 2021 Ronald van Manen <rvanmanen@gmail.com>
//
// This software is provided 'as-is', without any express or implied
// warranty.  In no event will the authors be held liable for any damages
// arising from the use of this software.
// 
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would be
//    appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be
//    misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.

using System.Runtime.InteropServices;

namespace SDL2Sharp.Interop
{
    public unsafe partial struct SDL_RWops
    {
        [NativeTypeName("Sint64 (*)(struct SDL_RWops *) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<SDL_RWops*, long> size;

        [NativeTypeName("Sint64 (*)(struct SDL_RWops *, Sint64, int) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<SDL_RWops*, long, int, long> seek;

        [NativeTypeName("size_t (*)(struct SDL_RWops *, void *, size_t, size_t) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<SDL_RWops*, void*, nuint, nuint, nuint> read;

        [NativeTypeName("size_t (*)(struct SDL_RWops *, const void *, size_t, size_t) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<SDL_RWops*, void*, nuint, nuint, nuint> write;

        [NativeTypeName("int (*)(struct SDL_RWops *) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<SDL_RWops*, int> close;

        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("union (anonymous union at C:/Users/Ronald/.nuget/packages/libsdl2/2.24.0-2986998811/lib/native/include/SDL_rwops.h:94:5)")]
        public _hidden_e__Union hidden;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _hidden_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at C:/Users/Ronald/.nuget/packages/libsdl2/2.24.0-2986998811/lib/native/include/SDL_rwops.h:102:9)")]
            public _windowsio_e__Struct windowsio;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at C:/Users/Ronald/.nuget/packages/libsdl2/2.24.0-2986998811/lib/native/include/SDL_rwops.h:122:9)")]
            public _mem_e__Struct mem;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at C:/Users/Ronald/.nuget/packages/libsdl2/2.24.0-2986998811/lib/native/include/SDL_rwops.h:128:9)")]
            public _unknown_e__Struct unknown;

            public unsafe partial struct _windowsio_e__Struct
            {
                public SDL_bool append;

                public void* h;

                [NativeTypeName("struct (anonymous struct at C:/Users/Ronald/.nuget/packages/libsdl2/2.24.0-2986998811/lib/native/include/SDL_rwops.h:106:13)")]
                public _buffer_e__Struct buffer;

                public unsafe partial struct _buffer_e__Struct
                {
                    public void* data;

                    [NativeTypeName("size_t")]
                    public nuint size;

                    [NativeTypeName("size_t")]
                    public nuint left;
                }
            }

            public unsafe partial struct _mem_e__Struct
            {
                [NativeTypeName("Uint8 *")]
                public byte* @base;

                [NativeTypeName("Uint8 *")]
                public byte* here;

                [NativeTypeName("Uint8 *")]
                public byte* stop;
            }

            public unsafe partial struct _unknown_e__Struct
            {
                public void* data1;

                public void* data2;
            }
        }
    }
}
