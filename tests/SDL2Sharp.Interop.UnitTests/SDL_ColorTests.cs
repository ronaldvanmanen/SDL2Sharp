using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Color" /> struct.</summary>
    public static unsafe class SDL_ColorTests
    {
        /// <summary>Validates that the <see cref="SDL_Color" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Color), Marshal.SizeOf<SDL_Color>());
        }

        /// <summary>Validates that the <see cref="SDL_Color" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Color).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Color" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(SDL_Color));
        }
    }
}
