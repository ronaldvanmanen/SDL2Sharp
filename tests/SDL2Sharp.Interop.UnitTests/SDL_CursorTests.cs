using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Cursor" /> struct.</summary>
    public static unsafe class SDL_CursorTests
    {
        /// <summary>Validates that the <see cref="SDL_Cursor" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Cursor), Marshal.SizeOf<SDL_Cursor>());
        }

        /// <summary>Validates that the <see cref="SDL_Cursor" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Cursor).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Cursor" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(SDL_Cursor));
        }
    }
}
