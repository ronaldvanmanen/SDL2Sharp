using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_AudioDeviceEvent" /> struct.</summary>
    public static unsafe class SDL_AudioDeviceEventTests
    {
        /// <summary>Validates that the <see cref="SDL_AudioDeviceEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_AudioDeviceEvent), Marshal.SizeOf<SDL_AudioDeviceEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_AudioDeviceEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_AudioDeviceEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_AudioDeviceEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(SDL_AudioDeviceEvent));
        }
    }
}
