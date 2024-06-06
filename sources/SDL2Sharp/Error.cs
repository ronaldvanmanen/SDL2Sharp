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
using System.Runtime.Serialization;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed class Error : Exception
    {
        public Error() { }

        public Error(string message)
        : base(message)
        { }

        public Error(SerializationInfo info, StreamingContext context)
        : base(info, context)
        { }

        public Error(string message, Exception innerException)
        : base(message, innerException)
        { }

        internal static unsafe void ThrowOnFailure(void* pointer)
        {
            if (pointer is null)
            {
                throw new Error(new string(SDL.GetError()));
            }
        }

        internal static unsafe void ThrowOnFailure(int returnCode)
        {
            if (returnCode < 0)
            {
                throw new Error(new string(SDL.GetError()));
            }
        }

        internal static unsafe void ThrowOnFailure(uint returnCode)
        {
            if (returnCode == 0)
            {
                throw new Error(new string(SDL.GetError()));
            }
        }

        internal static unsafe uint ReturnOrThrowOnFailure(uint returnCode)
        {
            if (returnCode == 0)
            {
                throw new Error(new string(SDL.GetError()));
            }
            return returnCode;
        }

        internal static unsafe T* ReturnOrThrowOnFailure<T>(T* pointer) where T : unmanaged
        {
            if (pointer is null)
            {
                throw new Error(new string(SDL.GetError()));
            }
            return pointer;
        }
    }
}
