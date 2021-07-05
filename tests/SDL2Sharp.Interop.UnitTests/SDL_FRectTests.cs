using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_FRect" /> struct.</summary>
    public static unsafe class SDL_FRectTests
    {
        /// <summary>Validates that the <see cref="SDL_FRect" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_FRect), Marshal.SizeOf<SDL_FRect>());
        }

        /// <summary>Validates that the <see cref="SDL_FRect" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_FRect).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_FRect" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(SDL_FRect));
        }
    }
}
