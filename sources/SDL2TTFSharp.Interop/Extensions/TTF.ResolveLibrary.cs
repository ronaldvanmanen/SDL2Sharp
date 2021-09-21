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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SDL2TTFSharp.Interop
{
    public static unsafe partial class TTF
    {
        public static event DllImportResolver? ResolveLibrary;

        public static string? LibraryDirectory { get; set; }

        static TTF()
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnDllImport);
        }

        private static IntPtr OnDllImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            return TryResolveLibrary(libraryName, assembly, searchPath, out var nativeLibrary)
                ? nativeLibrary
                : libraryName.Equals("libfreetype-6.dll") && TryResolveNativeLibrary(libraryName, assembly, searchPath, out nativeLibrary)
                ? nativeLibrary
                : libraryName.Equals("SDL2_ttf.dll") && TryResolveNativeLibrary(libraryName, assembly, searchPath, out nativeLibrary)
                ? nativeLibrary
                : libraryName.Equals("zlib1.dll") && TryResolveNativeLibrary(libraryName, assembly, searchPath, out nativeLibrary)
                ? nativeLibrary
                : IntPtr.Zero;
        }

        private static bool TryResolveNativeLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath, out IntPtr nativeLibrary)
        {
            if (NativeLibrary.TryLoad(libraryName, assembly, searchPath, out nativeLibrary))
            {
                return true;
            }

            if (string.IsNullOrEmpty(LibraryDirectory))
            {
                return false;
            }

            var libraryPath = Path.Combine(LibraryDirectory, libraryName);
            var result = NativeLibrary.TryLoad(libraryPath, out nativeLibrary);
            return result;
        }

        private static bool TryResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath, out IntPtr nativeLibrary)
        {
            var resolveLibrary = ResolveLibrary;

            if (resolveLibrary != null)
            {
                var resolvers = resolveLibrary.GetInvocationList();

                foreach (DllImportResolver resolver in resolvers)
                {
                    nativeLibrary = resolver(libraryName, assembly, searchPath);

                    if (nativeLibrary != IntPtr.Zero)
                    {
                        return true;
                    }
                }
            }

            nativeLibrary = IntPtr.Zero;

            return false;
        }
    }
}
