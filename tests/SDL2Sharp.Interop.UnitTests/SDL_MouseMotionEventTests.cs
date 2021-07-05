using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_MouseMotionEvent" /> struct.</summary>
    public static unsafe class SDL_MouseMotionEventTests
    {
        /// <summary>Validates that the <see cref="SDL_MouseMotionEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_MouseMotionEvent), Marshal.SizeOf<SDL_MouseMotionEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_MouseMotionEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_MouseMotionEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_MouseMotionEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(36, sizeof(SDL_MouseMotionEvent));
        }
    }
}
