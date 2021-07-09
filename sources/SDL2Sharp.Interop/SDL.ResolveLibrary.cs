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

namespace SDL2Sharp.Interop
{
    public static unsafe partial class SDL
    {
        public static event DllImportResolver ResolveLibrary;

        public static string LibraryDirectory { get; set; }

        static SDL()
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnDllImport);
        }

        private static IntPtr OnDllImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            return TryResolveLibrary(libraryName, assembly, searchPath, out var nativeLibrary)
                ? nativeLibrary
                : libraryName.Equals("SDL2.dll") && TryResolveSDL2(assembly, searchPath, out nativeLibrary)
                ? nativeLibrary
                : IntPtr.Zero;
        }

        private static bool TryResolveSDL2(Assembly assembly, DllImportSearchPath? searchPath, out IntPtr nativeLibrary)
        {
            if (NativeLibrary.TryLoad("SDL2.dll", assembly, searchPath, out nativeLibrary))
            {
                return true;
            }

            if (string.IsNullOrEmpty(LibraryDirectory))
            {
                return false;
            }
            
            var libraryPath = Path.Combine(LibraryDirectory, "SDL2.dll");
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
