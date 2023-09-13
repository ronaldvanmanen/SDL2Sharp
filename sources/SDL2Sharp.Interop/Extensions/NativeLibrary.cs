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

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SDL2Sharp.Interop
{
    internal static class NativeLibrary
    {
        private static readonly HashSet<Func<string, Assembly, DllImportSearchPath?, IntPtr>> _resolvers = new();

        static NativeLibrary()
        {
            System.Runtime.InteropServices.NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnDllImport);
        }

        public static void SetDllImportResolver(Func<string, Assembly, DllImportSearchPath?, IntPtr> resolver)
        {
            _resolvers.Add(resolver);
        }

        private static IntPtr OnDllImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            foreach (var resolver in _resolvers)
            {
                var result = resolver(libraryName, assembly, searchPath);
                if (result != IntPtr.Zero)
                {
                    return result;
                }
            }
            return IntPtr.Zero;
        }
    }
}
