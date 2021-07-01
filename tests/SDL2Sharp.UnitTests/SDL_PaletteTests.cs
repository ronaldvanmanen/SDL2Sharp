using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Palette" /> struct.</summary>
    public static unsafe class SDL_PaletteTests
    {
        /// <summary>Validates that the <see cref="SDL_Palette" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Palette), Marshal.SizeOf<SDL_Palette>());
        }

        /// <summary>Validates that the <see cref="SDL_Palette" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Palette).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Palette" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24, sizeof(SDL_Palette));
            }
            else
            {
                Assert.Equal(16, sizeof(SDL_Palette));
            }
        }
    }
}
