using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_Event" /> struct.</summary>
    public static unsafe class SDL_EventTests
    {
        /// <summary>Validates that the <see cref="SDL_Event" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_Event), Marshal.SizeOf<SDL_Event>());
        }

        /// <summary>Validates that the <see cref="SDL_Event" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutExplicitTest()
        {
            Assert.True(typeof(SDL_Event).IsExplicitLayout);
        }

        /// <summary>Validates that the <see cref="SDL_Event" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(56, sizeof(SDL_Event));
        }
    }
}
