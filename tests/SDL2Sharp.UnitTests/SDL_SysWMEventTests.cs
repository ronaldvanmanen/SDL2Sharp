using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_SysWMEvent" /> struct.</summary>
    public static unsafe class SDL_SysWMEventTests
    {
        /// <summary>Validates that the <see cref="SDL_SysWMEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_SysWMEvent), Marshal.SizeOf<SDL_SysWMEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_SysWMEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_SysWMEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_SysWMEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(SDL_SysWMEvent));
            }
            else
            {
                Assert.Equal(12, sizeof(SDL_SysWMEvent));
            }
        }
    }
}
