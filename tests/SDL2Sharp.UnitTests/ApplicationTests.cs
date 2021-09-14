using Xunit;

namespace SDL2Sharp.UnitTests
{
    public static class ApplicationTests
    {
        private sealed class App : Application { }

        [Fact]
        public static void TestConstructor()
        {
            using (new App())
            {
                // Empty on purpose
            };
        }
    }
}
