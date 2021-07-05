using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_JoyAxisEvent" /> struct.</summary>
    public static unsafe class SDL_JoyAxisEventTests
    {
        /// <summary>Validates that the <see cref="SDL_JoyAxisEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_JoyAxisEvent), Marshal.SizeOf<SDL_JoyAxisEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_JoyAxisEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_JoyAxisEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_JoyAxisEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(SDL_JoyAxisEvent));
        }
    }
}
