﻿// SDL2Sharp
//
// Copyright (C) 2022 Ronald van Manen <rvanmanen@gmail.com>
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

using System.Numerics;

namespace RayTracer
{
    internal sealed class Plane : IObject
    {
        public Vector3 Position { get; set; } = new Vector3(0f, 0f, 0f);

        public Vector3 Normal { get; set; } = new Vector3(0f, 1f, 0f);

        public ISurface Surface { get; set; } = new MatteSurface();

        public Vector3 NormalAt(Vector3 point)
        {
            return Normal;
        }

        public Intersection? Intersect(Ray ray)
        {
            var denominator = Vector3.Dot(Normal, ray.Direction);
            if (denominator == 0f)
            {
                return null;
            }

            var numerator = -Vector3.Dot(Normal, ray.Origin + Position);
            var t = numerator / denominator;
            if (t < 0)
            {
                return null;
            }

            return new Intersection(this, ray, t);
        }
    }
}
