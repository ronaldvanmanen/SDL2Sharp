using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_RendererInfo" /> struct.</summary>
    public static unsafe class SDL_RendererInfoTests
    {
        /// <summary>Validates that the <see cref="SDL_RendererInfo" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_RendererInfo), Marshal.SizeOf<SDL_RendererInfo>());
        }

        /// <summary>Validates that the <see cref="SDL_RendererInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_RendererInfo).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_RendererInfo" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(88, sizeof(SDL_RendererInfo));
            }
            else
            {
                Assert.Equal(84, sizeof(SDL_RendererInfo));
            }
        }
    }
}
