using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Renderer" /> struct.</summary>
    public static unsafe class SDL_RendererTests
    {
        /// <summary>Validates that the <see cref="SDL_Renderer" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Renderer), Marshal.SizeOf<SDL_Renderer>());
        }

        /// <summary>Validates that the <see cref="SDL_Renderer" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Renderer).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Renderer" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(SDL_Renderer));
        }
    }
}
