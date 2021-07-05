using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_MouseButtonEvent" /> struct.</summary>
    public static unsafe class SDL_MouseButtonEventTests
    {
        /// <summary>Validates that the <see cref="SDL_MouseButtonEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_MouseButtonEvent), Marshal.SizeOf<SDL_MouseButtonEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_MouseButtonEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_MouseButtonEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_MouseButtonEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(SDL_MouseButtonEvent));
        }
    }
}
