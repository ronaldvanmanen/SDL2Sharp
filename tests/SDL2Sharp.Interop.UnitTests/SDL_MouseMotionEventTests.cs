// SDL2Sharp
//
// Copyright (C) 2021-2024 Ronald van Manen <rvanmanen@gmail.com>
//
// This software is provided 'as-is', without any express or implied
// warranty.  In no event will the authors be held liable for any damages
// arising from the use of this software.
// 
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would be
//    appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be
//    misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.

using System.Runtime.InteropServices;
using Xunit;

namespace SDL2Sharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SDL_MouseMotionEvent" /> struct.</summary>
    public static unsafe partial class SDL_MouseMotionEventTests
    {
        /// <summary>Validates that the <see cref="SDL_MouseMotionEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_MouseMotionEvent), Marshal.SizeOf<SDL_MouseMotionEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_MouseMotionEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_MouseMotionEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_MouseMotionEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(36, sizeof(SDL_MouseMotionEvent));
        }
    }
}
