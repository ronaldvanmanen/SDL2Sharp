﻿// SDL2Sharp
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

using System;
using SDL2Sharp;
using SDL2Sharp.Extensions;

namespace ParticleSystem
{
    internal sealed class Particle
    {
        public Particle()
        {
            Lifespan = TimeSpan.Zero;
            Age = TimeSpan.Zero;
            Color = new Color(0, 0, 0, 0);
            Position = new Point(0, 0);
            Radius = 0;
        }

        public void Respawn(TimeSpan lifespan, Color color, Point position, double radius)
        {
            Lifespan = lifespan;
            Age = TimeSpan.Zero;
            Color = color;
            Position = position;
            Radius = radius;
        }

        public TimeSpan Lifespan { get; private set; }

        public TimeSpan Age { get; private set; }

        public bool IsDead => Age >= Lifespan;

        public Color Color { get; private set; }

        public Point Position { get; private set; }

        public double Radius { get; private set; }

        public void Update(DateTime realTime, TimeSpan elapsedTime)
        {
            var lifetime = Lifespan - Age;
            var ratio = Math.Clamp(1.0 - elapsedTime / lifetime, 0.0, 1.0);
            Age += elapsedTime;
            Radius = ratio * Radius;
            Color = new Color(Color.R, Color.G, Color.B, (byte)Math.Ceiling(ratio * Color.A));
        }

        public void Render(Renderer renderer)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            renderer.RenderDrawColor = Color;
            renderer.RenderBlendMode = BlendMode.Blend;
            renderer.RenderFillCircle(Position.X, Position.Y, (int)Math.Ceiling(Radius));
        }
    }
}
