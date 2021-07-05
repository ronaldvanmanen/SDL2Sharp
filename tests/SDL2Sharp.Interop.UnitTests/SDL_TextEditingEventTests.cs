using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_TextEditingEvent" /> struct.</summary>
    public static unsafe class SDL_TextEditingEventTests
    {
        /// <summary>Validates that the <see cref="SDL_TextEditingEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_TextEditingEvent), Marshal.SizeOf<SDL_TextEditingEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_TextEditingEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_TextEditingEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_TextEditingEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(52, sizeof(SDL_TextEditingEvent));
        }
    }
}
