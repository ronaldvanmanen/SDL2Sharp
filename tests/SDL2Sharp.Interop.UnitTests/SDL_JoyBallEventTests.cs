using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_JoyBallEvent" /> struct.</summary>
    public static unsafe class SDL_JoyBallEventTests
    {
        /// <summary>Validates that the <see cref="SDL_JoyBallEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_JoyBallEvent), Marshal.SizeOf<SDL_JoyBallEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_JoyBallEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_JoyBallEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_JoyBallEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(SDL_JoyBallEvent));
        }
    }
}
