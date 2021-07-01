using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Keysym" /> struct.</summary>
    public static unsafe class SDL_KeysymTests
    {
        /// <summary>Validates that the <see cref="SDL_Keysym" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Keysym), Marshal.SizeOf<SDL_Keysym>());
        }

        /// <summary>Validates that the <see cref="SDL_Keysym" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_Keysym).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_Keysym" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(SDL_Keysym));
        }
    }
}
