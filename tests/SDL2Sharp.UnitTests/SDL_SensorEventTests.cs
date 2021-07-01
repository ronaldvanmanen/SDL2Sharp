using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_SensorEvent" /> struct.</summary>
    public static unsafe class SDL_SensorEventTests
    {
        /// <summary>Validates that the <see cref="SDL_SensorEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_SensorEvent), Marshal.SizeOf<SDL_SensorEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_SensorEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_SensorEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_SensorEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(36, sizeof(SDL_SensorEvent));
        }
    }
}
