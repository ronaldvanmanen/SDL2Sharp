using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Surface" /> struct.</summary>
    public static unsafe class SDL_SurfaceTests
    {
        /// <summary>Validates that the <see cref="SDL_Surface" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Surface), Marshal.SizeOf<SDL_Surface>());
        }

        /// <summary>Validates that the <see cref="SDL_Surface" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Surface).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Surface" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(96, sizeof(SDL_Surface));
            }
            else
            {
                Assert.Equal(60, sizeof(SDL_Surface));
            }
        }

        /// <summary>Provides validation of the <see cref="SDL_Surface.SDL_BlitMap" /> struct.</summary>
        public static unsafe class SDL_BlitMapTests
        {
            /// <summary>Validates that the <see cref="SDL_Surface.SDL_BlitMap" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(SDL_Surface.SDL_BlitMap), Marshal.SizeOf<SDL_Surface.SDL_BlitMap>());
            }

            /// <summary>Validates that the <see cref="SDL_Surface.SDL_BlitMap" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(SDL_Surface.SDL_BlitMap).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="SDL_Surface.SDL_BlitMap" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(1, sizeof(SDL_Surface.SDL_BlitMap));
            }
        }
    }
}
