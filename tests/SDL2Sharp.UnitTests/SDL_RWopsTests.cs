using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_RWops" /> struct.</summary>
    public static unsafe class SDL_RWopsTests
    {
        /// <summary>Validates that the <see cref="SDL_RWops" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_RWops), Marshal.SizeOf<SDL_RWops>());
        }

        /// <summary>Validates that the <see cref="SDL_RWops" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_RWops).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_RWops" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(88, sizeof(SDL_RWops));
            }
            else
            {
                Assert.Equal(44, sizeof(SDL_RWops));
            }
        }
    }
}
