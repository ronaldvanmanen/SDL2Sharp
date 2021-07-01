using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_OSEvent" /> struct.</summary>
    public static unsafe class SDL_OSEventTests
    {
        /// <summary>Validates that the <see cref="SDL_OSEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_OSEvent), Marshal.SizeOf<SDL_OSEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_OSEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_OSEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_OSEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(SDL_OSEvent));
        }
    }
}
