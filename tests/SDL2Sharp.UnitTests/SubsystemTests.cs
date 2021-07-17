using SDL2Sharp.Interop;
using System;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    public static class SubsystemTests
    {
        [Fact]
        public static void TestConstructor()
        {
            SDL.LibraryDirectory = (Environment.Is64BitProcess)
                ? @"..\..\..\..\packages\sdl2.runtime.win-x64"
                : @"..\..\..\..\packages\sdl2.runtime.win-x86";

            using (new Subsystem(0)) 
            { 
                // Empty on purpose
            } ;
        }
    }
}
