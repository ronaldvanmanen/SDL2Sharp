using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_TextInputEvent" /> struct.</summary>
    public static unsafe class SDL_TextInputEventTests
    {
        /// <summary>Validates that the <see cref="SDL_TextInputEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_TextInputEvent), Marshal.SizeOf<SDL_TextInputEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_TextInputEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_TextInputEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_TextInputEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(44, sizeof(SDL_TextInputEvent));
        }
    }
}
