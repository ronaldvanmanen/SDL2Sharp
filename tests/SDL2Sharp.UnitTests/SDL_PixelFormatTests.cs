using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_PixelFormat" /> struct.</summary>
    public static unsafe class SDL_PixelFormatTests
    {
        /// <summary>Validates that the <see cref="SDL_PixelFormat" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_PixelFormat), Marshal.SizeOf<SDL_PixelFormat>());
        }

        /// <summary>Validates that the <see cref="SDL_PixelFormat" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_PixelFormat).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_PixelFormat" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(56, sizeof(SDL_PixelFormat));
            }
            else
            {
                Assert.Equal(44, sizeof(SDL_PixelFormat));
            }
        }
    }
}
