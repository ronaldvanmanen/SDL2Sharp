using Xunit;

namespace SDL2Sharp.UnitTests
{
    public static class SubsystemTests
    {
        [Fact(Skip = "Skipped because the runtime packages are not downloaded when in CI.")]
        public static void TestConstructor()
        {
            using (new Subsystem(0)) 
            { 
                // Empty on purpose
            } ;
        }
    }
}
