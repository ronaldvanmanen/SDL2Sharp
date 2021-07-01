using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="_SDL_AudioStream" /> struct.</summary>
    public static unsafe class _SDL_AudioStreamTests
    {
        /// <summary>Validates that the <see cref="_SDL_AudioStream" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_SDL_AudioStream), Marshal.SizeOf<_SDL_AudioStream>());
        }

        /// <summary>Validates that the <see cref="_SDL_AudioStream" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_SDL_AudioStream).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_SDL_AudioStream" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(_SDL_AudioStream));
        }
    }
}
