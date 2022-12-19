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

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL2Sharp.Extensions
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 12)]
    public readonly struct Rgb32f : IEquatable<Rgb32f>
    {
        public static Rgb32f Black { get; } = new Rgb32f(0f, 0f, 0f);

        public static Rgb32f White { get; } = new Rgb32f(1f, 1f, 1f);

        private readonly Vector3 _components;

        public float R
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return _components.X;
            }
        }

        public float G
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return _components.Y;
            }
        }

        public float B
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return _components.Z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rgb32f(float r, float g, float b)
        : this(new Vector3(r, g, b))
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rgb32f(Rgb32f other)
        : this(other._components)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Rgb32f(Vector3 components)
        {
            _components = components;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Rgb32f other)
        {
            return _components.Equals(other._components);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Rgb32f other)
            {
                return Equals(other);
            }
            return false;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(R, G, B);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Negate(Rgb32f value)
        {
            return new Rgb32f(-value._components);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Add(Rgb32f left, Rgb32f right)
        {
            return new Rgb32f(left._components + right._components);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Subtract(Rgb32f left, Rgb32f right)
        {
            return new Rgb32f(left._components - right._components);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Multiply(float left, Rgb32f right)
        {
            return new Rgb32f(left * right._components);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Multiply(Rgb32f left, float right)
        {
            return new Rgb32f(left._components * right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Multiply(Rgb32f left, Rgb32f right)
        {
            return new Rgb32f(left._components * right._components);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Divide(Rgb32f left, Rgb32f right)
        {
            return new Rgb32f(left._components / right._components);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Divide(Rgb32f left, float right)
        {
            return new Rgb32f(left._components / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Clamp(Rgb32f value, Rgb32f min, Rgb32f max)
        {
            return new Rgb32f(Vector3.Clamp(value._components, min._components, max._components));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f Clamp(Rgb32f value)
        {
            return Clamp(value, Black, White);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator +(Rgb32f value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator -(Rgb32f value)
        {
            return Negate(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator +(Rgb32f left, Rgb32f right)
        {
            return Add(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator -(Rgb32f left, Rgb32f right)
        {
            return Subtract(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator *(float left, Rgb32f right)
        {
            return Multiply(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator *(Rgb32f left, float right)
        {
            return Multiply(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator *(Rgb32f left, Rgb32f right)
        {
            return Multiply(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator /(Rgb32f left, Rgb32f right)
        {
            return Divide(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgb32f operator /(Rgb32f left, float right)
        {
            return Divide(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Rgb32f left, Rgb32f right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Rgb32f left, Rgb32f right)
        {
            return !left.Equals(right);
        }
    }
}
