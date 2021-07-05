using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Texture" /> struct.</summary>
    public static unsafe class SDL_TextureTests
    {
        /// <summary>Validates that the <see cref="SDL_Texture" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Texture), Marshal.SizeOf<SDL_Texture>());
        }

        /// <summary>Validates that the <see cref="SDL_Texture" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Texture).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Texture" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(SDL_Texture));
        }
    }
}
