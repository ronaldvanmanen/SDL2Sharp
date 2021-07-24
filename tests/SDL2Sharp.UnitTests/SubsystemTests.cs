using SDL2Sharp.Interop;
using System.Reflection;
using Xunit;

namespace SDL2Sharp.UnitTests
{
    public static class SubsystemTests
    {
        [Fact]
        public static void TestConstructor()
        {
            SDL.LibraryDirectory = typeof(SubsystemTests).Assembly.Location;

            using (new Subsystem(0)) 
            { 
                // Empty on purpose
            } ;
        }
    }
}
