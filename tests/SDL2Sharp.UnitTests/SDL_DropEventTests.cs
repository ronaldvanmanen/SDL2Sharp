using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_DropEvent" /> struct.</summary>
    public static unsafe class SDL_DropEventTests
    {
        /// <summary>Validates that the <see cref="SDL_DropEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_DropEvent), Marshal.SizeOf<SDL_DropEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_DropEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_DropEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_DropEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24, sizeof(SDL_DropEvent));
            }
            else
            {
                Assert.Equal(16, sizeof(SDL_DropEvent));
            }
        }
    }
}
