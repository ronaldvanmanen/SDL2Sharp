using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_QuitEvent" /> struct.</summary>
    public static unsafe class SDL_QuitEventTests
    {
        /// <summary>Validates that the <see cref="SDL_QuitEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_QuitEvent), Marshal.SizeOf<SDL_QuitEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_QuitEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_QuitEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_QuitEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(SDL_QuitEvent));
        }
    }
}
