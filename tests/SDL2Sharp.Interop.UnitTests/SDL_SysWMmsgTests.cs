using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_SysWMmsg" /> struct.</summary>
    public static unsafe class SDL_SysWMmsgTests
    {
        /// <summary>Validates that the <see cref="SDL_SysWMmsg" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_SysWMmsg), Marshal.SizeOf<SDL_SysWMmsg>());
        }

        /// <summary>Validates that the <see cref="SDL_SysWMmsg" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_SysWMmsg).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_SysWMmsg" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(SDL_SysWMmsg));
        }
    }
}
