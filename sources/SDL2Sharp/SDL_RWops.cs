using System;
using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    public partial struct SDL_RWops
    {
        [NativeTypeName("Sint64 (*)(struct SDL_RWops *) __attribute__((cdecl))")]
        public IntPtr size;

        [NativeTypeName("Sint64 (*)(struct SDL_RWops *, Sint64, int) __attribute__((cdecl))")]
        public IntPtr seek;

        [NativeTypeName("size_t (*)(struct SDL_RWops *, void *, size_t, size_t) __attribute__((cdecl))")]
        public IntPtr read;

        [NativeTypeName("size_t (*)(struct SDL_RWops *, const void *, size_t, size_t) __attribute__((cdecl))")]
        public IntPtr write;

        [NativeTypeName("int (*)(struct SDL_RWops *) __attribute__((cdecl))")]
        public IntPtr close;

        [NativeTypeName("Uint32")]
        public uint type;

        [NativeTypeName("union (anonymous union at submodules/sdl/include/SDL_rwops.h:94:5)")]
        public _hidden_e__Union hidden;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _hidden_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at submodules/sdl/include/SDL_rwops.h:102:9)")]
            public _windowsio_e__Struct windowsio;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at submodules/sdl/include/SDL_rwops.h:122:9)")]
            public _mem_e__Struct mem;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at submodules/sdl/include/SDL_rwops.h:128:9)")]
            public _unknown_e__Struct unknown;

            public unsafe partial struct _windowsio_e__Struct
            {
                public SDL_bool append;

                public void* h;

                [NativeTypeName("struct (anonymous struct at submodules/sdl/include/SDL_rwops.h:106:13)")]
                public _buffer_e__Struct buffer;

                public unsafe partial struct _buffer_e__Struct
                {
                    public void* data;

                    [NativeTypeName("size_t")]
                    public UIntPtr size;

                    [NativeTypeName("size_t")]
                    public UIntPtr left;
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
