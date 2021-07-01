using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_AudioCVT" /> struct.</summary>
    public static unsafe class SDL_AudioCVTTests
    {
        /// <summary>Validates that the <see cref="SDL_AudioCVT" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_AudioCVT), Marshal.SizeOf<SDL_AudioCVT>());
        }

        /// <summary>Validates that the <see cref="SDL_AudioCVT" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_AudioCVT).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_AudioCVT" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(136, sizeof(SDL_AudioCVT));
            }
            else
            {
                Assert.Equal(88, sizeof(SDL_AudioCVT));
            }
        }
    }
}
