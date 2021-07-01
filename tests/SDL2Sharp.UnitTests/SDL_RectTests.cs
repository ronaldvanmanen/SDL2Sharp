using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Rect" /> struct.</summary>
    public static unsafe class SDL_RectTests
    {
        /// <summary>Validates that the <see cref="SDL_Rect" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Rect), Marshal.SizeOf<SDL_Rect>());
        }

        /// <summary>Validates that the <see cref="SDL_Rect" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Rect).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Rect" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(SDL_Rect));
        }
    }
}
