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
