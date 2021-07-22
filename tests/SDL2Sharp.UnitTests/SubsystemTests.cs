using Xunit;

namespace SDL2Sharp.UnitTests
{
    public static class SubsystemTests
    {
        [Fact]
        public static void TestConstructor()
        {
            using (new Subsystem(0)) 
            { 
                // Empty on purpose
            } ;
        }
    }
}
