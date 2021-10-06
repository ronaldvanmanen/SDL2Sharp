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

using SDL2Sharp.Internals;
using SDL2Sharp.Interop;
using System.Text;

namespace SDL2Sharp
{
    public static class Hints
    {
        public static readonly string FramebufferAcceleration = Encoding.ASCII.GetString(SDL.SDL_HINT_FRAMEBUFFER_ACCELERATION);

        public static readonly string RenderDriver = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_DRIVER);

        public static readonly string OpenGlShaders = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_OPENGL_SHADERS);

        public static readonly string Direct3DThreadSafe = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_DIRECT3D_THREADSAFE);

        public static readonly string Direct3D11Debug = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_DIRECT3D11_DEBUG);

        public static readonly string LogicalSizeMode = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_LOGICAL_SIZE_MODE);

        public static readonly string RenderScaleQuality = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_SCALE_QUALITY);

        public static readonly string RenderVSync = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_VSYNC);

        public static readonly string VideoAllowScreensaver = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_ALLOW_SCREENSAVER);

        public static readonly string VideoExternalContext = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_EXTERNAL_CONTEXT);

        public static readonly string VideoX11XVidMode = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_X11_XVIDMODE);

        public static readonly string VideoX11Xinerama = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_X11_XINERAMA);

        public static readonly string VideoX11XRandr = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_X11_XRANDR);

        public static readonly string VideoX11WindowVisualId = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_X11_WINDOW_VISUALID);

        public static readonly string VideoX11NetWmPing = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_X11_NET_WM_PING);

        public static readonly string VideoX11NetWmBypassCompositor = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR);

        public static readonly string VideoX11ForceEgl = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_X11_FORCE_EGL);

        public static readonly string WindowFrameUsableWhileCursorHidden = Encoding.ASCII.GetString(SDL.SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN);

        public static readonly string WindowsIntResourceIcon = Encoding.ASCII.GetString(SDL.SDL_HINT_WINDOWS_INTRESOURCE_ICON);

        public static readonly string WindowsIntResourceIconSmall = Encoding.ASCII.GetString(SDL.SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL);

        public static readonly string WindowsEnableMessageLoop = Encoding.ASCII.GetString(SDL.SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP);

        public static readonly string GrabKeyboard = Encoding.ASCII.GetString(SDL.SDL_HINT_GRAB_KEYBOARD);

        public static readonly string MouseDoubleClickTime = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_DOUBLE_CLICK_TIME);

        public static readonly string MouseDoubleClickRadius = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_DOUBLE_CLICK_RADIUS);

        public static readonly string MouseNormalSpeedScale = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_NORMAL_SPEED_SCALE);

        public static readonly string MouseRelativeSpeedScale = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE);

        public static readonly string MouseRelativeScaling = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_RELATIVE_SCALING);

        public static readonly string MouseRelativeModeWarp = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_RELATIVE_MODE_WARP);

        public static readonly string MouseFocusClickThrough = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH);

        public static readonly string TouchMouseEvents = Encoding.ASCII.GetString(SDL.SDL_HINT_TOUCH_MOUSE_EVENTS);

        public static readonly string MouseTouchEvents = Encoding.ASCII.GetString(SDL.SDL_HINT_MOUSE_TOUCH_EVENTS);

        public static readonly string VideoMinimizeOnFocusLoss = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS);

        public static readonly string IdleTimerDisabled = Encoding.ASCII.GetString(SDL.SDL_HINT_IDLE_TIMER_DISABLED);

        public static readonly string Orientations = Encoding.ASCII.GetString(SDL.SDL_HINT_ORIENTATIONS);

        public static readonly string AppleTvControllerUiEvents = Encoding.ASCII.GetString(SDL.SDL_HINT_APPLE_TV_CONTROLLER_UI_EVENTS);

        public static readonly string AppleTvRemoteAllowRotation = Encoding.ASCII.GetString(SDL.SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION);

        public static readonly string IosHideHomeIndicator = Encoding.ASCII.GetString(SDL.SDL_HINT_IOS_HIDE_HOME_INDICATOR);

        public static readonly string AccelerometerAsJoystick = Encoding.ASCII.GetString(SDL.SDL_HINT_ACCELEROMETER_AS_JOYSTICK);

        public static readonly string TvRemoveAsJoystick = Encoding.ASCII.GetString(SDL.SDL_HINT_TV_REMOTE_AS_JOYSTICK);

        public static readonly string XInputEnabled = Encoding.ASCII.GetString(SDL.SDL_HINT_XINPUT_ENABLED);

        public static readonly string XInputUseOldJoystickMapping = Encoding.ASCII.GetString(SDL.SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING);

        public static readonly string GameControllerType = Encoding.ASCII.GetString(SDL.SDL_HINT_GAMECONTROLLERTYPE);

        public static readonly string GameControllerConfig = Encoding.ASCII.GetString(SDL.SDL_HINT_GAMECONTROLLERCONFIG);

        public static readonly string GameControllerConfigFile = Encoding.ASCII.GetString(SDL.SDL_HINT_GAMECONTROLLERCONFIG_FILE);

        public static readonly string GameControllerIgnoreDevices = Encoding.ASCII.GetString(SDL.SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES);

        public static readonly string GameControllerIgnoreDevicesExcept = Encoding.ASCII.GetString(SDL.SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES_EXCEPT);

        public static readonly string GameControllerUseButtonLabels = Encoding.ASCII.GetString(SDL.SDL_HINT_GAMECONTROLLER_USE_BUTTON_LABELS);

        public static readonly string JOYSTICK_ALLOW_BACKGROUND_EVENTS = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS);

        public static readonly string JoystickHidApi = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI);

        public static readonly string JoystickHidApiGameCube = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_GAMECUBE);

        public static readonly string JoystickHidApiJoyCons = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_JOY_CONS);

        public static readonly string JoystickHidApiLuna = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_LUNA);

        public static readonly string JoystickHidApiPS4 = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_PS4);

        public static readonly string JoystickHidApiPS4Rumble = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_PS4_RUMBLE);

        public static readonly string JoystickHidApiPS5 = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_PS5);

        public static readonly string JoystickHidApiPS5PlayerLed = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_PS5_PLAYER_LED);

        public static readonly string JoystickHidApiPS5Rumble = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_PS5_RUMBLE);

        public static readonly string JoystickHidApiStadia = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_STADIA);

        public static readonly string JoystickHidApiSteam = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_STEAM);

        public static readonly string JoystickHidApiSwitch = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_SWITCH);

        public static readonly string JoystickHidApiSwitchHomeLed = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_SWITCH_HOME_LED);

        public static readonly string JoystickHidApiXbox = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_HIDAPI_XBOX);

        public static readonly string EnableSteamControllers = Encoding.ASCII.GetString(SDL.SDL_HINT_ENABLE_STEAM_CONTROLLERS);

        public static readonly string JoystickRawInput = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_RAWINPUT);

        public static readonly string JoystickThread = Encoding.ASCII.GetString(SDL.SDL_HINT_JOYSTICK_THREAD);

        public static readonly string LinuxJoystickDeadzones = Encoding.ASCII.GetString(SDL.SDL_HINT_LINUX_JOYSTICK_DEADZONES);

        public static readonly string AllowTopMost = Encoding.ASCII.GetString(SDL.SDL_HINT_ALLOW_TOPMOST);

        public static readonly string TimerResolution = Encoding.ASCII.GetString(SDL.SDL_HINT_TIMER_RESOLUTION);

        public static readonly string QtWaylandContentOrientation = Encoding.ASCII.GetString(SDL.SDL_HINT_QTWAYLAND_CONTENT_ORIENTATION);

        public static readonly string QtWaylandWindowFlags = Encoding.ASCII.GetString(SDL.SDL_HINT_QTWAYLAND_WINDOW_FLAGS);

        public static readonly string ThreadStackSize = Encoding.ASCII.GetString(SDL.SDL_HINT_THREAD_STACK_SIZE);

        public static readonly string ThreadPriorityPolicy = Encoding.ASCII.GetString(SDL.SDL_HINT_THREAD_PRIORITY_POLICY);

        public static readonly string ThreadForceRealtimeTimeCritical = Encoding.ASCII.GetString(SDL.SDL_HINT_THREAD_FORCE_REALTIME_TIME_CRITICAL);

        public static readonly string VideoHighDpiDisabled = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_HIGHDPI_DISABLED);

        public static readonly string MacCtrlClickEmulateRightClick = Encoding.ASCII.GetString(SDL.SDL_HINT_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK);

        public static readonly string VideoWinD3DCompiler = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_WIN_D3DCOMPILER);

        public static readonly string VideoWindowSharePixelFormat = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT);

        public static readonly string WinrtPrivacyPolicyUrl = Encoding.ASCII.GetString(SDL.SDL_HINT_WINRT_PRIVACY_POLICY_URL);

        public static readonly string WinrtPrivacyPolicyLabel = Encoding.ASCII.GetString(SDL.SDL_HINT_WINRT_PRIVACY_POLICY_LABEL);

        public static readonly string WinrtHandleBackButton = Encoding.ASCII.GetString(SDL.SDL_HINT_WINRT_HANDLE_BACK_BUTTON);

        public static readonly string VideoMacFullScreenSpaces = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES);

        public static readonly string MacBackgroundApp = Encoding.ASCII.GetString(SDL.SDL_HINT_MAC_BACKGROUND_APP);

        public static readonly string AndroidApkExpansionMainFileVersion = Encoding.ASCII.GetString(SDL.SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION);

        public static readonly string AndroidApkExpansionPatchFileVersion = Encoding.ASCII.GetString(SDL.SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION);

        public static readonly string ImeInternalEditing = Encoding.ASCII.GetString(SDL.SDL_HINT_IME_INTERNAL_EDITING);

        public static readonly string AndroidTrapBackButton = Encoding.ASCII.GetString(SDL.SDL_HINT_ANDROID_TRAP_BACK_BUTTON);

        public static readonly string AndroidBlockOnPause = Encoding.ASCII.GetString(SDL.SDL_HINT_ANDROID_BLOCK_ON_PAUSE);

        public static readonly string AndroidBlockOnPausePauseAudio = Encoding.ASCII.GetString(SDL.SDL_HINT_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO);

        public static readonly string ReturnKeyHidesIme = Encoding.ASCII.GetString(SDL.SDL_HINT_RETURN_KEY_HIDES_IME);

        public static readonly string EmscriptenKeyboardElement = Encoding.ASCII.GetString(SDL.SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT);

        public static readonly string EmscriptenAsyncify = Encoding.ASCII.GetString(SDL.SDL_HINT_EMSCRIPTEN_ASYNCIFY);

        public static readonly string NoSignalHandlers = Encoding.ASCII.GetString(SDL.SDL_HINT_NO_SIGNAL_HANDLERS);

        public static readonly string WindowsNoCloseOnAltF4 = Encoding.ASCII.GetString(SDL.SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4);

        public static readonly string BmpSaveLegacyFormat = Encoding.ASCII.GetString(SDL.SDL_HINT_BMP_SAVE_LEGACY_FORMAT);

        public static readonly string WindowsDisableThreadNaming = Encoding.ASCII.GetString(SDL.SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING);

        public static readonly string RpiVideoLayer = Encoding.ASCII.GetString(SDL.SDL_HINT_RPI_VIDEO_LAYER);

        public static readonly string VideoDoubleBuffer = Encoding.ASCII.GetString(SDL.SDL_HINT_VIDEO_DOUBLE_BUFFER);

        public static readonly string OpenGlEsDriver = Encoding.ASCII.GetString(SDL.SDL_HINT_OPENGL_ES_DRIVER);

        public static readonly string AudioResamplingMode = Encoding.ASCII.GetString(SDL.SDL_HINT_AUDIO_RESAMPLING_MODE);

        public static readonly string AudioCategory = Encoding.ASCII.GetString(SDL.SDL_HINT_AUDIO_CATEGORY);

        public static readonly string RenderBatching = Encoding.ASCII.GetString(SDL.SDL_HINT_RENDER_BATCHING);

        public static readonly string AutoUpdateJoysticks = Encoding.ASCII.GetString(SDL.SDL_HINT_AUTO_UPDATE_JOYSTICKS);

        public static readonly string AutoUpdateSensors = Encoding.ASCII.GetString(SDL.SDL_HINT_AUTO_UPDATE_SENSORS);

        public static readonly string EventLogging = Encoding.ASCII.GetString(SDL.SDL_HINT_EVENT_LOGGING);

        public static readonly string WaveRiffChunkSize = Encoding.ASCII.GetString(SDL.SDL_HINT_WAVE_RIFF_CHUNK_SIZE);

        public static readonly string WaveTruncation = Encoding.ASCII.GetString(SDL.SDL_HINT_WAVE_TRUNCATION);

        public static readonly string WaveFactChunk = Encoding.ASCII.GetString(SDL.SDL_HINT_WAVE_FACT_CHUNK);

        public static readonly string DisplayUsableBounds = Encoding.ASCII.GetString(SDL.SDL_HINT_DISPLAY_USABLE_BOUNDS);

        public static readonly string AudioDeviceAppName = Encoding.ASCII.GetString(SDL.SDL_HINT_AUDIO_DEVICE_APP_NAME);

        public static readonly string AudioDeviceStreamName = Encoding.ASCII.GetString(SDL.SDL_HINT_AUDIO_DEVICE_STREAM_NAME);

        public static readonly string PreferredLocales = Encoding.ASCII.GetString(SDL.SDL_HINT_PREFERRED_LOCALES);

        public static unsafe bool SetValue(string name, string value)
        {
            using (var marshaledName = new MarshaledString(name))
            using (var marshaledValue = new MarshaledString(value))
            {
                return 0 != SDL.SetHint(marshaledName, marshaledValue);
            }
        }

        public static unsafe bool SetValue(string name, string value, HintPriority priority)
        {
            using (var marshaledName = new MarshaledString(name))
            using (var marshaledValue = new MarshaledString(value))
            {
                return 0 != SDL.SetHintWithPriority(marshaledName, marshaledValue, (SDL_HintPriority)priority);
            }
        }

        public static unsafe string GetValue(string name)
        {
            using (var marshaledName = new MarshaledString(name))
            {
                var value = SDL.GetHint(marshaledName);
                if (value is null)
                {
                    return null!;
                }
                return new string(value);
            }

        }
    }
}
