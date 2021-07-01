using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_DollarGestureEvent" /> struct.</summary>
    public static unsafe class SDL_DollarGestureEventTests
    {
        /// <summary>Validates that the <see cref="SDL_DollarGestureEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_DollarGestureEvent), Marshal.SizeOf<SDL_DollarGestureEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_DollarGestureEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_DollarGestureEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_DollarGestureEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(40, sizeof(SDL_DollarGestureEvent));
        }
    }
}
