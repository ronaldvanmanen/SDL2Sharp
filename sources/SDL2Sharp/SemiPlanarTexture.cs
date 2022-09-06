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

using System.Runtime.CompilerServices;
using Microsoft.Toolkit.HighPerformance;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class SemiPlanarTexture : Texture
    {
        internal SemiPlanarTexture(SDL_Texture* texture)
        : base(texture)
        { }

        public void Update(Span2D<byte> yPixels, Span2D<byte> uvPixels)
        {
            ThrowWhenDisposed();

            var yPlane = (byte*)Unsafe.AsPointer(ref yPixels.DangerousGetReference());
            var yPitch = yPixels.Width * sizeof(byte);
            var uvPlane = (byte*)Unsafe.AsPointer(ref uvPixels.DangerousGetReference());
            var uvPitch = uvPixels.Width * sizeof(byte);

            Update(null, yPlane, yPitch, uvPlane, uvPitch);
        }

        private void Update(SDL_Rect* rect, byte* yPlane, int yPitch, byte* uvPlane, int uvPitch)
        {
            Error.ThrowOnFailure(
                SDL.UpdateNVTexture(this, rect, yPlane, yPitch, uvPlane, uvPitch)
            );
        }
    }
}
