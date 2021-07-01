using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_ControllerDeviceEvent" /> struct.</summary>
    public static unsafe class SDL_ControllerDeviceEventTests
    {
        /// <summary>Validates that the <see cref="SDL_ControllerDeviceEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_ControllerDeviceEvent), Marshal.SizeOf<SDL_ControllerDeviceEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_ControllerDeviceEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_ControllerDeviceEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_ControllerDeviceEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(12, sizeof(SDL_ControllerDeviceEvent));
        }
    }
}
