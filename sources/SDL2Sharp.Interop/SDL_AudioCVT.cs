using System;
using System.Runtime.CompilerServices;

namespace SDL2Sharp.Interop
{
    public unsafe partial struct SDL_AudioCVT
    {
        public int needed;

        [NativeTypeName("SDL_AudioFormat")]
        public ushort src_format;

        [NativeTypeName("SDL_AudioFormat")]
        public ushort dst_format;

        public double rate_incr;

        [NativeTypeName("Uint8 *")]
        public byte* buf;

        public int len;

        public int len_cvt;

        public int len_mult;

        public double len_ratio;

        [NativeTypeName("SDL_AudioFilter [10]")]
        public _filters_e__FixedBuffer filters;

        public int filter_index;

        public partial struct _filters_e__FixedBuffer
        {
            public IntPtr e0;
            public IntPtr e1;
            public IntPtr e2;
            public IntPtr e3;
            public IntPtr e4;
            public IntPtr e5;
            public IntPtr e6;
            public IntPtr e7;
            public IntPtr e8;
            public IntPtr e9;

            public unsafe ref IntPtr this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (IntPtr* pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }
}
