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

using SDL2Sharp.Colors;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    public static class PackedTextureTests
    {
        [Fact]
        public static void CreatePackedTextureOfArgb8888()
        {
            using var window = new Window("TextureTests", 640, 480, WindowFlags.Hidden);
            using var renderer = window.CreateRenderer();
            using var texture = renderer.CreateTexture<Argb8888>(TextureAccess.Streaming, renderer.OutputSize);
            var white = new Argb8888(255, 255, 255, 255);
            texture.WithLock(image =>
            {
                for (var y = 0; y < image.Height; ++y)
                {
                    for (var x = 0; x < image.Width; ++x)
                    {
                        image[y, x] = white;
                    }
                }
            });
            renderer.Copy(texture);
            renderer.Present();
        }
    }
}
