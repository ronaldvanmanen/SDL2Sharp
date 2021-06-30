namespace SDL2Sharp.Samples
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            if (SDL.Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO) != 0)
            {
                SDL.Log($"Unable to initialize SDL: {SDL.GetErrorString()}");
                return 1;
            }

            /* ... */

            SDL.Quit();

            return 0;
        }
    }
}
