using System;
using System.Runtime.InteropServices;

namespace SDL2Sharp
{
    public static unsafe partial class SDL
    {
        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Init", ExactSpelling = true)]
        public static extern int Init([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_InitSubSystem", ExactSpelling = true)]
        public static extern int InitSubSystem([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QuitSubSystem", ExactSpelling = true)]
        public static extern void QuitSubSystem([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WasInit", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint WasInit([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Quit", ExactSpelling = true)]
        public static extern void Quit();

        [NativeTypeName("#define SDL_INIT_TIMER 0x00000001u")]
        public const uint SDL_INIT_TIMER = 0x00000001U;

        [NativeTypeName("#define SDL_INIT_AUDIO 0x00000010u")]
        public const uint SDL_INIT_AUDIO = 0x00000010U;

        [NativeTypeName("#define SDL_INIT_VIDEO 0x00000020u")]
        public const uint SDL_INIT_VIDEO = 0x00000020U;

        [NativeTypeName("#define SDL_INIT_JOYSTICK 0x00000200u")]
        public const uint SDL_INIT_JOYSTICK = 0x00000200U;

        [NativeTypeName("#define SDL_INIT_HAPTIC 0x00001000u")]
        public const uint SDL_INIT_HAPTIC = 0x00001000U;

        [NativeTypeName("#define SDL_INIT_GAMECONTROLLER 0x00002000u")]
        public const uint SDL_INIT_GAMECONTROLLER = 0x00002000U;

        [NativeTypeName("#define SDL_INIT_EVENTS 0x00004000u")]
        public const uint SDL_INIT_EVENTS = 0x00004000U;

        [NativeTypeName("#define SDL_INIT_SENSOR 0x00008000u")]
        public const uint SDL_INIT_SENSOR = 0x00008000U;

        [NativeTypeName("#define SDL_INIT_NOPARACHUTE 0x00100000u")]
        public const uint SDL_INIT_NOPARACHUTE = 0x00100000U;

        [NativeTypeName("#define SDL_INIT_EVERYTHING ( \\\n                SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS | \\\n                SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER | SDL_INIT_SENSOR \\\n            )")]
        public const uint SDL_INIT_EVERYTHING = (0x00000001U | 0x00000010U | 0x00000020U | 0x00004000U | 0x00000200U | 0x00001000U | 0x00002000U | 0x00008000U);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetAllPriority", ExactSpelling = true)]
        public static extern void LogSetAllPriority(SDL_LogPriority priority);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetPriority", ExactSpelling = true)]
        public static extern void LogSetPriority(int category, SDL_LogPriority priority);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogGetPriority", ExactSpelling = true)]
        public static extern SDL_LogPriority LogGetPriority(int category);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogResetPriorities", ExactSpelling = true)]
        public static extern void LogResetPriorities();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Log", ExactSpelling = true)]
        public static extern void Log([NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogVerbose", ExactSpelling = true)]
        public static extern void LogVerbose(int category, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogDebug", ExactSpelling = true)]
        public static extern void LogDebug(int category, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogInfo", ExactSpelling = true)]
        public static extern void LogInfo(int category, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogWarn", ExactSpelling = true)]
        public static extern void LogWarn(int category, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogError", ExactSpelling = true)]
        public static extern void LogError(int category, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogCritical", ExactSpelling = true)]
        public static extern void LogCritical(int category, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogMessage", ExactSpelling = true)]
        public static extern void LogMessage(int category, SDL_LogPriority priority, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogMessageV", ExactSpelling = true)]
        public static extern void LogMessageV(int category, SDL_LogPriority priority, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* ap);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogGetOutputFunction", ExactSpelling = true)]
        public static extern void LogGetOutputFunction([NativeTypeName("SDL_LogOutputFunction *")] IntPtr* callback, void** userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetOutputFunction", ExactSpelling = true)]
        public static extern void LogSetOutputFunction([NativeTypeName("SDL_LogOutputFunction")] IntPtr callback, void* userdata);

        [NativeTypeName("#define SDL_MAX_LOG_MESSAGE 4096")]
        public const int SDL_MAX_LOG_MESSAGE = 4096;

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetError", ExactSpelling = true)]
        public static extern int SetError([NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetError();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetErrorMsg", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetErrorMsg([NativeTypeName("char *")] sbyte* errstr, int maxlen);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearError", ExactSpelling = true)]
        public static extern void ClearError();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Error", ExactSpelling = true)]
        public static extern int Error(SDL_errorcode code);
    }
}
