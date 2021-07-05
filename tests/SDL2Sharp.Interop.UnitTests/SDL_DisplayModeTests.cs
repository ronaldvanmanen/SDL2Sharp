using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_DisplayMode" /> struct.</summary>
    public static unsafe class SDL_DisplayModeTests
    {
        /// <summary>Validates that the <see cref="SDL_DisplayMode" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_DisplayMode), Marshal.SizeOf<SDL_DisplayMode>());
        }

        /// <summary>Validates that the <see cref="SDL_DisplayMode" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_DisplayMode).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_DisplayMode" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24, sizeof(SDL_DisplayMode));
            }
            else
            {
                Assert.Equal(20, sizeof(SDL_DisplayMode));
            }
        }
    }
}
