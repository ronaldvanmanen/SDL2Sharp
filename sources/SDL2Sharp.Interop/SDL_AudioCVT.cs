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

        public unsafe partial struct _filters_e__FixedBuffer
        {
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e0;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e1;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e2;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e3;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e4;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e5;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e6;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e7;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e8;
            public delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> e9;

            public ref delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void> this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (delegate* unmanaged[Cdecl]<SDL_AudioCVT*, ushort, void>* pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }
}
