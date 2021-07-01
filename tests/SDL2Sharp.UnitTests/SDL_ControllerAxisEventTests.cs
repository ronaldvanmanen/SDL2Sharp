using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_ControllerAxisEvent" /> struct.</summary>
    public static unsafe class SDL_ControllerAxisEventTests
    {
        /// <summary>Validates that the <see cref="SDL_ControllerAxisEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_ControllerAxisEvent), Marshal.SizeOf<SDL_ControllerAxisEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_ControllerAxisEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_ControllerAxisEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_ControllerAxisEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(SDL_ControllerAxisEvent));
        }
    }
}
