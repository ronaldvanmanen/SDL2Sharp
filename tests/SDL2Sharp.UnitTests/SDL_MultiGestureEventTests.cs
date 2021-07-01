using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_MultiGestureEvent" /> struct.</summary>
    public static unsafe class SDL_MultiGestureEventTests
    {
        /// <summary>Validates that the <see cref="SDL_MultiGestureEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_MultiGestureEvent), Marshal.SizeOf<SDL_MultiGestureEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_MultiGestureEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_MultiGestureEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_MultiGestureEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(40, sizeof(SDL_MultiGestureEvent));
        }
    }
}
