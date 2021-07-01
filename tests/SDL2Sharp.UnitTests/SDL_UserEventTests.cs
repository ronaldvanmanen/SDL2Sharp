using System;
using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_UserEvent" /> struct.</summary>
    public static unsafe class SDL_UserEventTests
    {
        /// <summary>Validates that the <see cref="SDL_UserEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_UserEvent), Marshal.SizeOf<SDL_UserEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_UserEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_UserEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_UserEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(SDL_UserEvent));
            }
            else
            {
                Assert.Equal(24, sizeof(SDL_UserEvent));
            }
        }
    }
}
