using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_MouseWheelEvent" /> struct.</summary>
    public static unsafe class SDL_MouseWheelEventTests
    {
        /// <summary>Validates that the <see cref="SDL_MouseWheelEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_MouseWheelEvent), Marshal.SizeOf<SDL_MouseWheelEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_MouseWheelEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_MouseWheelEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_MouseWheelEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(SDL_MouseWheelEvent));
        }
    }
}
