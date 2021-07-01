using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Point" /> struct.</summary>
    public static unsafe class SDL_PointTests
    {
        /// <summary>Validates that the <see cref="SDL_Point" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Point), Marshal.SizeOf<SDL_Point>());
        }

        /// <summary>Validates that the <see cref="SDL_Point" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Point).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Point" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(SDL_Point));
        }
    }
}
