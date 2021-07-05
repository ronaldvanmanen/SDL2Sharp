using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_JoyHatEvent" /> struct.</summary>
    public static unsafe class SDL_JoyHatEventTests
    {
        /// <summary>Validates that the <see cref="SDL_JoyHatEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_JoyHatEvent), Marshal.SizeOf<SDL_JoyHatEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_JoyHatEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_JoyHatEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_JoyHatEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(SDL_JoyHatEvent));
        }
    }
}
