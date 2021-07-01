using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_KeyboardEvent" /> struct.</summary>
    public static unsafe class SDL_KeyboardEventTests
    {
        /// <summary>Validates that the <see cref="SDL_KeyboardEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_KeyboardEvent), Marshal.SizeOf<SDL_KeyboardEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_KeyboardEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_KeyboardEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_KeyboardEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(SDL_KeyboardEvent));
        }
    }
}
