using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_ControllerButtonEvent" /> struct.</summary>
    public static unsafe class SDL_ControllerButtonEventTests
    {
        /// <summary>Validates that the <see cref="SDL_ControllerButtonEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_ControllerButtonEvent), Marshal.SizeOf<SDL_ControllerButtonEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_ControllerButtonEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_ControllerButtonEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_ControllerButtonEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(SDL_ControllerButtonEvent));
        }
    }
}
