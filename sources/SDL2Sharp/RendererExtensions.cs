﻿// SDL2Sharp
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

using System;

namespace SDL2Sharp
{
    public static class RendererExtensions
    {
        public static Texture CreateTextureFromBitmap(this Renderer renderer, string filename)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or whitespace.", nameof(filename));
            }

            using var surface = Surface.LoadBitmap(filename);
            var texture = renderer.CreateTextureFromSurface(surface);
            return texture;
        }

        public static void DrawCircle(this Renderer renderer, int centerX, int centerY, int radius)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "The radius of a circle cannot be less than zero.");
            }

            var diameter = radius * 2;
            var x = radius - 1;
            var y = 0;
            var tx = 1;
            var ty = 1;
            var error = tx - diameter;

            while (x >= y)
            {
                //  Each of the following renders an octant of the circle
                renderer.DrawPoint(centerX + x, centerY - y);
                renderer.DrawPoint(centerX + x, centerY + y);
                renderer.DrawPoint(centerX - x, centerY - y);
                renderer.DrawPoint(centerX - x, centerY + y);
                renderer.DrawPoint(centerX + y, centerY - x);
                renderer.DrawPoint(centerX + y, centerY + x);
                renderer.DrawPoint(centerX - y, centerY - x);
                renderer.DrawPoint(centerX - y, centerY + x);

                if (error <= 0)
                {
                    ++y;
                    error += ty;
                    ty += 2;
                }

                if (error > 0)
                {
                    --x;
                    tx += 2;
                    error += (tx - diameter);
                }
            }
        }

        public static void DrawEllipse(this Renderer renderer, int centerX, int centerY, int radiusX, int radiusY)
        {
            // This is the algorithm documented in the paper "Drawing Ellipses Using Filled Rectangles" by L. Patrick.
            //
            // See: http://enchantia.com/software/graphapp/doc/tech/ellipses.html

            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (radiusX < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radiusX), radiusX, "The semi-major axis of an ellipse cannot be less than zero");
            }

            if (radiusY < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radiusY), radiusY, "The semi-minor axis of an ellipse cannot be less than zero");
            }

            var x = 0;
            var y = radiusY;
            var radiusX2 = radiusX * radiusX;
            var radiusY2 = radiusY * radiusY;
            var crit1 = -(radiusX2 / 4 + radiusX % 2 + radiusY2);
            var crit2 = -(radiusY2 / 4 + radiusY % 2 + radiusX2);
            var crit3 = -(radiusY2 / 4 + radiusY % 2);
            var t = -radiusX2 * y; /* e(x+1/2,y-1/2) - (a^2+b^2)/4 */
            var dxt = 2 * radiusY2 * x;
            var dyt = -2 * radiusX2 * y;
            var d2xt = 2 * radiusY2;
            var d2yt = 2 * radiusX2;

            void IncrementX()
            {
                x++;
                dxt += d2xt;
                t += dxt;
            }

            void IncrementY()
            {
                y--;
                dyt += d2yt;
                t += dyt;
            }

            while (y >= 0 && x <= radiusX)
            {
                renderer.DrawPoint(centerX + x, centerY + y);

                if (x != 0 || y != 0)
                {
                    renderer.DrawPoint(centerX - x, centerY - y);
                }

                if (x != 0 && y != 0)
                {
                    renderer.DrawPoint(centerX + x, centerY - y);
                    renderer.DrawPoint(centerX - x, centerY + y);
                }

                if (t + radiusY2 * x <= crit1 ||   /* e(x+1,y-1/2) <= 0 */
                    t + radiusX2 * y <= crit3)     /* e(x+1/2,y) <= 0 */
                {
                    IncrementX();
                }
                else if (t - radiusX2 * y > crit2) /* e(x+1/2,y-1) > 0 */
                {
                    IncrementY();
                }
                else
                {
                    IncrementX();
                    IncrementY();
                }
            }
        }

        public static void FillCircle(this Renderer renderer, int centerX, int centerY, int radius)
        {
            FillEllipse(renderer, centerX, centerY, radius, radius);
        }

        public static void FillEllipse(this Renderer renderer, int centerX, int centerY, int radiusX, int radiusY)
        {
            // This is the algorithm documented in the paper "Drawing Ellipses Using Filled Rectangles" by L. Patrick.
            //
            // See: http://enchantia.com/software/graphapp/doc/tech/ellipses.html

            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (radiusX < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radiusX), radiusX, "The semi-major axis of an ellipse cannot be less than zero");
            }

            if (radiusY < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radiusY), radiusY, "The semi-minor axis of an ellipse cannot be less than zero");
            }

            var x = 0;
            var y = radiusY;
            var rx = x;
            var ry = y;
            var width = 1;
            var height = 1;
            var radiusX2 = radiusX * radiusX;
            var radiusY2 = radiusY * radiusY;
            var crit1 = -(radiusX2 / 4 + radiusX % 2 + radiusY2);
            var crit2 = -(radiusY2 / 4 + radiusY % 2 + radiusX2);
            var crit3 = -(radiusY2 / 4 + radiusY % 2);
            var t = -radiusX2 * y; /* e(x+1/2,y-1/2) - (a^2+b^2)/4 */
            var dxt = 2 * radiusY2 * x;
            var dyt = -2 * radiusX2 * y;
            var d2xt = 2 * radiusY2;
            var d2yt = 2 * radiusX2;

            void IncrementX()
            {
                x++;
                dxt += d2xt;
                t += dxt;
            }

            void IncrementY()
            {
                y--;
                dyt += d2yt;
                t += dyt;
            }

            if (radiusY == 0)
            {
                renderer.FillRect(centerX - radiusX, centerY, 2 * radiusX + 1, 1);
                return;
            }

            while (y >= 0 && x <= radiusX)
            {
                if (t + radiusY2 * x <= crit1 ||      /* e(x+1,y-1/2) <= 0 */
                    t + radiusX2 * y <= crit3)        /* e(x+1/2,y) <= 0 */
                {
                    if (height == 1)
                    {
                        /* draw nothing */
                    }
                    else if (ry * 2 + 1 > (height - 1) * 2)
                    {
                        renderer.FillRect(centerX - rx, centerY - ry, width, height - 1);
                        renderer.FillRect(centerX - rx, centerY + ry + 1, width, 1 - height);
                        ry -= height - 1;
                        height = 1;
                    }
                    else
                    {
                        renderer.FillRect(centerX - rx, centerY - ry, width, ry * 2 + 1);
                        ry -= ry;
                        height = 1;
                    }
                    IncrementX();
                    rx++;
                    width += 2;
                }
                else if (t - radiusX2 * y > crit2)
                { /* e(x+1/2,y-1) > 0 */
                    IncrementY();
                    height++;
                }
                else
                {
                    if (ry * 2 + 1 > height * 2)
                    {
                        renderer.FillRect(centerX - rx, centerY - ry, width, height);
                        renderer.FillRect(centerX - rx, centerY + ry + 1, width, -height);
                    }
                    else
                    {
                        renderer.FillRect(centerX - rx, centerY - ry, width, ry * 2 + 1);
                    }
                    IncrementX();
                    IncrementY();
                    rx++;
                    width += 2;
                    ry -= height;
                    height = 1;
                }
            }

            if (ry > height)
            {
                renderer.FillRect(centerX - rx, centerY - ry, width, height);
                renderer.FillRect(centerX - rx, centerY + ry + 1, width, -height);
            }
            else
            {
                renderer.FillRect(centerX - rx, centerY - ry, width, ry * 2 + 1);
            }
        }

        public static void DrawTextBlended(this Renderer renderer, int x, int y, Font font, string text)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            using var textSurface = font.RenderBlended(text, renderer.DrawColor);
            using var textTexture = renderer.CreateTextureFromSurface(textSurface);
            renderer.Copy(textTexture, new Rectangle(x, y, textTexture.Width, textTexture.Height));
        }
    }
}
