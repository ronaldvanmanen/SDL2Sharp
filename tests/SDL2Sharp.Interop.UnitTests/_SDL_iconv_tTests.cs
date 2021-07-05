using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="_SDL_iconv_t" /> struct.</summary>
    public static unsafe class _SDL_iconv_tTests
    {
        /// <summary>Validates that the <see cref="_SDL_iconv_t" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_SDL_iconv_t), Marshal.SizeOf<_SDL_iconv_t>());
        }

        /// <summary>Validates that the <see cref="_SDL_iconv_t" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_SDL_iconv_t).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_SDL_iconv_t" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(_SDL_iconv_t));
        }
    }
}
