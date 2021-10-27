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

using Microsoft.Toolkit.HighPerformance;

namespace SDL2Sharp
{
    public sealed class Image<TPixelFormat> where TPixelFormat : struct
    {
        private readonly int _height;

        private readonly int _width;

        private readonly TPixelFormat[] _pixels;

        public int Height => _height;

        public int Width => _width;

        public TPixelFormat this[int y, int x]
        {
            get
            {
                return _pixels[y * Width + x];
            }
            set
            {
                _pixels[y * Width + x] = value;
            }
        }

        public Image(int width, int height)
        {
            _width = width;
            _height = height;
            _pixels = new TPixelFormat[_height * Width];
        }

        public Image<TPixelFormat> Crop(int top, int left, int bottom, int right)
        {
            var croppedImage = new Image<TPixelFormat>(right - left, bottom - top);
            for (var y = 0; y < croppedImage.Height; ++y)
            {
                for (var x = 0; x < croppedImage.Width; ++x)
                {
                    croppedImage[y, x] = this[y + top, x + left];
                }
            }
            return croppedImage;
        }

        public ref TPixelFormat DangerousGetReference()
        {
            return ref _pixels.DangerousGetReference();
        }
    }
}
