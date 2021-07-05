using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_ControllerTouchpadEvent" /> struct.</summary>
    public static unsafe class SDL_ControllerTouchpadEventTests
    {
        /// <summary>Validates that the <see cref="SDL_ControllerTouchpadEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_ControllerTouchpadEvent), Marshal.SizeOf<SDL_ControllerTouchpadEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_ControllerTouchpadEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_ControllerTouchpadEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_ControllerTouchpadEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(SDL_ControllerTouchpadEvent));
        }
    }
}
