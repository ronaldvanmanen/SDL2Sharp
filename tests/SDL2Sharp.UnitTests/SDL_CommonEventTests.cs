using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_CommonEvent" /> struct.</summary>
    public static unsafe class SDL_CommonEventTests
    {
        /// <summary>Validates that the <see cref="SDL_CommonEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_CommonEvent), Marshal.SizeOf<SDL_CommonEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_CommonEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_CommonEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_CommonEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(SDL_CommonEvent));
        }
    }
}
