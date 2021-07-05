using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_AudioSpec" /> struct.</summary>
    public static unsafe class SDL_AudioSpecTests
    {
        /// <summary>Validates that the <see cref="SDL_AudioSpec" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_AudioSpec), Marshal.SizeOf<SDL_AudioSpec>());
        }

        /// <summary>Validates that the <see cref="SDL_AudioSpec" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_AudioSpec).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_AudioSpec" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(SDL_AudioSpec));
            }
            else
            {
                Assert.Equal(24, sizeof(SDL_AudioSpec));
            }
        }
    }
}
