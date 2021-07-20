// SDL2Sharp
//
// Copyright (C) 2021 Ronald van Manen <rvanmanen@gmail.com>
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
    /// <summary>Provides validation of the <see cref="SDL_MultiGestureEvent" /> struct.</summary>
    public static unsafe class SDL_MultiGestureEventTests
    {
        /// <summary>Validates that the <see cref="SDL_MultiGestureEvent" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SDL_MultiGestureEvent), Marshal.SizeOf<SDL_MultiGestureEvent>());
        }

        /// <summary>Validates that the <see cref="SDL_MultiGestureEvent" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SDL_MultiGestureEvent).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SDL_MultiGestureEvent" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(40, sizeof(SDL_MultiGestureEvent));
        }
    }
}