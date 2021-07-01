using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_ControllerSensorEvent" /> struct.</summary>
    public static unsafe class SDL_ControllerSensorEventTests
    {
        /// <summary>Validates that the <see cref="SDL_ControllerSensorEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_ControllerSensorEvent), Marshal.SizeOf<SDL_ControllerSensorEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_ControllerSensorEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_ControllerSensorEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_ControllerSensorEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(SDL_ControllerSensorEvent));
        }
    }
}
