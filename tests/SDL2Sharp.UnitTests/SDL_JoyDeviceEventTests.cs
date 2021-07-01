using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_JoyDeviceEvent" /> struct.</summary>
    public static unsafe class SDL_JoyDeviceEventTests
    {
        /// <summary>Validates that the <see cref="SDL_JoyDeviceEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_JoyDeviceEvent), Marshal.SizeOf<SDL_JoyDeviceEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_JoyDeviceEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_JoyDeviceEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_JoyDeviceEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(12, sizeof(SDL_JoyDeviceEvent));
        }
    }
}
