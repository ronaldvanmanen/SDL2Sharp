using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_DisplayEvent" /> struct.</summary>
    public static unsafe class SDL_DisplayEventTests
    {
        /// <summary>Validates that the <see cref="SDL_DisplayEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_DisplayEvent), Marshal.SizeOf<SDL_DisplayEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_DisplayEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_DisplayEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_DisplayEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(SDL_DisplayEvent));
        }
    }
}
