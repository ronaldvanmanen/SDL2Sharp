using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_FPoint" /> struct.</summary>
    public static unsafe class SDL_FPointTests
    {
        /// <summary>Validates that the <see cref="SDL_FPoint" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_FPoint), Marshal.SizeOf<SDL_FPoint>());
        }

        /// <summary>Validates that the <see cref="SDL_FPoint" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_FPoint).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_FPoint" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(SDL_FPoint));
        }
    }
}
