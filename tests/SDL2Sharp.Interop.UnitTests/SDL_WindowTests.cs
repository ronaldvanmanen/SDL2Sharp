using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Window" /> struct.</summary>
    public static unsafe class SDL_WindowTests
    {
        /// <summary>Validates that the <see cref="SDL_Window" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Window), Marshal.SizeOf<SDL_Window>());
        }

        /// <summary>Validates that the <see cref="SDL_Window" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Window).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Window" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(SDL_Window));
        }
    }
}
