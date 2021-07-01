using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_WindowEvent" /> struct.</summary>
    public static unsafe class SDL_WindowEventTests
    {
        /// <summary>Validates that the <see cref="SDL_WindowEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_WindowEvent), Marshal.SizeOf<SDL_WindowEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_WindowEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_WindowEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_WindowEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(SDL_WindowEvent));
        }
    }
}
