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
using System.Runtime.InteropServices;
using static SDL2Sharp.Interop.SDL_bool;

namespace SDL2Sharp.Interop
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

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAudioDrivers", ExactSpelling = true)]
        public static extern int GetNumAudioDrivers();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDriver", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetAudioDriver(int index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioInit", ExactSpelling = true)]
        public static extern int AudioInit([NativeTypeName("const char *")] sbyte* driver_name);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioQuit", ExactSpelling = true)]
        public static extern void AudioQuit();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentAudioDriver", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetCurrentAudioDriver();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenAudio", ExactSpelling = true)]
        public static extern int OpenAudio(SDL_AudioSpec* desired, SDL_AudioSpec* obtained);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAudioDevices", ExactSpelling = true)]
        public static extern int GetNumAudioDevices(int iscapture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetAudioDeviceName(int index, int iscapture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceSpec", ExactSpelling = true)]
        public static extern int GetAudioDeviceSpec(int index, int iscapture, SDL_AudioSpec* spec);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenAudioDevice", ExactSpelling = true)]
        [return: NativeTypeName("SDL_AudioDeviceID")]
        public static extern uint OpenAudioDevice([NativeTypeName("const char *")] sbyte* device, int iscapture, [NativeTypeName("const SDL_AudioSpec *")] SDL_AudioSpec* desired, SDL_AudioSpec* obtained, int allowed_changes);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioStatus", ExactSpelling = true)]
        public static extern SDL_AudioStatus GetAudioStatus();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceStatus", ExactSpelling = true)]
        public static extern SDL_AudioStatus GetAudioDeviceStatus([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PauseAudio", ExactSpelling = true)]
        public static extern void PauseAudio(int pause_on);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PauseAudioDevice", ExactSpelling = true)]
        public static extern void PauseAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev, int pause_on);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadWAV_RW", ExactSpelling = true)]
        public static extern SDL_AudioSpec* LoadWAV_RW(SDL_RWops* src, int freesrc, SDL_AudioSpec* spec, [NativeTypeName("Uint8 **")] byte** audio_buf, [NativeTypeName("Uint32 *")] uint* audio_len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeWAV", ExactSpelling = true)]
        public static extern void FreeWAV([NativeTypeName("Uint8 *")] byte* audio_buf);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_BuildAudioCVT", ExactSpelling = true)]
        public static extern int BuildAudioCVT(SDL_AudioCVT* cvt, [NativeTypeName("SDL_AudioFormat")] ushort src_format, [NativeTypeName("Uint8")] byte src_channels, int src_rate, [NativeTypeName("SDL_AudioFormat")] ushort dst_format, [NativeTypeName("Uint8")] byte dst_channels, int dst_rate);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertAudio", ExactSpelling = true)]
        public static extern int ConvertAudio(SDL_AudioCVT* cvt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NewAudioStream", ExactSpelling = true)]
        [return: NativeTypeName("SDL_AudioStream *")]
        public static extern _SDL_AudioStream* NewAudioStream([NativeTypeName("const SDL_AudioFormat")] ushort src_format, [NativeTypeName("const Uint8")] byte src_channels, [NativeTypeName("const int")] int src_rate, [NativeTypeName("const SDL_AudioFormat")] ushort dst_format, [NativeTypeName("const Uint8")] byte dst_channels, [NativeTypeName("const int")] int dst_rate);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamPut", ExactSpelling = true)]
        public static extern int AudioStreamPut([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream, [NativeTypeName("const void *")] void* buf, int len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamGet", ExactSpelling = true)]
        public static extern int AudioStreamGet([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream, void* buf, int len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamAvailable", ExactSpelling = true)]
        public static extern int AudioStreamAvailable([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamFlush", ExactSpelling = true)]
        public static extern int AudioStreamFlush([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamClear", ExactSpelling = true)]
        public static extern void AudioStreamClear([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeAudioStream", ExactSpelling = true)]
        public static extern void FreeAudioStream([NativeTypeName("SDL_AudioStream *")] _SDL_AudioStream* stream);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MixAudio", ExactSpelling = true)]
        public static extern void MixAudio([NativeTypeName("Uint8 *")] byte* dst, [NativeTypeName("const Uint8 *")] byte* src, [NativeTypeName("Uint32")] uint len, int volume);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MixAudioFormat", ExactSpelling = true)]
        public static extern void MixAudioFormat([NativeTypeName("Uint8 *")] byte* dst, [NativeTypeName("const Uint8 *")] byte* src, [NativeTypeName("SDL_AudioFormat")] ushort format, [NativeTypeName("Uint32")] uint len, int volume);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QueueAudio", ExactSpelling = true)]
        public static extern int QueueAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev, [NativeTypeName("const void *")] void* data, [NativeTypeName("Uint32")] uint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DequeueAudio", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint DequeueAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev, void* data, [NativeTypeName("Uint32")] uint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetQueuedAudioSize", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint GetQueuedAudioSize([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearQueuedAudio", ExactSpelling = true)]
        public static extern void ClearQueuedAudio([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockAudio", ExactSpelling = true)]
        public static extern void LockAudio();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockAudioDevice", ExactSpelling = true)]
        public static extern void LockAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockAudio", ExactSpelling = true)]
        public static extern void UnlockAudio();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockAudioDevice", ExactSpelling = true)]
        public static extern void UnlockAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CloseAudio", ExactSpelling = true)]
        public static extern void CloseAudio();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CloseAudioDevice", ExactSpelling = true)]
        public static extern void CloseAudioDevice([NativeTypeName("SDL_AudioDeviceID")] uint dev);

        [NativeTypeName("#define SDL_AUDIO_MASK_BITSIZE (0xFF)")]
        public const int SDL_AUDIO_MASK_BITSIZE = (0xFF);

        [NativeTypeName("#define SDL_AUDIO_MASK_DATATYPE (1<<8)")]
        public const int SDL_AUDIO_MASK_DATATYPE = (1 << 8);

        [NativeTypeName("#define SDL_AUDIO_MASK_ENDIAN (1<<12)")]
        public const int SDL_AUDIO_MASK_ENDIAN = (1 << 12);

        [NativeTypeName("#define SDL_AUDIO_MASK_SIGNED (1<<15)")]
        public const int SDL_AUDIO_MASK_SIGNED = (1 << 15);

        [NativeTypeName("#define AUDIO_U8 0x0008")]
        public const int AUDIO_U8 = 0x0008;

        [NativeTypeName("#define AUDIO_S8 0x8008")]
        public const int AUDIO_S8 = 0x8008;

        [NativeTypeName("#define AUDIO_U16LSB 0x0010")]
        public const int AUDIO_U16LSB = 0x0010;

        [NativeTypeName("#define AUDIO_S16LSB 0x8010")]
        public const int AUDIO_S16LSB = 0x8010;

        [NativeTypeName("#define AUDIO_U16MSB 0x1010")]
        public const int AUDIO_U16MSB = 0x1010;

        [NativeTypeName("#define AUDIO_S16MSB 0x9010")]
        public const int AUDIO_S16MSB = 0x9010;

        [NativeTypeName("#define AUDIO_U16 AUDIO_U16LSB")]
        public const int AUDIO_U16 = 0x0010;

        [NativeTypeName("#define AUDIO_S16 AUDIO_S16LSB")]
        public const int AUDIO_S16 = 0x8010;

        [NativeTypeName("#define AUDIO_S32LSB 0x8020")]
        public const int AUDIO_S32LSB = 0x8020;

        [NativeTypeName("#define AUDIO_S32MSB 0x9020")]
        public const int AUDIO_S32MSB = 0x9020;

        [NativeTypeName("#define AUDIO_S32 AUDIO_S32LSB")]
        public const int AUDIO_S32 = 0x8020;

        [NativeTypeName("#define AUDIO_F32LSB 0x8120")]
        public const int AUDIO_F32LSB = 0x8120;

        [NativeTypeName("#define AUDIO_F32MSB 0x9120")]
        public const int AUDIO_F32MSB = 0x9120;

        [NativeTypeName("#define AUDIO_F32 AUDIO_F32LSB")]
        public const int AUDIO_F32 = 0x8120;

        [NativeTypeName("#define AUDIO_U16SYS AUDIO_U16LSB")]
        public const int AUDIO_U16SYS = 0x0010;

        [NativeTypeName("#define AUDIO_S16SYS AUDIO_S16LSB")]
        public const int AUDIO_S16SYS = 0x8010;

        [NativeTypeName("#define AUDIO_S32SYS AUDIO_S32LSB")]
        public const int AUDIO_S32SYS = 0x8020;

        [NativeTypeName("#define AUDIO_F32SYS AUDIO_F32LSB")]
        public const int AUDIO_F32SYS = 0x8120;

        [NativeTypeName("#define SDL_AUDIO_ALLOW_FREQUENCY_CHANGE 0x00000001")]
        public const int SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;

        [NativeTypeName("#define SDL_AUDIO_ALLOW_FORMAT_CHANGE 0x00000002")]
        public const int SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;

        [NativeTypeName("#define SDL_AUDIO_ALLOW_CHANNELS_CHANGE 0x00000004")]
        public const int SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;

        [NativeTypeName("#define SDL_AUDIO_ALLOW_SAMPLES_CHANGE 0x00000008")]
        public const int SDL_AUDIO_ALLOW_SAMPLES_CHANGE = 0x00000008;

        [NativeTypeName("#define SDL_AUDIO_ALLOW_ANY_CHANGE (SDL_AUDIO_ALLOW_FREQUENCY_CHANGE|SDL_AUDIO_ALLOW_FORMAT_CHANGE|SDL_AUDIO_ALLOW_CHANNELS_CHANGE|SDL_AUDIO_ALLOW_SAMPLES_CHANGE)")]
        public const int SDL_AUDIO_ALLOW_ANY_CHANGE = (0x00000001 | 0x00000002 | 0x00000004 | 0x00000008);

        [NativeTypeName("#define SDL_AUDIOCVT_MAX_FILTERS 9")]
        public const int SDL_AUDIOCVT_MAX_FILTERS = 9;

        [NativeTypeName("#define SDL_MIX_MAXVOLUME 128")]
        public const int SDL_MIX_MAXVOLUME = 128;

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ComposeCustomBlendMode", ExactSpelling = true)]
        public static extern SDL_BlendMode ComposeCustomBlendMode(SDL_BlendFactor srcColorFactor, SDL_BlendFactor dstColorFactor, SDL_BlendOperation colorOperation, SDL_BlendFactor srcAlphaFactor, SDL_BlendFactor dstAlphaFactor, SDL_BlendOperation alphaOperation);

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

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PumpEvents", ExactSpelling = true)]
        public static extern void PumpEvents();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PeepEvents", ExactSpelling = true)]
        public static extern int PeepEvents(SDL_Event* events, int numevents, SDL_eventaction action, [NativeTypeName("Uint32")] uint minType, [NativeTypeName("Uint32")] uint maxType);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasEvent", ExactSpelling = true)]
        public static extern SDL_bool HasEvent([NativeTypeName("Uint32")] uint type);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasEvents", ExactSpelling = true)]
        public static extern SDL_bool HasEvents([NativeTypeName("Uint32")] uint minType, [NativeTypeName("Uint32")] uint maxType);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FlushEvent", ExactSpelling = true)]
        public static extern void FlushEvent([NativeTypeName("Uint32")] uint type);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FlushEvents", ExactSpelling = true)]
        public static extern void FlushEvents([NativeTypeName("Uint32")] uint minType, [NativeTypeName("Uint32")] uint maxType);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PollEvent", ExactSpelling = true)]
        public static extern int PollEvent(SDL_Event* @event);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WaitEvent", ExactSpelling = true)]
        public static extern int WaitEvent(SDL_Event* @event);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WaitEventTimeout", ExactSpelling = true)]
        public static extern int WaitEventTimeout(SDL_Event* @event, int timeout);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PushEvent", ExactSpelling = true)]
        public static extern int PushEvent(SDL_Event* @event);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetEventFilter", ExactSpelling = true)]
        public static extern void SetEventFilter([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetEventFilter", ExactSpelling = true)]
        public static extern SDL_bool GetEventFilter([NativeTypeName("SDL_EventFilter *")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int>* filter, void** userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AddEventWatch", ExactSpelling = true)]
        public static extern void AddEventWatch([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DelEventWatch", ExactSpelling = true)]
        public static extern void DelEventWatch([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FilterEvents", ExactSpelling = true)]
        public static extern void FilterEvents([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EventState", ExactSpelling = true)]
        [return: NativeTypeName("Uint8")]
        public static extern byte EventState([NativeTypeName("Uint32")] uint type, int state);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RegisterEvents", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint RegisterEvents(int numevents);

        [NativeTypeName("#define SDL_RELEASED 0")]
        public const int SDL_RELEASED = 0;

        [NativeTypeName("#define SDL_PRESSED 1")]
        public const int SDL_PRESSED = 1;

        [NativeTypeName("#define SDL_TEXTEDITINGEVENT_TEXT_SIZE (32)")]
        public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = (32);

        [NativeTypeName("#define SDL_TEXTINPUTEVENT_TEXT_SIZE (32)")]
        public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = (32);

        [NativeTypeName("#define SDL_QUERY -1")]
        public const int SDL_QUERY = -1;

        [NativeTypeName("#define SDL_IGNORE 0")]
        public const int SDL_IGNORE = 0;

        [NativeTypeName("#define SDL_DISABLE 0")]
        public const int SDL_DISABLE = 0;

        [NativeTypeName("#define SDL_ENABLE 1")]
        public const int SDL_ENABLE = 1;

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetHintWithPriority", ExactSpelling = true)]
        public static extern SDL_bool SetHintWithPriority([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* value, SDL_HintPriority priority);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetHint", ExactSpelling = true)]
        public static extern SDL_bool SetHint([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetHint", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetHint([NativeTypeName("const char *")] sbyte* name);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetHintBoolean", ExactSpelling = true)]
        public static extern SDL_bool GetHintBoolean([NativeTypeName("const char *")] sbyte* name, SDL_bool default_value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AddHintCallback", ExactSpelling = true)]
        public static extern void AddHintCallback([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SDL_HintCallback")] delegate* unmanaged[Cdecl]<void*, sbyte*, sbyte*, sbyte*, void> callback, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DelHintCallback", ExactSpelling = true)]
        public static extern void DelHintCallback([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SDL_HintCallback")] delegate* unmanaged[Cdecl]<void*, sbyte*, sbyte*, sbyte*, void> callback, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearHints", ExactSpelling = true)]
        public static extern void ClearHints();

        [NativeTypeName("#define SDL_HINT_ACCELEROMETER_AS_JOYSTICK \"SDL_ACCELEROMETER_AS_JOYSTICK\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ACCELEROMETER_AS_JOYSTICK => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x43, 0x43, 0x45, 0x4C, 0x45, 0x52, 0x4F, 0x4D, 0x45, 0x54, 0x45, 0x52, 0x5F, 0x41, 0x53, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x00 };

        [NativeTypeName("#define SDL_HINT_ALLOW_ALT_TAB_WHILE_GRABBED \"SDL_ALLOW_ALT_TAB_WHILE_GRABBED\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ALLOW_ALT_TAB_WHILE_GRABBED => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x4C, 0x4C, 0x4F, 0x57, 0x5F, 0x41, 0x4C, 0x54, 0x5F, 0x54, 0x41, 0x42, 0x5F, 0x57, 0x48, 0x49, 0x4C, 0x45, 0x5F, 0x47, 0x52, 0x41, 0x42, 0x42, 0x45, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_ALLOW_TOPMOST \"SDL_ALLOW_TOPMOST\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ALLOW_TOPMOST => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x4C, 0x4C, 0x4F, 0x57, 0x5F, 0x54, 0x4F, 0x50, 0x4D, 0x4F, 0x53, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION \"SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x4E, 0x44, 0x52, 0x4F, 0x49, 0x44, 0x5F, 0x41, 0x50, 0x4B, 0x5F, 0x45, 0x58, 0x50, 0x41, 0x4E, 0x53, 0x49, 0x4F, 0x4E, 0x5F, 0x4D, 0x41, 0x49, 0x4E, 0x5F, 0x46, 0x49, 0x4C, 0x45, 0x5F, 0x56, 0x45, 0x52, 0x53, 0x49, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION \"SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x4E, 0x44, 0x52, 0x4F, 0x49, 0x44, 0x5F, 0x41, 0x50, 0x4B, 0x5F, 0x45, 0x58, 0x50, 0x41, 0x4E, 0x53, 0x49, 0x4F, 0x4E, 0x5F, 0x50, 0x41, 0x54, 0x43, 0x48, 0x5F, 0x46, 0x49, 0x4C, 0x45, 0x5F, 0x56, 0x45, 0x52, 0x53, 0x49, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_ANDROID_BLOCK_ON_PAUSE \"SDL_ANDROID_BLOCK_ON_PAUSE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ANDROID_BLOCK_ON_PAUSE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x4E, 0x44, 0x52, 0x4F, 0x49, 0x44, 0x5F, 0x42, 0x4C, 0x4F, 0x43, 0x4B, 0x5F, 0x4F, 0x4E, 0x5F, 0x50, 0x41, 0x55, 0x53, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO \"SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x4E, 0x44, 0x52, 0x4F, 0x49, 0x44, 0x5F, 0x42, 0x4C, 0x4F, 0x43, 0x4B, 0x5F, 0x4F, 0x4E, 0x5F, 0x50, 0x41, 0x55, 0x53, 0x45, 0x5F, 0x50, 0x41, 0x55, 0x53, 0x45, 0x41, 0x55, 0x44, 0x49, 0x4F, 0x00 };

        [NativeTypeName("#define SDL_HINT_ANDROID_TRAP_BACK_BUTTON \"SDL_ANDROID_TRAP_BACK_BUTTON\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ANDROID_TRAP_BACK_BUTTON => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x4E, 0x44, 0x52, 0x4F, 0x49, 0x44, 0x5F, 0x54, 0x52, 0x41, 0x50, 0x5F, 0x42, 0x41, 0x43, 0x4B, 0x5F, 0x42, 0x55, 0x54, 0x54, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_APP_NAME \"SDL_APP_NAME\"")]
        public static ReadOnlySpan<byte> SDL_HINT_APP_NAME => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x50, 0x50, 0x5F, 0x4E, 0x41, 0x4D, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_APPLE_TV_CONTROLLER_UI_EVENTS \"SDL_APPLE_TV_CONTROLLER_UI_EVENTS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_APPLE_TV_CONTROLLER_UI_EVENTS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x50, 0x50, 0x4C, 0x45, 0x5F, 0x54, 0x56, 0x5F, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x5F, 0x55, 0x49, 0x5F, 0x45, 0x56, 0x45, 0x4E, 0x54, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION \"SDL_APPLE_TV_REMOTE_ALLOW_ROTATION\"")]
        public static ReadOnlySpan<byte> SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x50, 0x50, 0x4C, 0x45, 0x5F, 0x54, 0x56, 0x5F, 0x52, 0x45, 0x4D, 0x4F, 0x54, 0x45, 0x5F, 0x41, 0x4C, 0x4C, 0x4F, 0x57, 0x5F, 0x52, 0x4F, 0x54, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUDIO_CATEGORY \"SDL_AUDIO_CATEGORY\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUDIO_CATEGORY => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x44, 0x49, 0x4F, 0x5F, 0x43, 0x41, 0x54, 0x45, 0x47, 0x4F, 0x52, 0x59, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUDIO_DEVICE_APP_NAME \"SDL_AUDIO_DEVICE_APP_NAME\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUDIO_DEVICE_APP_NAME => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x44, 0x49, 0x4F, 0x5F, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x5F, 0x41, 0x50, 0x50, 0x5F, 0x4E, 0x41, 0x4D, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUDIO_DEVICE_STREAM_NAME \"SDL_AUDIO_DEVICE_STREAM_NAME\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUDIO_DEVICE_STREAM_NAME => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x44, 0x49, 0x4F, 0x5F, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x5F, 0x53, 0x54, 0x52, 0x45, 0x41, 0x4D, 0x5F, 0x4E, 0x41, 0x4D, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUDIO_DEVICE_STREAM_ROLE \"SDL_AUDIO_DEVICE_STREAM_ROLE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUDIO_DEVICE_STREAM_ROLE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x44, 0x49, 0x4F, 0x5F, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x5F, 0x53, 0x54, 0x52, 0x45, 0x41, 0x4D, 0x5F, 0x52, 0x4F, 0x4C, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUDIO_RESAMPLING_MODE \"SDL_AUDIO_RESAMPLING_MODE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUDIO_RESAMPLING_MODE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x44, 0x49, 0x4F, 0x5F, 0x52, 0x45, 0x53, 0x41, 0x4D, 0x50, 0x4C, 0x49, 0x4E, 0x47, 0x5F, 0x4D, 0x4F, 0x44, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUTO_UPDATE_JOYSTICKS \"SDL_AUTO_UPDATE_JOYSTICKS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUTO_UPDATE_JOYSTICKS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x54, 0x4F, 0x5F, 0x55, 0x50, 0x44, 0x41, 0x54, 0x45, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUTO_UPDATE_SENSORS \"SDL_AUTO_UPDATE_SENSORS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUTO_UPDATE_SENSORS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x54, 0x4F, 0x5F, 0x55, 0x50, 0x44, 0x41, 0x54, 0x45, 0x5F, 0x53, 0x45, 0x4E, 0x53, 0x4F, 0x52, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_BMP_SAVE_LEGACY_FORMAT \"SDL_BMP_SAVE_LEGACY_FORMAT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_BMP_SAVE_LEGACY_FORMAT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x42, 0x4D, 0x50, 0x5F, 0x53, 0x41, 0x56, 0x45, 0x5F, 0x4C, 0x45, 0x47, 0x41, 0x43, 0x59, 0x5F, 0x46, 0x4F, 0x52, 0x4D, 0x41, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_DISPLAY_USABLE_BOUNDS \"SDL_DISPLAY_USABLE_BOUNDS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_DISPLAY_USABLE_BOUNDS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x44, 0x49, 0x53, 0x50, 0x4C, 0x41, 0x59, 0x5F, 0x55, 0x53, 0x41, 0x42, 0x4C, 0x45, 0x5F, 0x42, 0x4F, 0x55, 0x4E, 0x44, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_EMSCRIPTEN_ASYNCIFY \"SDL_EMSCRIPTEN_ASYNCIFY\"")]
        public static ReadOnlySpan<byte> SDL_HINT_EMSCRIPTEN_ASYNCIFY => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x45, 0x4D, 0x53, 0x43, 0x52, 0x49, 0x50, 0x54, 0x45, 0x4E, 0x5F, 0x41, 0x53, 0x59, 0x4E, 0x43, 0x49, 0x46, 0x59, 0x00 };

        [NativeTypeName("#define SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT \"SDL_EMSCRIPTEN_KEYBOARD_ELEMENT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x45, 0x4D, 0x53, 0x43, 0x52, 0x49, 0x50, 0x54, 0x45, 0x4E, 0x5F, 0x4B, 0x45, 0x59, 0x42, 0x4F, 0x41, 0x52, 0x44, 0x5F, 0x45, 0x4C, 0x45, 0x4D, 0x45, 0x4E, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_ENABLE_STEAM_CONTROLLERS \"SDL_ENABLE_STEAM_CONTROLLERS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ENABLE_STEAM_CONTROLLERS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x45, 0x4E, 0x41, 0x42, 0x4C, 0x45, 0x5F, 0x53, 0x54, 0x45, 0x41, 0x4D, 0x5F, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_EVENT_LOGGING \"SDL_EVENT_LOGGING\"")]
        public static ReadOnlySpan<byte> SDL_HINT_EVENT_LOGGING => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x45, 0x56, 0x45, 0x4E, 0x54, 0x5F, 0x4C, 0x4F, 0x47, 0x47, 0x49, 0x4E, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_FRAMEBUFFER_ACCELERATION \"SDL_FRAMEBUFFER_ACCELERATION\"")]
        public static ReadOnlySpan<byte> SDL_HINT_FRAMEBUFFER_ACCELERATION => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x46, 0x52, 0x41, 0x4D, 0x45, 0x42, 0x55, 0x46, 0x46, 0x45, 0x52, 0x5F, 0x41, 0x43, 0x43, 0x45, 0x4C, 0x45, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_GAMECONTROLLERCONFIG \"SDL_GAMECONTROLLERCONFIG\"")]
        public static ReadOnlySpan<byte> SDL_HINT_GAMECONTROLLERCONFIG => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x47, 0x41, 0x4D, 0x45, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x43, 0x4F, 0x4E, 0x46, 0x49, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_GAMECONTROLLERCONFIG_FILE \"SDL_GAMECONTROLLERCONFIG_FILE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_GAMECONTROLLERCONFIG_FILE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x47, 0x41, 0x4D, 0x45, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x43, 0x4F, 0x4E, 0x46, 0x49, 0x47, 0x5F, 0x46, 0x49, 0x4C, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_GAMECONTROLLERTYPE \"SDL_GAMECONTROLLERTYPE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_GAMECONTROLLERTYPE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x47, 0x41, 0x4D, 0x45, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x54, 0x59, 0x50, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES \"SDL_GAMECONTROLLER_IGNORE_DEVICES\"")]
        public static ReadOnlySpan<byte> SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x47, 0x41, 0x4D, 0x45, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x5F, 0x49, 0x47, 0x4E, 0x4F, 0x52, 0x45, 0x5F, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES_EXCEPT \"SDL_GAMECONTROLLER_IGNORE_DEVICES_EXCEPT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_GAMECONTROLLER_IGNORE_DEVICES_EXCEPT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x47, 0x41, 0x4D, 0x45, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x5F, 0x49, 0x47, 0x4E, 0x4F, 0x52, 0x45, 0x5F, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x53, 0x5F, 0x45, 0x58, 0x43, 0x45, 0x50, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_GAMECONTROLLER_USE_BUTTON_LABELS \"SDL_GAMECONTROLLER_USE_BUTTON_LABELS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_GAMECONTROLLER_USE_BUTTON_LABELS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x47, 0x41, 0x4D, 0x45, 0x43, 0x4F, 0x4E, 0x54, 0x52, 0x4F, 0x4C, 0x4C, 0x45, 0x52, 0x5F, 0x55, 0x53, 0x45, 0x5F, 0x42, 0x55, 0x54, 0x54, 0x4F, 0x4E, 0x5F, 0x4C, 0x41, 0x42, 0x45, 0x4C, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_GRAB_KEYBOARD \"SDL_GRAB_KEYBOARD\"")]
        public static ReadOnlySpan<byte> SDL_HINT_GRAB_KEYBOARD => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x47, 0x52, 0x41, 0x42, 0x5F, 0x4B, 0x45, 0x59, 0x42, 0x4F, 0x41, 0x52, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_IDLE_TIMER_DISABLED \"SDL_IOS_IDLE_TIMER_DISABLED\"")]
        public static ReadOnlySpan<byte> SDL_HINT_IDLE_TIMER_DISABLED => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x49, 0x4F, 0x53, 0x5F, 0x49, 0x44, 0x4C, 0x45, 0x5F, 0x54, 0x49, 0x4D, 0x45, 0x52, 0x5F, 0x44, 0x49, 0x53, 0x41, 0x42, 0x4C, 0x45, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_IME_INTERNAL_EDITING \"SDL_IME_INTERNAL_EDITING\"")]
        public static ReadOnlySpan<byte> SDL_HINT_IME_INTERNAL_EDITING => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x49, 0x4D, 0x45, 0x5F, 0x49, 0x4E, 0x54, 0x45, 0x52, 0x4E, 0x41, 0x4C, 0x5F, 0x45, 0x44, 0x49, 0x54, 0x49, 0x4E, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_IME_SHOW_UI \"SDL_IME_SHOW_UI\"")]
        public static ReadOnlySpan<byte> SDL_HINT_IME_SHOW_UI => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x49, 0x4D, 0x45, 0x5F, 0x53, 0x48, 0x4F, 0x57, 0x5F, 0x55, 0x49, 0x00 };

        [NativeTypeName("#define SDL_HINT_IOS_HIDE_HOME_INDICATOR \"SDL_IOS_HIDE_HOME_INDICATOR\"")]
        public static ReadOnlySpan<byte> SDL_HINT_IOS_HIDE_HOME_INDICATOR => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x49, 0x4F, 0x53, 0x5F, 0x48, 0x49, 0x44, 0x45, 0x5F, 0x48, 0x4F, 0x4D, 0x45, 0x5F, 0x49, 0x4E, 0x44, 0x49, 0x43, 0x41, 0x54, 0x4F, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS \"SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x41, 0x4C, 0x4C, 0x4F, 0x57, 0x5F, 0x42, 0x41, 0x43, 0x4B, 0x47, 0x52, 0x4F, 0x55, 0x4E, 0x44, 0x5F, 0x45, 0x56, 0x45, 0x4E, 0x54, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI \"SDL_JOYSTICK_HIDAPI\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_GAMECUBE \"SDL_JOYSTICK_HIDAPI_GAMECUBE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_GAMECUBE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x47, 0x41, 0x4D, 0x45, 0x43, 0x55, 0x42, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_JOY_CONS \"SDL_JOYSTICK_HIDAPI_JOY_CONS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_JOY_CONS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x4A, 0x4F, 0x59, 0x5F, 0x43, 0x4F, 0x4E, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_LUNA \"SDL_JOYSTICK_HIDAPI_LUNA\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_LUNA => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x4C, 0x55, 0x4E, 0x41, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_PS4 \"SDL_JOYSTICK_HIDAPI_PS4\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_PS4 => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x50, 0x53, 0x34, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_PS4_RUMBLE \"SDL_JOYSTICK_HIDAPI_PS4_RUMBLE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_PS4_RUMBLE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x50, 0x53, 0x34, 0x5F, 0x52, 0x55, 0x4D, 0x42, 0x4C, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_PS5 \"SDL_JOYSTICK_HIDAPI_PS5\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_PS5 => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x50, 0x53, 0x35, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_PS5_PLAYER_LED \"SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_PS5_PLAYER_LED => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x50, 0x53, 0x35, 0x5F, 0x50, 0x4C, 0x41, 0x59, 0x45, 0x52, 0x5F, 0x4C, 0x45, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_PS5_RUMBLE \"SDL_JOYSTICK_HIDAPI_PS5_RUMBLE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_PS5_RUMBLE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x50, 0x53, 0x35, 0x5F, 0x52, 0x55, 0x4D, 0x42, 0x4C, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_STADIA \"SDL_JOYSTICK_HIDAPI_STADIA\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_STADIA => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x53, 0x54, 0x41, 0x44, 0x49, 0x41, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_STEAM \"SDL_JOYSTICK_HIDAPI_STEAM\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_STEAM => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x53, 0x54, 0x45, 0x41, 0x4D, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_SWITCH \"SDL_JOYSTICK_HIDAPI_SWITCH\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_SWITCH => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x53, 0x57, 0x49, 0x54, 0x43, 0x48, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_SWITCH_HOME_LED \"SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_SWITCH_HOME_LED => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x53, 0x57, 0x49, 0x54, 0x43, 0x48, 0x5F, 0x48, 0x4F, 0x4D, 0x45, 0x5F, 0x4C, 0x45, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_HIDAPI_XBOX \"SDL_JOYSTICK_HIDAPI_XBOX\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_HIDAPI_XBOX => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x48, 0x49, 0x44, 0x41, 0x50, 0x49, 0x5F, 0x58, 0x42, 0x4F, 0x58, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_RAWINPUT \"SDL_JOYSTICK_RAWINPUT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_RAWINPUT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x52, 0x41, 0x57, 0x49, 0x4E, 0x50, 0x55, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_RAWINPUT_CORRELATE_XINPUT \"SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_RAWINPUT_CORRELATE_XINPUT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x52, 0x41, 0x57, 0x49, 0x4E, 0x50, 0x55, 0x54, 0x5F, 0x43, 0x4F, 0x52, 0x52, 0x45, 0x4C, 0x41, 0x54, 0x45, 0x5F, 0x58, 0x49, 0x4E, 0x50, 0x55, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_THREAD \"SDL_JOYSTICK_THREAD\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_THREAD => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x54, 0x48, 0x52, 0x45, 0x41, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_KMSDRM_REQUIRE_DRM_MASTER \"SDL_KMSDRM_REQUIRE_DRM_MASTER\"")]
        public static ReadOnlySpan<byte> SDL_HINT_KMSDRM_REQUIRE_DRM_MASTER => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4B, 0x4D, 0x53, 0x44, 0x52, 0x4D, 0x5F, 0x52, 0x45, 0x51, 0x55, 0x49, 0x52, 0x45, 0x5F, 0x44, 0x52, 0x4D, 0x5F, 0x4D, 0x41, 0x53, 0x54, 0x45, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_JOYSTICK_DEVICE \"SDL_JOYSTICK_DEVICE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_JOYSTICK_DEVICE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_LINUX_JOYSTICK_CLASSIC \"SDL_LINUX_JOYSTICK_CLASSIC\"")]
        public static ReadOnlySpan<byte> SDL_HINT_LINUX_JOYSTICK_CLASSIC => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4C, 0x49, 0x4E, 0x55, 0x58, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x43, 0x4C, 0x41, 0x53, 0x53, 0x49, 0x43, 0x00 };

        [NativeTypeName("#define SDL_HINT_LINUX_JOYSTICK_DEADZONES \"SDL_LINUX_JOYSTICK_DEADZONES\"")]
        public static ReadOnlySpan<byte> SDL_HINT_LINUX_JOYSTICK_DEADZONES => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4C, 0x49, 0x4E, 0x55, 0x58, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x44, 0x45, 0x41, 0x44, 0x5A, 0x4F, 0x4E, 0x45, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_MAC_BACKGROUND_APP \"SDL_MAC_BACKGROUND_APP\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MAC_BACKGROUND_APP => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x41, 0x43, 0x5F, 0x42, 0x41, 0x43, 0x4B, 0x47, 0x52, 0x4F, 0x55, 0x4E, 0x44, 0x5F, 0x41, 0x50, 0x50, 0x00 };

        [NativeTypeName("#define SDL_HINT_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK \"SDL_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x41, 0x43, 0x5F, 0x43, 0x54, 0x52, 0x4C, 0x5F, 0x43, 0x4C, 0x49, 0x43, 0x4B, 0x5F, 0x45, 0x4D, 0x55, 0x4C, 0x41, 0x54, 0x45, 0x5F, 0x52, 0x49, 0x47, 0x48, 0x54, 0x5F, 0x43, 0x4C, 0x49, 0x43, 0x4B, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_DOUBLE_CLICK_RADIUS \"SDL_MOUSE_DOUBLE_CLICK_RADIUS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_DOUBLE_CLICK_RADIUS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x44, 0x4F, 0x55, 0x42, 0x4C, 0x45, 0x5F, 0x43, 0x4C, 0x49, 0x43, 0x4B, 0x5F, 0x52, 0x41, 0x44, 0x49, 0x55, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_DOUBLE_CLICK_TIME \"SDL_MOUSE_DOUBLE_CLICK_TIME\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_DOUBLE_CLICK_TIME => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x44, 0x4F, 0x55, 0x42, 0x4C, 0x45, 0x5F, 0x43, 0x4C, 0x49, 0x43, 0x4B, 0x5F, 0x54, 0x49, 0x4D, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH \"SDL_MOUSE_FOCUS_CLICKTHROUGH\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x46, 0x4F, 0x43, 0x55, 0x53, 0x5F, 0x43, 0x4C, 0x49, 0x43, 0x4B, 0x54, 0x48, 0x52, 0x4F, 0x55, 0x47, 0x48, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_NORMAL_SPEED_SCALE \"SDL_MOUSE_NORMAL_SPEED_SCALE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_NORMAL_SPEED_SCALE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x4E, 0x4F, 0x52, 0x4D, 0x41, 0x4C, 0x5F, 0x53, 0x50, 0x45, 0x45, 0x44, 0x5F, 0x53, 0x43, 0x41, 0x4C, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_RELATIVE_MODE_WARP \"SDL_MOUSE_RELATIVE_MODE_WARP\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_RELATIVE_MODE_WARP => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x52, 0x45, 0x4C, 0x41, 0x54, 0x49, 0x56, 0x45, 0x5F, 0x4D, 0x4F, 0x44, 0x45, 0x5F, 0x57, 0x41, 0x52, 0x50, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_RELATIVE_SCALING \"SDL_MOUSE_RELATIVE_SCALING\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_RELATIVE_SCALING => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x52, 0x45, 0x4C, 0x41, 0x54, 0x49, 0x56, 0x45, 0x5F, 0x53, 0x43, 0x41, 0x4C, 0x49, 0x4E, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE \"SDL_MOUSE_RELATIVE_SPEED_SCALE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x52, 0x45, 0x4C, 0x41, 0x54, 0x49, 0x56, 0x45, 0x5F, 0x53, 0x50, 0x45, 0x45, 0x44, 0x5F, 0x53, 0x43, 0x41, 0x4C, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_MOUSE_TOUCH_EVENTS \"SDL_MOUSE_TOUCH_EVENTS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_MOUSE_TOUCH_EVENTS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x54, 0x4F, 0x55, 0x43, 0x48, 0x5F, 0x45, 0x56, 0x45, 0x4E, 0x54, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_NO_SIGNAL_HANDLERS \"SDL_NO_SIGNAL_HANDLERS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_NO_SIGNAL_HANDLERS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4E, 0x4F, 0x5F, 0x53, 0x49, 0x47, 0x4E, 0x41, 0x4C, 0x5F, 0x48, 0x41, 0x4E, 0x44, 0x4C, 0x45, 0x52, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_OPENGL_ES_DRIVER \"SDL_OPENGL_ES_DRIVER\"")]
        public static ReadOnlySpan<byte> SDL_HINT_OPENGL_ES_DRIVER => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x4F, 0x50, 0x45, 0x4E, 0x47, 0x4C, 0x5F, 0x45, 0x53, 0x5F, 0x44, 0x52, 0x49, 0x56, 0x45, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_ORIENTATIONS \"SDL_IOS_ORIENTATIONS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_ORIENTATIONS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x49, 0x4F, 0x53, 0x5F, 0x4F, 0x52, 0x49, 0x45, 0x4E, 0x54, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_POLL_SENTINEL \"SDL_POLL_SENTINEL\"")]
        public static ReadOnlySpan<byte> SDL_HINT_POLL_SENTINEL => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x50, 0x4F, 0x4C, 0x4C, 0x5F, 0x53, 0x45, 0x4E, 0x54, 0x49, 0x4E, 0x45, 0x4C, 0x00 };

        [NativeTypeName("#define SDL_HINT_PREFERRED_LOCALES \"SDL_PREFERRED_LOCALES\"")]
        public static ReadOnlySpan<byte> SDL_HINT_PREFERRED_LOCALES => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x50, 0x52, 0x45, 0x46, 0x45, 0x52, 0x52, 0x45, 0x44, 0x5F, 0x4C, 0x4F, 0x43, 0x41, 0x4C, 0x45, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_QTWAYLAND_CONTENT_ORIENTATION \"SDL_QTWAYLAND_CONTENT_ORIENTATION\"")]
        public static ReadOnlySpan<byte> SDL_HINT_QTWAYLAND_CONTENT_ORIENTATION => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x51, 0x54, 0x57, 0x41, 0x59, 0x4C, 0x41, 0x4E, 0x44, 0x5F, 0x43, 0x4F, 0x4E, 0x54, 0x45, 0x4E, 0x54, 0x5F, 0x4F, 0x52, 0x49, 0x45, 0x4E, 0x54, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_QTWAYLAND_WINDOW_FLAGS \"SDL_QTWAYLAND_WINDOW_FLAGS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_QTWAYLAND_WINDOW_FLAGS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x51, 0x54, 0x57, 0x41, 0x59, 0x4C, 0x41, 0x4E, 0x44, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x5F, 0x46, 0x4C, 0x41, 0x47, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_BATCHING \"SDL_RENDER_BATCHING\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_BATCHING => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x42, 0x41, 0x54, 0x43, 0x48, 0x49, 0x4E, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_DIRECT3D11_DEBUG \"SDL_RENDER_DIRECT3D11_DEBUG\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_DIRECT3D11_DEBUG => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x44, 0x49, 0x52, 0x45, 0x43, 0x54, 0x33, 0x44, 0x31, 0x31, 0x5F, 0x44, 0x45, 0x42, 0x55, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_DIRECT3D_THREADSAFE \"SDL_RENDER_DIRECT3D_THREADSAFE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_DIRECT3D_THREADSAFE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x44, 0x49, 0x52, 0x45, 0x43, 0x54, 0x33, 0x44, 0x5F, 0x54, 0x48, 0x52, 0x45, 0x41, 0x44, 0x53, 0x41, 0x46, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_DRIVER \"SDL_RENDER_DRIVER\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_DRIVER => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x44, 0x52, 0x49, 0x56, 0x45, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_LOGICAL_SIZE_MODE \"SDL_RENDER_LOGICAL_SIZE_MODE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_LOGICAL_SIZE_MODE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x4C, 0x4F, 0x47, 0x49, 0x43, 0x41, 0x4C, 0x5F, 0x53, 0x49, 0x5A, 0x45, 0x5F, 0x4D, 0x4F, 0x44, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_OPENGL_SHADERS \"SDL_RENDER_OPENGL_SHADERS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_OPENGL_SHADERS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x4F, 0x50, 0x45, 0x4E, 0x47, 0x4C, 0x5F, 0x53, 0x48, 0x41, 0x44, 0x45, 0x52, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_SCALE_QUALITY \"SDL_RENDER_SCALE_QUALITY\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_SCALE_QUALITY => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x53, 0x43, 0x41, 0x4C, 0x45, 0x5F, 0x51, 0x55, 0x41, 0x4C, 0x49, 0x54, 0x59, 0x00 };

        [NativeTypeName("#define SDL_HINT_RENDER_VSYNC \"SDL_RENDER_VSYNC\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RENDER_VSYNC => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x4E, 0x44, 0x45, 0x52, 0x5F, 0x56, 0x53, 0x59, 0x4E, 0x43, 0x00 };

        [NativeTypeName("#define SDL_HINT_RETURN_KEY_HIDES_IME \"SDL_RETURN_KEY_HIDES_IME\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RETURN_KEY_HIDES_IME => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x45, 0x54, 0x55, 0x52, 0x4E, 0x5F, 0x4B, 0x45, 0x59, 0x5F, 0x48, 0x49, 0x44, 0x45, 0x53, 0x5F, 0x49, 0x4D, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_RPI_VIDEO_LAYER \"SDL_RPI_VIDEO_LAYER\"")]
        public static ReadOnlySpan<byte> SDL_HINT_RPI_VIDEO_LAYER => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x52, 0x50, 0x49, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x4C, 0x41, 0x59, 0x45, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_SCREENSAVER_INHIBIT_ACTIVITY_NAME \"SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME\"")]
        public static ReadOnlySpan<byte> SDL_HINT_SCREENSAVER_INHIBIT_ACTIVITY_NAME => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x53, 0x43, 0x52, 0x45, 0x45, 0x4E, 0x53, 0x41, 0x56, 0x45, 0x52, 0x5F, 0x49, 0x4E, 0x48, 0x49, 0x42, 0x49, 0x54, 0x5F, 0x41, 0x43, 0x54, 0x49, 0x56, 0x49, 0x54, 0x59, 0x5F, 0x4E, 0x41, 0x4D, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_THREAD_FORCE_REALTIME_TIME_CRITICAL \"SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL\"")]
        public static ReadOnlySpan<byte> SDL_HINT_THREAD_FORCE_REALTIME_TIME_CRITICAL => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x54, 0x48, 0x52, 0x45, 0x41, 0x44, 0x5F, 0x46, 0x4F, 0x52, 0x43, 0x45, 0x5F, 0x52, 0x45, 0x41, 0x4C, 0x54, 0x49, 0x4D, 0x45, 0x5F, 0x54, 0x49, 0x4D, 0x45, 0x5F, 0x43, 0x52, 0x49, 0x54, 0x49, 0x43, 0x41, 0x4C, 0x00 };

        [NativeTypeName("#define SDL_HINT_THREAD_PRIORITY_POLICY \"SDL_THREAD_PRIORITY_POLICY\"")]
        public static ReadOnlySpan<byte> SDL_HINT_THREAD_PRIORITY_POLICY => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x54, 0x48, 0x52, 0x45, 0x41, 0x44, 0x5F, 0x50, 0x52, 0x49, 0x4F, 0x52, 0x49, 0x54, 0x59, 0x5F, 0x50, 0x4F, 0x4C, 0x49, 0x43, 0x59, 0x00 };

        [NativeTypeName("#define SDL_HINT_THREAD_STACK_SIZE \"SDL_THREAD_STACK_SIZE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_THREAD_STACK_SIZE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x54, 0x48, 0x52, 0x45, 0x41, 0x44, 0x5F, 0x53, 0x54, 0x41, 0x43, 0x4B, 0x5F, 0x53, 0x49, 0x5A, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_TIMER_RESOLUTION \"SDL_TIMER_RESOLUTION\"")]
        public static ReadOnlySpan<byte> SDL_HINT_TIMER_RESOLUTION => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x54, 0x49, 0x4D, 0x45, 0x52, 0x5F, 0x52, 0x45, 0x53, 0x4F, 0x4C, 0x55, 0x54, 0x49, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_TOUCH_MOUSE_EVENTS \"SDL_TOUCH_MOUSE_EVENTS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_TOUCH_MOUSE_EVENTS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x54, 0x4F, 0x55, 0x43, 0x48, 0x5F, 0x4D, 0x4F, 0x55, 0x53, 0x45, 0x5F, 0x45, 0x56, 0x45, 0x4E, 0x54, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_TV_REMOTE_AS_JOYSTICK \"SDL_TV_REMOTE_AS_JOYSTICK\"")]
        public static ReadOnlySpan<byte> SDL_HINT_TV_REMOTE_AS_JOYSTICK => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x54, 0x56, 0x5F, 0x52, 0x45, 0x4D, 0x4F, 0x54, 0x45, 0x5F, 0x41, 0x53, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_ALLOW_SCREENSAVER \"SDL_VIDEO_ALLOW_SCREENSAVER\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_ALLOW_SCREENSAVER => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x41, 0x4C, 0x4C, 0x4F, 0x57, 0x5F, 0x53, 0x43, 0x52, 0x45, 0x45, 0x4E, 0x53, 0x41, 0x56, 0x45, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_DOUBLE_BUFFER \"SDL_VIDEO_DOUBLE_BUFFER\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_DOUBLE_BUFFER => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x44, 0x4F, 0x55, 0x42, 0x4C, 0x45, 0x5F, 0x42, 0x55, 0x46, 0x46, 0x45, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_EGL_ALLOW_TRANSPARENCY \"SDL_VIDEO_EGL_ALLOW_TRANSPARENCY\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_EGL_ALLOW_TRANSPARENCY => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x45, 0x47, 0x4C, 0x5F, 0x41, 0x4C, 0x4C, 0x4F, 0x57, 0x5F, 0x54, 0x52, 0x41, 0x4E, 0x53, 0x50, 0x41, 0x52, 0x45, 0x4E, 0x43, 0x59, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_EXTERNAL_CONTEXT \"SDL_VIDEO_EXTERNAL_CONTEXT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_EXTERNAL_CONTEXT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x45, 0x58, 0x54, 0x45, 0x52, 0x4E, 0x41, 0x4C, 0x5F, 0x43, 0x4F, 0x4E, 0x54, 0x45, 0x58, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_HIGHDPI_DISABLED \"SDL_VIDEO_HIGHDPI_DISABLED\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_HIGHDPI_DISABLED => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x48, 0x49, 0x47, 0x48, 0x44, 0x50, 0x49, 0x5F, 0x44, 0x49, 0x53, 0x41, 0x42, 0x4C, 0x45, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES \"SDL_VIDEO_MAC_FULLSCREEN_SPACES\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x4D, 0x41, 0x43, 0x5F, 0x46, 0x55, 0x4C, 0x4C, 0x53, 0x43, 0x52, 0x45, 0x45, 0x4E, 0x5F, 0x53, 0x50, 0x41, 0x43, 0x45, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS \"SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x4D, 0x49, 0x4E, 0x49, 0x4D, 0x49, 0x5A, 0x45, 0x5F, 0x4F, 0x4E, 0x5F, 0x46, 0x4F, 0x43, 0x55, 0x53, 0x5F, 0x4C, 0x4F, 0x53, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_WAYLAND_ALLOW_LIBDECOR \"SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_WAYLAND_ALLOW_LIBDECOR => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x57, 0x41, 0x59, 0x4C, 0x41, 0x4E, 0x44, 0x5F, 0x41, 0x4C, 0x4C, 0x4F, 0x57, 0x5F, 0x4C, 0x49, 0x42, 0x44, 0x45, 0x43, 0x4F, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT \"SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x5F, 0x53, 0x48, 0x41, 0x52, 0x45, 0x5F, 0x50, 0x49, 0x58, 0x45, 0x4C, 0x5F, 0x46, 0x4F, 0x52, 0x4D, 0x41, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_WIN_D3DCOMPILER \"SDL_VIDEO_WIN_D3DCOMPILER\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_WIN_D3DCOMPILER => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x57, 0x49, 0x4E, 0x5F, 0x44, 0x33, 0x44, 0x43, 0x4F, 0x4D, 0x50, 0x49, 0x4C, 0x45, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_X11_FORCE_EGL \"SDL_VIDEO_X11_FORCE_EGL\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_X11_FORCE_EGL => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x46, 0x4F, 0x52, 0x43, 0x45, 0x5F, 0x45, 0x47, 0x4C, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR \"SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x4E, 0x45, 0x54, 0x5F, 0x57, 0x4D, 0x5F, 0x42, 0x59, 0x50, 0x41, 0x53, 0x53, 0x5F, 0x43, 0x4F, 0x4D, 0x50, 0x4F, 0x53, 0x49, 0x54, 0x4F, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_X11_NET_WM_PING \"SDL_VIDEO_X11_NET_WM_PING\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_X11_NET_WM_PING => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x4E, 0x45, 0x54, 0x5F, 0x57, 0x4D, 0x5F, 0x50, 0x49, 0x4E, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_X11_WINDOW_VISUALID \"SDL_VIDEO_X11_WINDOW_VISUALID\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_X11_WINDOW_VISUALID => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x5F, 0x56, 0x49, 0x53, 0x55, 0x41, 0x4C, 0x49, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_X11_XINERAMA \"SDL_VIDEO_X11_XINERAMA\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_X11_XINERAMA => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x58, 0x49, 0x4E, 0x45, 0x52, 0x41, 0x4D, 0x41, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_X11_XRANDR \"SDL_VIDEO_X11_XRANDR\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_X11_XRANDR => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x58, 0x52, 0x41, 0x4E, 0x44, 0x52, 0x00 };

        [NativeTypeName("#define SDL_HINT_VIDEO_X11_XVIDMODE \"SDL_VIDEO_X11_XVIDMODE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_VIDEO_X11_XVIDMODE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x56, 0x49, 0x44, 0x45, 0x4F, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x58, 0x56, 0x49, 0x44, 0x4D, 0x4F, 0x44, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_WAVE_FACT_CHUNK \"SDL_WAVE_FACT_CHUNK\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WAVE_FACT_CHUNK => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x41, 0x56, 0x45, 0x5F, 0x46, 0x41, 0x43, 0x54, 0x5F, 0x43, 0x48, 0x55, 0x4E, 0x4B, 0x00 };

        [NativeTypeName("#define SDL_HINT_WAVE_RIFF_CHUNK_SIZE \"SDL_WAVE_RIFF_CHUNK_SIZE\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WAVE_RIFF_CHUNK_SIZE => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x41, 0x56, 0x45, 0x5F, 0x52, 0x49, 0x46, 0x46, 0x5F, 0x43, 0x48, 0x55, 0x4E, 0x4B, 0x5F, 0x53, 0x49, 0x5A, 0x45, 0x00 };

        [NativeTypeName("#define SDL_HINT_WAVE_TRUNCATION \"SDL_WAVE_TRUNCATION\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WAVE_TRUNCATION => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x41, 0x56, 0x45, 0x5F, 0x54, 0x52, 0x55, 0x4E, 0x43, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING \"SDL_WINDOWS_DISABLE_THREAD_NAMING\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x44, 0x49, 0x53, 0x41, 0x42, 0x4C, 0x45, 0x5F, 0x54, 0x48, 0x52, 0x45, 0x41, 0x44, 0x5F, 0x4E, 0x41, 0x4D, 0x49, 0x4E, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP \"SDL_WINDOWS_ENABLE_MESSAGELOOP\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x45, 0x4E, 0x41, 0x42, 0x4C, 0x45, 0x5F, 0x4D, 0x45, 0x53, 0x53, 0x41, 0x47, 0x45, 0x4C, 0x4F, 0x4F, 0x50, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS \"SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x46, 0x4F, 0x52, 0x43, 0x45, 0x5F, 0x4D, 0x55, 0x54, 0x45, 0x58, 0x5F, 0x43, 0x52, 0x49, 0x54, 0x49, 0x43, 0x41, 0x4C, 0x5F, 0x53, 0x45, 0x43, 0x54, 0x49, 0x4F, 0x4E, 0x53, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_FORCE_SEMAPHORE_KERNEL \"SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_FORCE_SEMAPHORE_KERNEL => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x46, 0x4F, 0x52, 0x43, 0x45, 0x5F, 0x53, 0x45, 0x4D, 0x41, 0x50, 0x48, 0x4F, 0x52, 0x45, 0x5F, 0x4B, 0x45, 0x52, 0x4E, 0x45, 0x4C, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_INTRESOURCE_ICON \"SDL_WINDOWS_INTRESOURCE_ICON\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_INTRESOURCE_ICON => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x49, 0x4E, 0x54, 0x52, 0x45, 0x53, 0x4F, 0x55, 0x52, 0x43, 0x45, 0x5F, 0x49, 0x43, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL \"SDL_WINDOWS_INTRESOURCE_ICON_SMALL\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x49, 0x4E, 0x54, 0x52, 0x45, 0x53, 0x4F, 0x55, 0x52, 0x43, 0x45, 0x5F, 0x49, 0x43, 0x4F, 0x4E, 0x5F, 0x53, 0x4D, 0x41, 0x4C, 0x4C, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4 \"SDL_WINDOWS_NO_CLOSE_ON_ALT_F4\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4 => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x4E, 0x4F, 0x5F, 0x43, 0x4C, 0x4F, 0x53, 0x45, 0x5F, 0x4F, 0x4E, 0x5F, 0x41, 0x4C, 0x54, 0x5F, 0x46, 0x34, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOWS_USE_D3D9EX \"SDL_WINDOWS_USE_D3D9EX\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOWS_USE_D3D9EX => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x53, 0x5F, 0x55, 0x53, 0x45, 0x5F, 0x44, 0x33, 0x44, 0x39, 0x45, 0x58, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN \"SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x5F, 0x46, 0x52, 0x41, 0x4D, 0x45, 0x5F, 0x55, 0x53, 0x41, 0x42, 0x4C, 0x45, 0x5F, 0x57, 0x48, 0x49, 0x4C, 0x45, 0x5F, 0x43, 0x55, 0x52, 0x53, 0x4F, 0x52, 0x5F, 0x48, 0x49, 0x44, 0x44, 0x45, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINDOW_NO_ACTIVATION_WHEN_SHOWN \"SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINDOW_NO_ACTIVATION_WHEN_SHOWN => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x44, 0x4F, 0x57, 0x5F, 0x4E, 0x4F, 0x5F, 0x41, 0x43, 0x54, 0x49, 0x56, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x5F, 0x57, 0x48, 0x45, 0x4E, 0x5F, 0x53, 0x48, 0x4F, 0x57, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINRT_HANDLE_BACK_BUTTON \"SDL_WINRT_HANDLE_BACK_BUTTON\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINRT_HANDLE_BACK_BUTTON => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x52, 0x54, 0x5F, 0x48, 0x41, 0x4E, 0x44, 0x4C, 0x45, 0x5F, 0x42, 0x41, 0x43, 0x4B, 0x5F, 0x42, 0x55, 0x54, 0x54, 0x4F, 0x4E, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINRT_PRIVACY_POLICY_LABEL \"SDL_WINRT_PRIVACY_POLICY_LABEL\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINRT_PRIVACY_POLICY_LABEL => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x52, 0x54, 0x5F, 0x50, 0x52, 0x49, 0x56, 0x41, 0x43, 0x59, 0x5F, 0x50, 0x4F, 0x4C, 0x49, 0x43, 0x59, 0x5F, 0x4C, 0x41, 0x42, 0x45, 0x4C, 0x00 };

        [NativeTypeName("#define SDL_HINT_WINRT_PRIVACY_POLICY_URL \"SDL_WINRT_PRIVACY_POLICY_URL\"")]
        public static ReadOnlySpan<byte> SDL_HINT_WINRT_PRIVACY_POLICY_URL => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x57, 0x49, 0x4E, 0x52, 0x54, 0x5F, 0x50, 0x52, 0x49, 0x56, 0x41, 0x43, 0x59, 0x5F, 0x50, 0x4F, 0x4C, 0x49, 0x43, 0x59, 0x5F, 0x55, 0x52, 0x4C, 0x00 };

        [NativeTypeName("#define SDL_HINT_X11_FORCE_OVERRIDE_REDIRECT \"SDL_X11_FORCE_OVERRIDE_REDIRECT\"")]
        public static ReadOnlySpan<byte> SDL_HINT_X11_FORCE_OVERRIDE_REDIRECT => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x58, 0x31, 0x31, 0x5F, 0x46, 0x4F, 0x52, 0x43, 0x45, 0x5F, 0x4F, 0x56, 0x45, 0x52, 0x52, 0x49, 0x44, 0x45, 0x5F, 0x52, 0x45, 0x44, 0x49, 0x52, 0x45, 0x43, 0x54, 0x00 };

        [NativeTypeName("#define SDL_HINT_XINPUT_ENABLED \"SDL_XINPUT_ENABLED\"")]
        public static ReadOnlySpan<byte> SDL_HINT_XINPUT_ENABLED => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x58, 0x49, 0x4E, 0x50, 0x55, 0x54, 0x5F, 0x45, 0x4E, 0x41, 0x42, 0x4C, 0x45, 0x44, 0x00 };

        [NativeTypeName("#define SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING \"SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING\"")]
        public static ReadOnlySpan<byte> SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x58, 0x49, 0x4E, 0x50, 0x55, 0x54, 0x5F, 0x55, 0x53, 0x45, 0x5F, 0x4F, 0x4C, 0x44, 0x5F, 0x4A, 0x4F, 0x59, 0x53, 0x54, 0x49, 0x43, 0x4B, 0x5F, 0x4D, 0x41, 0x50, 0x50, 0x49, 0x4E, 0x47, 0x00 };

        [NativeTypeName("#define SDL_HINT_AUDIO_INCLUDE_MONITORS \"SDL_AUDIO_INCLUDE_MONITORS\"")]
        public static ReadOnlySpan<byte> SDL_HINT_AUDIO_INCLUDE_MONITORS => new byte[] { 0x53, 0x44, 0x4C, 0x5F, 0x41, 0x55, 0x44, 0x49, 0x4F, 0x5F, 0x49, 0x4E, 0x43, 0x4C, 0x55, 0x44, 0x45, 0x5F, 0x4D, 0x4F, 0x4E, 0x49, 0x54, 0x4F, 0x52, 0x53, 0x00 };

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyboardFocus", ExactSpelling = true)]
        public static extern SDL_Window* GetKeyboardFocus();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyboardState", ExactSpelling = true)]
        [return: NativeTypeName("const Uint8 *")]
        public static extern byte* GetKeyboardState(int* numkeys);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetModState", ExactSpelling = true)]
        public static extern SDL_Keymod GetModState();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetModState", ExactSpelling = true)]
        public static extern void SetModState(SDL_Keymod modstate);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyFromScancode", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Keycode")]
        public static extern int GetKeyFromScancode(SDL_Scancode scancode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromKey", ExactSpelling = true)]
        public static extern SDL_Scancode GetScancodeFromKey([NativeTypeName("SDL_Keycode")] int key);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetScancodeName(SDL_Scancode scancode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromName", ExactSpelling = true)]
        public static extern SDL_Scancode GetScancodeFromName([NativeTypeName("const char *")] sbyte* name);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetKeyName([NativeTypeName("SDL_Keycode")] int key);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyFromName", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Keycode")]
        public static extern int GetKeyFromName([NativeTypeName("const char *")] sbyte* name);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_StartTextInput", ExactSpelling = true)]
        public static extern void StartTextInput();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsTextInputActive", ExactSpelling = true)]
        public static extern SDL_bool IsTextInputActive();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_StopTextInput", ExactSpelling = true)]
        public static extern void StopTextInput();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextInputRect", ExactSpelling = true)]
        public static extern void SetTextInputRect(SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasScreenKeyboardSupport", ExactSpelling = true)]
        public static extern SDL_bool HasScreenKeyboardSupport();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsScreenKeyboardShown", ExactSpelling = true)]
        public static extern SDL_bool IsScreenKeyboardShown(SDL_Window* window);

        [NativeTypeName("#define SDLK_SCANCODE_MASK (1<<30)")]
        public const int SDLK_SCANCODE_MASK = (1 << 30);

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
        public static extern void LogGetOutputFunction([NativeTypeName("SDL_LogOutputFunction *")] delegate* unmanaged[Cdecl]<void*, int, SDL_LogPriority, sbyte*, void>* callback, void** userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetOutputFunction", ExactSpelling = true)]
        public static extern void LogSetOutputFunction([NativeTypeName("SDL_LogOutputFunction")] delegate* unmanaged[Cdecl]<void*, int, SDL_LogPriority, sbyte*, void> callback, void* userdata);

        [NativeTypeName("#define SDL_MAX_LOG_MESSAGE 4096")]
        public const int SDL_MAX_LOG_MESSAGE = 4096;

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseFocus", ExactSpelling = true)]
        public static extern SDL_Window* GetMouseFocus();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseState", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint GetMouseState(int* x, int* y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGlobalMouseState", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint GetGlobalMouseState(int* x, int* y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRelativeMouseState", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint GetRelativeMouseState(int* x, int* y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WarpMouseInWindow", ExactSpelling = true)]
        public static extern void WarpMouseInWindow(SDL_Window* window, int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WarpMouseGlobal", ExactSpelling = true)]
        public static extern int WarpMouseGlobal(int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRelativeMouseMode", ExactSpelling = true)]
        public static extern int SetRelativeMouseMode(SDL_bool enabled);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CaptureMouse", ExactSpelling = true)]
        public static extern int CaptureMouse(SDL_bool enabled);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRelativeMouseMode", ExactSpelling = true)]
        public static extern SDL_bool GetRelativeMouseMode();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateCursor", ExactSpelling = true)]
        public static extern SDL_Cursor* CreateCursor([NativeTypeName("const Uint8 *")] byte* data, [NativeTypeName("const Uint8 *")] byte* mask, int w, int h, int hot_x, int hot_y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateColorCursor", ExactSpelling = true)]
        public static extern SDL_Cursor* CreateColorCursor(SDL_Surface* surface, int hot_x, int hot_y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateSystemCursor", ExactSpelling = true)]
        public static extern SDL_Cursor* CreateSystemCursor(SDL_SystemCursor id);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetCursor", ExactSpelling = true)]
        public static extern void SetCursor(SDL_Cursor* cursor);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCursor", ExactSpelling = true)]
        public static extern SDL_Cursor* GetCursor();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDefaultCursor", ExactSpelling = true)]
        public static extern SDL_Cursor* GetDefaultCursor();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeCursor", ExactSpelling = true)]
        public static extern void FreeCursor(SDL_Cursor* cursor);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowCursor", ExactSpelling = true)]
        public static extern int ShowCursor(int toggle);

        [NativeTypeName("#define SDL_BUTTON_LEFT 1")]
        public const int SDL_BUTTON_LEFT = 1;

        [NativeTypeName("#define SDL_BUTTON_MIDDLE 2")]
        public const int SDL_BUTTON_MIDDLE = 2;

        [NativeTypeName("#define SDL_BUTTON_RIGHT 3")]
        public const int SDL_BUTTON_RIGHT = 3;

        [NativeTypeName("#define SDL_BUTTON_X1 4")]
        public const int SDL_BUTTON_X1 = 4;

        [NativeTypeName("#define SDL_BUTTON_X2 5")]
        public const int SDL_BUTTON_X2 = 5;

        [NativeTypeName("#define SDL_BUTTON_LMASK SDL_BUTTON(SDL_BUTTON_LEFT)")]
        public const int SDL_BUTTON_LMASK = (1 << ((1) - 1));

        [NativeTypeName("#define SDL_BUTTON_MMASK SDL_BUTTON(SDL_BUTTON_MIDDLE)")]
        public const int SDL_BUTTON_MMASK = (1 << ((2) - 1));

        [NativeTypeName("#define SDL_BUTTON_RMASK SDL_BUTTON(SDL_BUTTON_RIGHT)")]
        public const int SDL_BUTTON_RMASK = (1 << ((3) - 1));

        [NativeTypeName("#define SDL_BUTTON_X1MASK SDL_BUTTON(SDL_BUTTON_X1)")]
        public const int SDL_BUTTON_X1MASK = (1 << ((4) - 1));

        [NativeTypeName("#define SDL_BUTTON_X2MASK SDL_BUTTON(SDL_BUTTON_X2)")]
        public const int SDL_BUTTON_X2MASK = (1 << ((5) - 1));

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPixelFormatName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetPixelFormatName([NativeTypeName("Uint32")] uint format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PixelFormatEnumToMasks", ExactSpelling = true)]
        public static extern SDL_bool PixelFormatEnumToMasks([NativeTypeName("Uint32")] uint format, int* bpp, [NativeTypeName("Uint32 *")] uint* Rmask, [NativeTypeName("Uint32 *")] uint* Gmask, [NativeTypeName("Uint32 *")] uint* Bmask, [NativeTypeName("Uint32 *")] uint* Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MasksToPixelFormatEnum", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint MasksToPixelFormatEnum(int bpp, [NativeTypeName("Uint32")] uint Rmask, [NativeTypeName("Uint32")] uint Gmask, [NativeTypeName("Uint32")] uint Bmask, [NativeTypeName("Uint32")] uint Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocFormat", ExactSpelling = true)]
        public static extern SDL_PixelFormat* AllocFormat([NativeTypeName("Uint32")] uint pixel_format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeFormat", ExactSpelling = true)]
        public static extern void FreeFormat(SDL_PixelFormat* format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocPalette", ExactSpelling = true)]
        public static extern SDL_Palette* AllocPalette(int ncolors);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetPixelFormatPalette", ExactSpelling = true)]
        public static extern int SetPixelFormatPalette(SDL_PixelFormat* format, SDL_Palette* palette);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetPaletteColors", ExactSpelling = true)]
        public static extern int SetPaletteColors(SDL_Palette* palette, [NativeTypeName("const SDL_Color *")] SDL_Color* colors, int firstcolor, int ncolors);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreePalette", ExactSpelling = true)]
        public static extern void FreePalette(SDL_Palette* palette);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MapRGB", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint MapRGB([NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, [NativeTypeName("Uint8")] byte r, [NativeTypeName("Uint8")] byte g, [NativeTypeName("Uint8")] byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MapRGBA", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint MapRGBA([NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, [NativeTypeName("Uint8")] byte r, [NativeTypeName("Uint8")] byte g, [NativeTypeName("Uint8")] byte b, [NativeTypeName("Uint8")] byte a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRGB", ExactSpelling = true)]
        public static extern void GetRGB([NativeTypeName("Uint32")] uint pixel, [NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, [NativeTypeName("Uint8 *")] byte* r, [NativeTypeName("Uint8 *")] byte* g, [NativeTypeName("Uint8 *")] byte* b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRGBA", ExactSpelling = true)]
        public static extern void GetRGBA([NativeTypeName("Uint32")] uint pixel, [NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, [NativeTypeName("Uint8 *")] byte* r, [NativeTypeName("Uint8 *")] byte* g, [NativeTypeName("Uint8 *")] byte* b, [NativeTypeName("Uint8 *")] byte* a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CalculateGammaRamp", ExactSpelling = true)]
        public static extern void CalculateGammaRamp(float gamma, [NativeTypeName("Uint16 *")] ushort* ramp);

        [NativeTypeName("#define SDL_ALPHA_OPAQUE 255")]
        public const int SDL_ALPHA_OPAQUE = 255;

        [NativeTypeName("#define SDL_ALPHA_TRANSPARENT 0")]
        public const int SDL_ALPHA_TRANSPARENT = 0;

        public static SDL_bool PointInRect([NativeTypeName("const SDL_Point *")] SDL_Point* p, [NativeTypeName("const SDL_Rect *")] SDL_Rect* r)
        {
            return ((p->x >= r->x) && (p->x < (r->x + r->w)) && (p->y >= r->y) && (p->y < (r->y + r->h))) ? SDL_TRUE : SDL_FALSE;
        }

        public static SDL_bool RectEmpty([NativeTypeName("const SDL_Rect *")] SDL_Rect* r)
        {
            return ((r == null) || (r->w <= 0) || (r->h <= 0)) ? SDL_TRUE : SDL_FALSE;
        }

        public static SDL_bool RectEquals([NativeTypeName("const SDL_Rect *")] SDL_Rect* a, [NativeTypeName("const SDL_Rect *")] SDL_Rect* b)
        {
            return ((a) != null && (b) != null && (a->x == b->x) && (a->y == b->y) && (a->w == b->w) && (a->h == b->h)) ? SDL_TRUE : SDL_FALSE;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasIntersection", ExactSpelling = true)]
        public static extern SDL_bool HasIntersection([NativeTypeName("const SDL_Rect *")] SDL_Rect* A, [NativeTypeName("const SDL_Rect *")] SDL_Rect* B);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRect", ExactSpelling = true)]
        public static extern SDL_bool IntersectRect([NativeTypeName("const SDL_Rect *")] SDL_Rect* A, [NativeTypeName("const SDL_Rect *")] SDL_Rect* B, SDL_Rect* result);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnionRect", ExactSpelling = true)]
        public static extern void UnionRect([NativeTypeName("const SDL_Rect *")] SDL_Rect* A, [NativeTypeName("const SDL_Rect *")] SDL_Rect* B, SDL_Rect* result);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnclosePoints", ExactSpelling = true)]
        public static extern SDL_bool EnclosePoints([NativeTypeName("const SDL_Point *")] SDL_Point* points, int count, [NativeTypeName("const SDL_Rect *")] SDL_Rect* clip, SDL_Rect* result);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRectAndLine", ExactSpelling = true)]
        public static extern SDL_bool IntersectRectAndLine([NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, int* X1, int* Y1, int* X2, int* Y2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumRenderDrivers", ExactSpelling = true)]
        public static extern int GetNumRenderDrivers();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDriverInfo", ExactSpelling = true)]
        public static extern int GetRenderDriverInfo(int index, SDL_RendererInfo* info);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowAndRenderer", ExactSpelling = true)]
        public static extern int CreateWindowAndRenderer(int width, int height, [NativeTypeName("Uint32")] uint window_flags, SDL_Window** window, SDL_Renderer** renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRenderer", ExactSpelling = true)]
        public static extern SDL_Renderer* CreateRenderer(SDL_Window* window, int index, [NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateSoftwareRenderer", ExactSpelling = true)]
        public static extern SDL_Renderer* CreateSoftwareRenderer(SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderer", ExactSpelling = true)]
        public static extern SDL_Renderer* GetRenderer(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererInfo", ExactSpelling = true)]
        public static extern int GetRendererInfo(SDL_Renderer* renderer, SDL_RendererInfo* info);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererOutputSize", ExactSpelling = true)]
        public static extern int GetRendererOutputSize(SDL_Renderer* renderer, int* w, int* h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTexture", ExactSpelling = true)]
        public static extern SDL_Texture* CreateTexture(SDL_Renderer* renderer, [NativeTypeName("Uint32")] uint format, int access, int w, int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTextureFromSurface", ExactSpelling = true)]
        public static extern SDL_Texture* CreateTextureFromSurface(SDL_Renderer* renderer, SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QueryTexture", ExactSpelling = true)]
        public static extern int QueryTexture(SDL_Texture* texture, [NativeTypeName("Uint32 *")] uint* format, int* access, int* w, int* h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureColorMod", ExactSpelling = true)]
        public static extern int SetTextureColorMod(SDL_Texture* texture, [NativeTypeName("Uint8")] byte r, [NativeTypeName("Uint8")] byte g, [NativeTypeName("Uint8")] byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureColorMod", ExactSpelling = true)]
        public static extern int GetTextureColorMod(SDL_Texture* texture, [NativeTypeName("Uint8 *")] byte* r, [NativeTypeName("Uint8 *")] byte* g, [NativeTypeName("Uint8 *")] byte* b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureAlphaMod", ExactSpelling = true)]
        public static extern int SetTextureAlphaMod(SDL_Texture* texture, [NativeTypeName("Uint8")] byte alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureAlphaMod", ExactSpelling = true)]
        public static extern int GetTextureAlphaMod(SDL_Texture* texture, [NativeTypeName("Uint8 *")] byte* alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureBlendMode", ExactSpelling = true)]
        public static extern int SetTextureBlendMode(SDL_Texture* texture, SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureBlendMode", ExactSpelling = true)]
        public static extern int GetTextureBlendMode(SDL_Texture* texture, SDL_BlendMode* blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureScaleMode", ExactSpelling = true)]
        public static extern int SetTextureScaleMode(SDL_Texture* texture, SDL_ScaleMode scaleMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureScaleMode", ExactSpelling = true)]
        public static extern int GetTextureScaleMode(SDL_Texture* texture, SDL_ScaleMode* scaleMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureUserData", ExactSpelling = true)]
        public static extern int SetTextureUserData(SDL_Texture* texture, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureUserData", ExactSpelling = true)]
        public static extern void* GetTextureUserData(SDL_Texture* texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateTexture", ExactSpelling = true)]
        public static extern int UpdateTexture(SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName("const void *")] void* pixels, int pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateYUVTexture", ExactSpelling = true)]
        public static extern int UpdateYUVTexture(SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName("const Uint8 *")] byte* Yplane, int Ypitch, [NativeTypeName("const Uint8 *")] byte* Uplane, int Upitch, [NativeTypeName("const Uint8 *")] byte* Vplane, int Vpitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateNVTexture", ExactSpelling = true)]
        public static extern int UpdateNVTexture(SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName("const Uint8 *")] byte* Yplane, int Ypitch, [NativeTypeName("const Uint8 *")] byte* UVplane, int UVpitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTexture", ExactSpelling = true)]
        public static extern int LockTexture(SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, void** pixels, int* pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTextureToSurface", ExactSpelling = true)]
        public static extern int LockTextureToSurface(SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, SDL_Surface** surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockTexture", ExactSpelling = true)]
        public static extern void UnlockTexture(SDL_Texture* texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderTargetSupported", ExactSpelling = true)]
        public static extern SDL_bool RenderTargetSupported(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderTarget", ExactSpelling = true)]
        public static extern int SetRenderTarget(SDL_Renderer* renderer, SDL_Texture* texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderTarget", ExactSpelling = true)]
        public static extern SDL_Texture* GetRenderTarget(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetLogicalSize", ExactSpelling = true)]
        public static extern int RenderSetLogicalSize(SDL_Renderer* renderer, int w, int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetLogicalSize", ExactSpelling = true)]
        public static extern void RenderGetLogicalSize(SDL_Renderer* renderer, int* w, int* h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetIntegerScale", ExactSpelling = true)]
        public static extern int RenderSetIntegerScale(SDL_Renderer* renderer, SDL_bool enable);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetIntegerScale", ExactSpelling = true)]
        public static extern SDL_bool RenderGetIntegerScale(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetViewport", ExactSpelling = true)]
        public static extern int RenderSetViewport(SDL_Renderer* renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetViewport", ExactSpelling = true)]
        public static extern void RenderGetViewport(SDL_Renderer* renderer, SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetClipRect", ExactSpelling = true)]
        public static extern int RenderSetClipRect(SDL_Renderer* renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetClipRect", ExactSpelling = true)]
        public static extern void RenderGetClipRect(SDL_Renderer* renderer, SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderIsClipEnabled", ExactSpelling = true)]
        public static extern SDL_bool RenderIsClipEnabled(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetScale", ExactSpelling = true)]
        public static extern int RenderSetScale(SDL_Renderer* renderer, float scaleX, float scaleY);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetScale", ExactSpelling = true)]
        public static extern void RenderGetScale(SDL_Renderer* renderer, float* scaleX, float* scaleY);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderWindowToLogical", ExactSpelling = true)]
        public static extern void RenderWindowToLogical(SDL_Renderer* renderer, int windowX, int windowY, float* logicalX, float* logicalY);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderLogicalToWindow", ExactSpelling = true)]
        public static extern void RenderLogicalToWindow(SDL_Renderer* renderer, float logicalX, float logicalY, int* windowX, int* windowY);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawColor", ExactSpelling = true)]
        public static extern int SetRenderDrawColor(SDL_Renderer* renderer, [NativeTypeName("Uint8")] byte r, [NativeTypeName("Uint8")] byte g, [NativeTypeName("Uint8")] byte b, [NativeTypeName("Uint8")] byte a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawColor", ExactSpelling = true)]
        public static extern int GetRenderDrawColor(SDL_Renderer* renderer, [NativeTypeName("Uint8 *")] byte* r, [NativeTypeName("Uint8 *")] byte* g, [NativeTypeName("Uint8 *")] byte* b, [NativeTypeName("Uint8 *")] byte* a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawBlendMode", ExactSpelling = true)]
        public static extern int SetRenderDrawBlendMode(SDL_Renderer* renderer, SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawBlendMode", ExactSpelling = true)]
        public static extern int GetRenderDrawBlendMode(SDL_Renderer* renderer, SDL_BlendMode* blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderClear", ExactSpelling = true)]
        public static extern int RenderClear(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoint", ExactSpelling = true)]
        public static extern int RenderDrawPoint(SDL_Renderer* renderer, int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoints", ExactSpelling = true)]
        public static extern int RenderDrawPoints(SDL_Renderer* renderer, [NativeTypeName("const SDL_Point *")] SDL_Point* points, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLine", ExactSpelling = true)]
        public static extern int RenderDrawLine(SDL_Renderer* renderer, int x1, int y1, int x2, int y2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLines", ExactSpelling = true)]
        public static extern int RenderDrawLines(SDL_Renderer* renderer, [NativeTypeName("const SDL_Point *")] SDL_Point* points, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRect", ExactSpelling = true)]
        public static extern int RenderDrawRect(SDL_Renderer* renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRects", ExactSpelling = true)]
        public static extern int RenderDrawRects(SDL_Renderer* renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRect", ExactSpelling = true)]
        public static extern int RenderFillRect(SDL_Renderer* renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRects", ExactSpelling = true)]
        public static extern int RenderFillRects(SDL_Renderer* renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy", ExactSpelling = true)]
        public static extern int RenderCopy(SDL_Renderer* renderer, SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx", ExactSpelling = true)]
        public static extern int RenderCopyEx(SDL_Renderer* renderer, SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect, [NativeTypeName("const double")] double angle, [NativeTypeName("const SDL_Point *")] SDL_Point* center, [NativeTypeName("const SDL_RendererFlip")] SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointF", ExactSpelling = true)]
        public static extern int RenderDrawPointF(SDL_Renderer* renderer, float x, float y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointsF", ExactSpelling = true)]
        public static extern int RenderDrawPointsF(SDL_Renderer* renderer, [NativeTypeName("const SDL_FPoint *")] SDL_FPoint* points, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLineF", ExactSpelling = true)]
        public static extern int RenderDrawLineF(SDL_Renderer* renderer, float x1, float y1, float x2, float y2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLinesF", ExactSpelling = true)]
        public static extern int RenderDrawLinesF(SDL_Renderer* renderer, [NativeTypeName("const SDL_FPoint *")] SDL_FPoint* points, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectF", ExactSpelling = true)]
        public static extern int RenderDrawRectF(SDL_Renderer* renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectsF", ExactSpelling = true)]
        public static extern int RenderDrawRectsF(SDL_Renderer* renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rects, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectF", ExactSpelling = true)]
        public static extern int RenderFillRectF(SDL_Renderer* renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectsF", ExactSpelling = true)]
        public static extern int RenderFillRectsF(SDL_Renderer* renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rects, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyF", ExactSpelling = true)]
        public static extern int RenderCopyF(SDL_Renderer* renderer, SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_FRect *")] SDL_FRect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF", ExactSpelling = true)]
        public static extern int RenderCopyExF(SDL_Renderer* renderer, SDL_Texture* texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_FRect *")] SDL_FRect* dstrect, [NativeTypeName("const double")] double angle, [NativeTypeName("const SDL_FPoint *")] SDL_FPoint* center, [NativeTypeName("const SDL_RendererFlip")] SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGeometry", ExactSpelling = true)]
        public static extern int RenderGeometry(SDL_Renderer* renderer, SDL_Texture* texture, [NativeTypeName("const SDL_Vertex *")] SDL_Vertex* vertices, int num_vertices, [NativeTypeName("const int *")] int* indices, int num_indices);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGeometryRaw", ExactSpelling = true)]
        public static extern int RenderGeometryRaw(SDL_Renderer* renderer, SDL_Texture* texture, [NativeTypeName("const float *")] float* xy, int xy_stride, [NativeTypeName("const int *")] int* color, int color_stride, [NativeTypeName("const float *")] float* uv, int uv_stride, int num_vertices, [NativeTypeName("const void *")] void* indices, int num_indices, int size_indices);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderReadPixels", ExactSpelling = true)]
        public static extern int RenderReadPixels(SDL_Renderer* renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName("Uint32")] uint format, void* pixels, int pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderPresent", ExactSpelling = true)]
        public static extern void RenderPresent(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyTexture", ExactSpelling = true)]
        public static extern void DestroyTexture(SDL_Texture* texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyRenderer", ExactSpelling = true)]
        public static extern void DestroyRenderer(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFlush", ExactSpelling = true)]
        public static extern int RenderFlush(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_BindTexture", ExactSpelling = true)]
        public static extern int GL_BindTexture(SDL_Texture* texture, float* texw, float* texh);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_UnbindTexture", ExactSpelling = true)]
        public static extern int GL_UnbindTexture(SDL_Texture* texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetMetalLayer", ExactSpelling = true)]
        public static extern void* RenderGetMetalLayer(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetMetalCommandEncoder", ExactSpelling = true)]
        public static extern void* RenderGetMetalCommandEncoder(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetVSync", ExactSpelling = true)]
        public static extern int RenderSetVSync(SDL_Renderer* renderer, int vsync);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFile", ExactSpelling = true)]
        public static extern SDL_RWops* RWFromFile([NativeTypeName("const char *")] sbyte* file, [NativeTypeName("const char *")] sbyte* mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFP", ExactSpelling = true)]
        public static extern SDL_RWops* RWFromFP(void* fp, SDL_bool autoclose);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromMem", ExactSpelling = true)]
        public static extern SDL_RWops* RWFromMem(void* mem, int size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromConstMem", ExactSpelling = true)]
        public static extern SDL_RWops* RWFromConstMem([NativeTypeName("const void *")] void* mem, int size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocRW", ExactSpelling = true)]
        public static extern SDL_RWops* AllocRW();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeRW", ExactSpelling = true)]
        public static extern void FreeRW(SDL_RWops* area);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWsize", ExactSpelling = true)]
        [return: NativeTypeName("Sint64")]
        public static extern long RWsize(SDL_RWops* context);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWseek", ExactSpelling = true)]
        [return: NativeTypeName("Sint64")]
        public static extern long RWseek(SDL_RWops* context, [NativeTypeName("Sint64")] long offset, int whence);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWtell", ExactSpelling = true)]
        [return: NativeTypeName("Sint64")]
        public static extern long RWtell(SDL_RWops* context);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWread", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint RWread(SDL_RWops* context, void* ptr, [NativeTypeName("size_t")] nuint size, [NativeTypeName("size_t")] nuint maxnum);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWwrite", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint RWwrite(SDL_RWops* context, [NativeTypeName("const void *")] void* ptr, [NativeTypeName("size_t")] nuint size, [NativeTypeName("size_t")] nuint num);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWclose", ExactSpelling = true)]
        public static extern int RWclose(SDL_RWops* context);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile_RW", ExactSpelling = true)]
        public static extern void* LoadFile_RW(SDL_RWops* src, [NativeTypeName("size_t *")] nuint* datasize, int freesrc);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile", ExactSpelling = true)]
        public static extern void* LoadFile([NativeTypeName("const char *")] sbyte* file, [NativeTypeName("size_t *")] nuint* datasize);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadU8", ExactSpelling = true)]
        [return: NativeTypeName("Uint8")]
        public static extern byte ReadU8(SDL_RWops* src);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE16", ExactSpelling = true)]
        [return: NativeTypeName("Uint16")]
        public static extern ushort ReadLE16(SDL_RWops* src);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE16", ExactSpelling = true)]
        [return: NativeTypeName("Uint16")]
        public static extern ushort ReadBE16(SDL_RWops* src);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE32", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint ReadLE32(SDL_RWops* src);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE32", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint ReadBE32(SDL_RWops* src);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE64", ExactSpelling = true)]
        [return: NativeTypeName("Uint64")]
        public static extern ulong ReadLE64(SDL_RWops* src);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE64", ExactSpelling = true)]
        [return: NativeTypeName("Uint64")]
        public static extern ulong ReadBE64(SDL_RWops* src);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteU8", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteU8(SDL_RWops* dst, [NativeTypeName("Uint8")] byte value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE16", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteLE16(SDL_RWops* dst, [NativeTypeName("Uint16")] ushort value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE16", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteBE16(SDL_RWops* dst, [NativeTypeName("Uint16")] ushort value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE32", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteLE32(SDL_RWops* dst, [NativeTypeName("Uint32")] uint value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE32", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteBE32(SDL_RWops* dst, [NativeTypeName("Uint32")] uint value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE64", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteLE64(SDL_RWops* dst, [NativeTypeName("Uint64")] ulong value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE64", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteBE64(SDL_RWops* dst, [NativeTypeName("Uint64")] ulong value);

        [NativeTypeName("#define SDL_RWOPS_UNKNOWN 0U")]
        public const uint SDL_RWOPS_UNKNOWN = 0U;

        [NativeTypeName("#define SDL_RWOPS_WINFILE 1U")]
        public const uint SDL_RWOPS_WINFILE = 1U;

        [NativeTypeName("#define SDL_RWOPS_STDFILE 2U")]
        public const uint SDL_RWOPS_STDFILE = 2U;

        [NativeTypeName("#define SDL_RWOPS_JNIFILE 3U")]
        public const uint SDL_RWOPS_JNIFILE = 3U;

        [NativeTypeName("#define SDL_RWOPS_MEMORY 4U")]
        public const uint SDL_RWOPS_MEMORY = 4U;

        [NativeTypeName("#define SDL_RWOPS_MEMORY_RO 5U")]
        public const uint SDL_RWOPS_MEMORY_RO = 5U;

        [NativeTypeName("#define RW_SEEK_SET 0")]
        public const int RW_SEEK_SET = 0;

        [NativeTypeName("#define RW_SEEK_CUR 1")]
        public const int RW_SEEK_CUR = 1;

        [NativeTypeName("#define RW_SEEK_END 2")]
        public const int RW_SEEK_END = 2;

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_malloc", ExactSpelling = true)]
        public static extern void* malloc([NativeTypeName("size_t")] nuint size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_calloc", ExactSpelling = true)]
        public static extern void* calloc([NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_realloc", ExactSpelling = true)]
        public static extern void* realloc(void* mem, [NativeTypeName("size_t")] nuint size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_free", ExactSpelling = true)]
        public static extern void free(void* mem);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMemoryFunctions", ExactSpelling = true)]
        public static extern void GetMemoryFunctions([NativeTypeName("SDL_malloc_func *")] delegate* unmanaged[Cdecl]<nuint, void*>* malloc_func, [NativeTypeName("SDL_calloc_func *")] delegate* unmanaged[Cdecl]<nuint, nuint, void*>* calloc_func, [NativeTypeName("SDL_realloc_func *")] delegate* unmanaged[Cdecl]<void*, nuint, void*>* realloc_func, [NativeTypeName("SDL_free_func *")] delegate* unmanaged[Cdecl]<void*, void>* free_func);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetMemoryFunctions", ExactSpelling = true)]
        public static extern int SetMemoryFunctions([NativeTypeName("SDL_malloc_func")] delegate* unmanaged[Cdecl]<nuint, void*> malloc_func, [NativeTypeName("SDL_calloc_func")] delegate* unmanaged[Cdecl]<nuint, nuint, void*> calloc_func, [NativeTypeName("SDL_realloc_func")] delegate* unmanaged[Cdecl]<void*, nuint, void*> realloc_func, [NativeTypeName("SDL_free_func")] delegate* unmanaged[Cdecl]<void*, void> free_func);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAllocations", ExactSpelling = true)]
        public static extern int GetNumAllocations();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_getenv", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* getenv([NativeTypeName("const char *")] sbyte* name);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_setenv", ExactSpelling = true)]
        public static extern int setenv([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* value, int overwrite);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_qsort", ExactSpelling = true)]
        public static extern void qsort(void* @base, [NativeTypeName("size_t")] nuint nmemb, [NativeTypeName("size_t")] nuint size, [NativeTypeName("int (*)(const void *, const void *)")] delegate* unmanaged[Cdecl]<void*, void*, int> compare);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_abs", ExactSpelling = true)]
        public static extern int abs(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isalpha", ExactSpelling = true)]
        public static extern int isalpha(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isalnum", ExactSpelling = true)]
        public static extern int isalnum(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isblank", ExactSpelling = true)]
        public static extern int isblank(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iscntrl", ExactSpelling = true)]
        public static extern int iscntrl(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isdigit", ExactSpelling = true)]
        public static extern int isdigit(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isxdigit", ExactSpelling = true)]
        public static extern int isxdigit(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ispunct", ExactSpelling = true)]
        public static extern int ispunct(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isspace", ExactSpelling = true)]
        public static extern int isspace(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isupper", ExactSpelling = true)]
        public static extern int isupper(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_islower", ExactSpelling = true)]
        public static extern int islower(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isprint", ExactSpelling = true)]
        public static extern int isprint(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_isgraph", ExactSpelling = true)]
        public static extern int isgraph(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_toupper", ExactSpelling = true)]
        public static extern int toupper(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_tolower", ExactSpelling = true)]
        public static extern int tolower(int x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_crc32", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint crc32([NativeTypeName("Uint32")] uint crc, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memset", ExactSpelling = true)]
        public static extern void* memset(void* dst, int c, [NativeTypeName("size_t")] nuint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memcpy", ExactSpelling = true)]
        public static extern void* memcpy(void* dst, [NativeTypeName("const void *")] void* src, [NativeTypeName("size_t")] nuint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memmove", ExactSpelling = true)]
        public static extern void* memmove(void* dst, [NativeTypeName("const void *")] void* src, [NativeTypeName("size_t")] nuint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_memcmp", ExactSpelling = true)]
        public static extern int memcmp([NativeTypeName("const void *")] void* s1, [NativeTypeName("const void *")] void* s2, [NativeTypeName("size_t")] nuint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcslen", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint wcslen([NativeTypeName("const wchar_t *")] ushort* wstr);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcslcpy", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint wcslcpy([NativeTypeName("wchar_t *")] ushort* dst, [NativeTypeName("const wchar_t *")] ushort* src, [NativeTypeName("size_t")] nuint maxlen);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcslcat", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint wcslcat([NativeTypeName("wchar_t *")] ushort* dst, [NativeTypeName("const wchar_t *")] ushort* src, [NativeTypeName("size_t")] nuint maxlen);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsdup", ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* wcsdup([NativeTypeName("const wchar_t *")] ushort* wstr);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsstr", ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* wcsstr([NativeTypeName("const wchar_t *")] ushort* haystack, [NativeTypeName("const wchar_t *")] ushort* needle);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcscmp", ExactSpelling = true)]
        public static extern int wcscmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsncmp", ExactSpelling = true)]
        public static extern int wcsncmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2, [NativeTypeName("size_t")] nuint maxlen);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcscasecmp", ExactSpelling = true)]
        public static extern int wcscasecmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_wcsncasecmp", ExactSpelling = true)]
        public static extern int wcsncasecmp([NativeTypeName("const wchar_t *")] ushort* str1, [NativeTypeName("const wchar_t *")] ushort* str2, [NativeTypeName("size_t")] nuint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlen", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint strlen([NativeTypeName("const char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlcpy", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint strlcpy([NativeTypeName("char *")] sbyte* dst, [NativeTypeName("const char *")] sbyte* src, [NativeTypeName("size_t")] nuint maxlen);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_utf8strlcpy", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint utf8strlcpy([NativeTypeName("char *")] sbyte* dst, [NativeTypeName("const char *")] sbyte* src, [NativeTypeName("size_t")] nuint dst_bytes);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlcat", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint strlcat([NativeTypeName("char *")] sbyte* dst, [NativeTypeName("const char *")] sbyte* src, [NativeTypeName("size_t")] nuint maxlen);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strdup", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strdup([NativeTypeName("const char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strrev", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strrev([NativeTypeName("char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strupr", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strupr([NativeTypeName("char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strlwr", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strlwr([NativeTypeName("char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strchr", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strchr([NativeTypeName("const char *")] sbyte* str, int c);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strrchr", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strrchr([NativeTypeName("const char *")] sbyte* str, int c);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strstr", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strstr([NativeTypeName("const char *")] sbyte* haystack, [NativeTypeName("const char *")] sbyte* needle);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtokr", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* strtokr([NativeTypeName("char *")] sbyte* s1, [NativeTypeName("const char *")] sbyte* s2, [NativeTypeName("char **")] sbyte** saveptr);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_utf8strlen", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint utf8strlen([NativeTypeName("const char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_itoa", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* itoa(int value, [NativeTypeName("char *")] sbyte* str, int radix);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_uitoa", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* uitoa([NativeTypeName("unsigned int")] uint value, [NativeTypeName("char *")] sbyte* str, int radix);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ltoa", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* ltoa([NativeTypeName("long")] int value, [NativeTypeName("char *")] sbyte* str, int radix);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ultoa", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* ultoa([NativeTypeName("unsigned long")] uint value, [NativeTypeName("char *")] sbyte* str, int radix);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_lltoa", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* lltoa([NativeTypeName("Sint64")] long value, [NativeTypeName("char *")] sbyte* str, int radix);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ulltoa", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* ulltoa([NativeTypeName("Uint64")] ulong value, [NativeTypeName("char *")] sbyte* str, int radix);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atoi", ExactSpelling = true)]
        public static extern int atoi([NativeTypeName("const char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atof", ExactSpelling = true)]
        public static extern double atof([NativeTypeName("const char *")] sbyte* str);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtol", ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int strtol([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("char **")] sbyte** endp, int @base);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtoul", ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint strtoul([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("char **")] sbyte** endp, int @base);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtoll", ExactSpelling = true)]
        [return: NativeTypeName("Sint64")]
        public static extern long strtoll([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("char **")] sbyte** endp, int @base);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtoull", ExactSpelling = true)]
        [return: NativeTypeName("Uint64")]
        public static extern ulong strtoull([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("char **")] sbyte** endp, int @base);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strtod", ExactSpelling = true)]
        public static extern double strtod([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("char **")] sbyte** endp);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strcmp", ExactSpelling = true)]
        public static extern int strcmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strncmp", ExactSpelling = true)]
        public static extern int strncmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2, [NativeTypeName("size_t")] nuint maxlen);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strcasecmp", ExactSpelling = true)]
        public static extern int strcasecmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_strncasecmp", ExactSpelling = true)]
        public static extern int strncasecmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2, [NativeTypeName("size_t")] nuint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sscanf", ExactSpelling = true)]
        public static extern int sscanf([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_vsscanf", ExactSpelling = true)]
        public static extern int vsscanf([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* ap);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_snprintf", ExactSpelling = true)]
        public static extern int snprintf([NativeTypeName("char *")] sbyte* text, [NativeTypeName("size_t")] nuint maxlen, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_vsnprintf", ExactSpelling = true)]
        public static extern int vsnprintf([NativeTypeName("char *")] sbyte* text, [NativeTypeName("size_t")] nuint maxlen, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* ap);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_asprintf", ExactSpelling = true)]
        public static extern int asprintf([NativeTypeName("char **")] sbyte** strp, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_vasprintf", ExactSpelling = true)]
        public static extern int vasprintf([NativeTypeName("char **")] sbyte** strp, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* ap);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_acos", ExactSpelling = true)]
        public static extern double acos(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_acosf", ExactSpelling = true)]
        public static extern float acosf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_asin", ExactSpelling = true)]
        public static extern double asin(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_asinf", ExactSpelling = true)]
        public static extern float asinf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atan", ExactSpelling = true)]
        public static extern double atan(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atanf", ExactSpelling = true)]
        public static extern float atanf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atan2", ExactSpelling = true)]
        public static extern double atan2(double y, double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_atan2f", ExactSpelling = true)]
        public static extern float atan2f(float y, float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ceil", ExactSpelling = true)]
        public static extern double ceil(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ceilf", ExactSpelling = true)]
        public static extern float ceilf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_copysign", ExactSpelling = true)]
        public static extern double copysign(double x, double y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_copysignf", ExactSpelling = true)]
        public static extern float copysignf(float x, float y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_cos", ExactSpelling = true)]
        public static extern double cos(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_cosf", ExactSpelling = true)]
        public static extern float cosf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_exp", ExactSpelling = true)]
        public static extern double exp(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_expf", ExactSpelling = true)]
        public static extern float expf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fabs", ExactSpelling = true)]
        public static extern double fabs(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fabsf", ExactSpelling = true)]
        public static extern float fabsf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_floor", ExactSpelling = true)]
        public static extern double floor(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_floorf", ExactSpelling = true)]
        public static extern float floorf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_trunc", ExactSpelling = true)]
        public static extern double trunc(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_truncf", ExactSpelling = true)]
        public static extern float truncf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fmod", ExactSpelling = true)]
        public static extern double fmod(double x, double y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_fmodf", ExactSpelling = true)]
        public static extern float fmodf(float x, float y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_log", ExactSpelling = true)]
        public static extern double log(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_logf", ExactSpelling = true)]
        public static extern float logf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_log10", ExactSpelling = true)]
        public static extern double log10(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_log10f", ExactSpelling = true)]
        public static extern float log10f(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_pow", ExactSpelling = true)]
        public static extern double pow(double x, double y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_powf", ExactSpelling = true)]
        public static extern float powf(float x, float y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_round", ExactSpelling = true)]
        public static extern double round(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_roundf", ExactSpelling = true)]
        public static extern float roundf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_lround", ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int lround(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_lroundf", ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int lroundf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_scalbn", ExactSpelling = true)]
        public static extern double scalbn(double x, int n);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_scalbnf", ExactSpelling = true)]
        public static extern float scalbnf(float x, int n);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sin", ExactSpelling = true)]
        public static extern double sin(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sinf", ExactSpelling = true)]
        public static extern float sinf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sqrt", ExactSpelling = true)]
        public static extern double sqrt(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_sqrtf", ExactSpelling = true)]
        public static extern float sqrtf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_tan", ExactSpelling = true)]
        public static extern double tan(double x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_tanf", ExactSpelling = true)]
        public static extern float tanf(float x);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv_open", ExactSpelling = true)]
        [return: NativeTypeName("SDL_iconv_t")]
        public static extern _SDL_iconv_t* iconv_open([NativeTypeName("const char *")] sbyte* tocode, [NativeTypeName("const char *")] sbyte* fromcode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv_close", ExactSpelling = true)]
        public static extern int iconv_close([NativeTypeName("SDL_iconv_t")] _SDL_iconv_t* cd);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint iconv([NativeTypeName("SDL_iconv_t")] _SDL_iconv_t* cd, [NativeTypeName("const char **")] sbyte** inbuf, [NativeTypeName("size_t *")] nuint* inbytesleft, [NativeTypeName("char **")] sbyte** outbuf, [NativeTypeName("size_t *")] nuint* outbytesleft);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iconv_string", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* iconv_string([NativeTypeName("const char *")] sbyte* tocode, [NativeTypeName("const char *")] sbyte* fromcode, [NativeTypeName("const char *")] sbyte* inbuf, [NativeTypeName("size_t")] nuint inbytesleft);

        [NativeTypeName("#define SDL_MAX_SINT8 ((Sint8)0x7F)")]
        public const sbyte SDL_MAX_SINT8 = ((sbyte)(0x7F));

        [NativeTypeName("#define SDL_MIN_SINT8 ((Sint8)(~0x7F))")]
        public const sbyte SDL_MIN_SINT8 = ((sbyte)(~0x7F));

        [NativeTypeName("#define SDL_MAX_UINT8 ((Uint8)0xFF)")]
        public const byte SDL_MAX_UINT8 = ((byte)(0xFF));

        [NativeTypeName("#define SDL_MIN_UINT8 ((Uint8)0x00)")]
        public const byte SDL_MIN_UINT8 = ((byte)(0x00));

        [NativeTypeName("#define SDL_MAX_SINT16 ((Sint16)0x7FFF)")]
        public const short SDL_MAX_SINT16 = ((short)(0x7FFF));

        [NativeTypeName("#define SDL_MIN_SINT16 ((Sint16)(~0x7FFF))")]
        public const short SDL_MIN_SINT16 = ((short)(~0x7FFF));

        [NativeTypeName("#define SDL_MAX_UINT16 ((Uint16)0xFFFF)")]
        public const ushort SDL_MAX_UINT16 = ((ushort)(0xFFFF));

        [NativeTypeName("#define SDL_MIN_UINT16 ((Uint16)0x0000)")]
        public const ushort SDL_MIN_UINT16 = ((ushort)(0x0000));

        [NativeTypeName("#define SDL_MAX_SINT32 ((Sint32)0x7FFFFFFF)")]
        public const int SDL_MAX_SINT32 = ((int)(0x7FFFFFFF));

        [NativeTypeName("#define SDL_MIN_SINT32 ((Sint32)(~0x7FFFFFFF))")]
        public const int SDL_MIN_SINT32 = ((int)(~0x7FFFFFFF));

        [NativeTypeName("#define SDL_MAX_UINT32 ((Uint32)0xFFFFFFFFu)")]
        public const uint SDL_MAX_UINT32 = ((uint)(0xFFFFFFFFU));

        [NativeTypeName("#define SDL_MIN_UINT32 ((Uint32)0x00000000)")]
        public const uint SDL_MIN_UINT32 = ((uint)(0x00000000));

        [NativeTypeName("#define SDL_MAX_SINT64 ((Sint64)0x7FFFFFFFFFFFFFFFll)")]
        public const long SDL_MAX_SINT64 = ((long)(0x7FFFFFFFFFFFFFFFL));

        [NativeTypeName("#define SDL_MIN_SINT64 ((Sint64)(~0x7FFFFFFFFFFFFFFFll))")]
        public const long SDL_MIN_SINT64 = ((long)(~0x7FFFFFFFFFFFFFFFL));

        [NativeTypeName("#define SDL_MAX_UINT64 ((Uint64)0xFFFFFFFFFFFFFFFFull)")]
        public const ulong SDL_MAX_UINT64 = ((ulong)(0xFFFFFFFFFFFFFFFFUL));

        [NativeTypeName("#define SDL_MIN_UINT64 ((Uint64)(0x0000000000000000ull))")]
        public const ulong SDL_MIN_UINT64 = ((ulong)(0x0000000000000000UL));

        [NativeTypeName("#define SDL_PRIs64 \"I64d\"")]
        public static ReadOnlySpan<byte> SDL_PRIs64 => new byte[] { 0x49, 0x36, 0x34, 0x64, 0x00 };

        [NativeTypeName("#define SDL_PRIu64 \"I64u\"")]
        public static ReadOnlySpan<byte> SDL_PRIu64 => new byte[] { 0x49, 0x36, 0x34, 0x75, 0x00 };

        [NativeTypeName("#define SDL_PRIx64 \"I64x\"")]
        public static ReadOnlySpan<byte> SDL_PRIx64 => new byte[] { 0x49, 0x36, 0x34, 0x78, 0x00 };

        [NativeTypeName("#define SDL_PRIX64 \"I64X\"")]
        public static ReadOnlySpan<byte> SDL_PRIX64 => new byte[] { 0x49, 0x36, 0x34, 0x58, 0x00 };

        [NativeTypeName("#define SDL_PRIs32 \"d\"")]
        public static ReadOnlySpan<byte> SDL_PRIs32 => new byte[] { 0x64, 0x00 };

        [NativeTypeName("#define SDL_PRIu32 \"u\"")]
        public static ReadOnlySpan<byte> SDL_PRIu32 => new byte[] { 0x75, 0x00 };

        [NativeTypeName("#define SDL_PRIx32 \"x\"")]
        public static ReadOnlySpan<byte> SDL_PRIx32 => new byte[] { 0x78, 0x00 };

        [NativeTypeName("#define SDL_PRIX32 \"X\"")]
        public static ReadOnlySpan<byte> SDL_PRIX32 => new byte[] { 0x58, 0x00 };

        [NativeTypeName("#define M_PI 3.14159265358979323846264338327950288")]
        public const double M_PI = 3.14159265358979323846264338327950288;

        [NativeTypeName("#define SDL_ICONV_ERROR (size_t)-1")]
        public const nuint SDL_ICONV_ERROR = unchecked((uint)(-1));

        [NativeTypeName("#define SDL_ICONV_E2BIG (size_t)-2")]
        public const nuint SDL_ICONV_E2BIG = unchecked((uint)(-2));

        [NativeTypeName("#define SDL_ICONV_EILSEQ (size_t)-3")]
        public const nuint SDL_ICONV_EILSEQ = unchecked((uint)(-3));

        [NativeTypeName("#define SDL_ICONV_EINVAL (size_t)-4")]
        public const nuint SDL_ICONV_EINVAL = unchecked((uint)(-4));

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurface", ExactSpelling = true)]
        public static extern SDL_Surface* CreateRGBSurface([NativeTypeName("Uint32")] uint flags, int width, int height, int depth, [NativeTypeName("Uint32")] uint Rmask, [NativeTypeName("Uint32")] uint Gmask, [NativeTypeName("Uint32")] uint Bmask, [NativeTypeName("Uint32")] uint Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceWithFormat", ExactSpelling = true)]
        public static extern SDL_Surface* CreateRGBSurfaceWithFormat([NativeTypeName("Uint32")] uint flags, int width, int height, int depth, [NativeTypeName("Uint32")] uint format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceFrom", ExactSpelling = true)]
        public static extern SDL_Surface* CreateRGBSurfaceFrom(void* pixels, int width, int height, int depth, int pitch, [NativeTypeName("Uint32")] uint Rmask, [NativeTypeName("Uint32")] uint Gmask, [NativeTypeName("Uint32")] uint Bmask, [NativeTypeName("Uint32")] uint Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceWithFormatFrom", ExactSpelling = true)]
        public static extern SDL_Surface* CreateRGBSurfaceWithFormatFrom(void* pixels, int width, int height, int depth, int pitch, [NativeTypeName("Uint32")] uint format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeSurface", ExactSpelling = true)]
        public static extern void FreeSurface(SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfacePalette", ExactSpelling = true)]
        public static extern int SetSurfacePalette(SDL_Surface* surface, SDL_Palette* palette);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockSurface", ExactSpelling = true)]
        public static extern int LockSurface(SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockSurface", ExactSpelling = true)]
        public static extern void UnlockSurface(SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadBMP_RW", ExactSpelling = true)]
        public static extern SDL_Surface* LoadBMP_RW(SDL_RWops* src, int freesrc);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SaveBMP_RW", ExactSpelling = true)]
        public static extern int SaveBMP_RW(SDL_Surface* surface, SDL_RWops* dst, int freedst);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceRLE", ExactSpelling = true)]
        public static extern int SetSurfaceRLE(SDL_Surface* surface, int flag);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSurfaceRLE", ExactSpelling = true)]
        public static extern SDL_bool HasSurfaceRLE(SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetColorKey", ExactSpelling = true)]
        public static extern int SetColorKey(SDL_Surface* surface, int flag, [NativeTypeName("Uint32")] uint key);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasColorKey", ExactSpelling = true)]
        public static extern SDL_bool HasColorKey(SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetColorKey", ExactSpelling = true)]
        public static extern int GetColorKey(SDL_Surface* surface, [NativeTypeName("Uint32 *")] uint* key);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceColorMod", ExactSpelling = true)]
        public static extern int SetSurfaceColorMod(SDL_Surface* surface, [NativeTypeName("Uint8")] byte r, [NativeTypeName("Uint8")] byte g, [NativeTypeName("Uint8")] byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceColorMod", ExactSpelling = true)]
        public static extern int GetSurfaceColorMod(SDL_Surface* surface, [NativeTypeName("Uint8 *")] byte* r, [NativeTypeName("Uint8 *")] byte* g, [NativeTypeName("Uint8 *")] byte* b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceAlphaMod", ExactSpelling = true)]
        public static extern int SetSurfaceAlphaMod(SDL_Surface* surface, [NativeTypeName("Uint8")] byte alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceAlphaMod", ExactSpelling = true)]
        public static extern int GetSurfaceAlphaMod(SDL_Surface* surface, [NativeTypeName("Uint8 *")] byte* alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceBlendMode", ExactSpelling = true)]
        public static extern int SetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceBlendMode", ExactSpelling = true)]
        public static extern int GetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode* blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipRect", ExactSpelling = true)]
        public static extern SDL_bool SetClipRect(SDL_Surface* surface, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipRect", ExactSpelling = true)]
        public static extern void GetClipRect(SDL_Surface* surface, SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DuplicateSurface", ExactSpelling = true)]
        public static extern SDL_Surface* DuplicateSurface(SDL_Surface* surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurface", ExactSpelling = true)]
        public static extern SDL_Surface* ConvertSurface(SDL_Surface* src, [NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* fmt, [NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurfaceFormat", ExactSpelling = true)]
        public static extern SDL_Surface* ConvertSurfaceFormat(SDL_Surface* src, [NativeTypeName("Uint32")] uint pixel_format, [NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertPixels", ExactSpelling = true)]
        public static extern int ConvertPixels(int width, int height, [NativeTypeName("Uint32")] uint src_format, [NativeTypeName("const void *")] void* src, int src_pitch, [NativeTypeName("Uint32")] uint dst_format, void* dst, int dst_pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PremultiplyAlpha", ExactSpelling = true)]
        public static extern int PremultiplyAlpha(int width, int height, [NativeTypeName("Uint32")] uint src_format, [NativeTypeName("const void *")] void* src, int src_pitch, [NativeTypeName("Uint32")] uint dst_format, void* dst, int dst_pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRect", ExactSpelling = true)]
        public static extern int FillRect(SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName("Uint32")] uint color);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRects", ExactSpelling = true)]
        public static extern int FillRects(SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int count, [NativeTypeName("Uint32")] uint color);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit", ExactSpelling = true)]
        public static extern int UpperBlit(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlit", ExactSpelling = true)]
        public static extern int LowerBlit(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretch", ExactSpelling = true)]
        public static extern int SoftStretch(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretchLinear", ExactSpelling = true)]
        public static extern int SoftStretchLinear(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled", ExactSpelling = true)]
        public static extern int UpperBlitScaled(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlitScaled", ExactSpelling = true)]
        public static extern int LowerBlitScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetYUVConversionMode", ExactSpelling = true)]
        public static extern void SetYUVConversionMode(SDL_YUV_CONVERSION_MODE mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetYUVConversionMode", ExactSpelling = true)]
        public static extern SDL_YUV_CONVERSION_MODE GetYUVConversionMode();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetYUVConversionModeForResolution", ExactSpelling = true)]
        public static extern SDL_YUV_CONVERSION_MODE GetYUVConversionModeForResolution(int width, int height);

        [NativeTypeName("#define SDL_SWSURFACE 0")]
        public const int SDL_SWSURFACE = 0;

        [NativeTypeName("#define SDL_PREALLOC 0x00000001")]
        public const int SDL_PREALLOC = 0x00000001;

        [NativeTypeName("#define SDL_RLEACCEL 0x00000002")]
        public const int SDL_RLEACCEL = 0x00000002;

        [NativeTypeName("#define SDL_DONTFREE 0x00000004")]
        public const int SDL_DONTFREE = 0x00000004;

        [NativeTypeName("#define SDL_SIMD_ALIGNED 0x00000008")]
        public const int SDL_SIMD_ALIGNED = 0x00000008;

        [NativeTypeName("#define SDL_BlitSurface SDL_UpperBlit")]
        public static readonly delegate*<SDL_Surface*, SDL_Rect*, SDL_Surface*, SDL_Rect*, int> Blit = &UpperBlit;

        [NativeTypeName("#define SDL_BlitScaled SDL_UpperBlitScaled")]
        public static readonly delegate*<SDL_Surface*, SDL_Rect*, SDL_Surface*, SDL_Rect*, int> BlitScaled = &UpperBlitScaled;

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowsMessageHook", ExactSpelling = true)]
        public static extern void SetWindowsMessageHook([NativeTypeName("SDL_WindowsMessageHook")] delegate* unmanaged[Cdecl]<void*, void*, uint, ulong, long, void> callback, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Direct3D9GetAdapterIndex", ExactSpelling = true)]
        public static extern int Direct3D9GetAdapterIndex(int displayIndex);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D9Device", ExactSpelling = true)]
        public static extern IDirect3DDevice9* RenderGetD3D9Device(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D11Device", ExactSpelling = true)]
        public static extern ID3D11Device* RenderGetD3D11Device(SDL_Renderer* renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DXGIGetOutputInfo", ExactSpelling = true)]
        public static extern SDL_bool DXGIGetOutputInfo(int displayIndex, int* adapterIndex, int* outputIndex);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsTablet", ExactSpelling = true)]
        public static extern SDL_bool IsTablet();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationWillTerminate", ExactSpelling = true)]
        public static extern void OnApplicationWillTerminate();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationDidReceiveMemoryWarning", ExactSpelling = true)]
        public static extern void OnApplicationDidReceiveMemoryWarning();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationWillResignActive", ExactSpelling = true)]
        public static extern void OnApplicationWillResignActive();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationDidEnterBackground", ExactSpelling = true)]
        public static extern void OnApplicationDidEnterBackground();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationWillEnterForeground", ExactSpelling = true)]
        public static extern void OnApplicationWillEnterForeground();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationDidBecomeActive", ExactSpelling = true)]
        public static extern void OnApplicationDidBecomeActive();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVersion", ExactSpelling = true)]
        public static extern void GetVersion(SDL_version* ver);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevision", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetRevision();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevisionNumber", ExactSpelling = true)]
        public static extern int GetRevisionNumber();

        [NativeTypeName("#define SDL_MAJOR_VERSION 2")]
        public const int SDL_MAJOR_VERSION = 2;

        [NativeTypeName("#define SDL_MINOR_VERSION 0")]
        public const int SDL_MINOR_VERSION = 0;

        [NativeTypeName("#define SDL_PATCHLEVEL 18")]
        public const int SDL_PATCHLEVEL = 18;

        [NativeTypeName("#define SDL_COMPILEDVERSION SDL_VERSIONNUM(SDL_MAJOR_VERSION, SDL_MINOR_VERSION, SDL_PATCHLEVEL)")]
        public const int SDL_COMPILEDVERSION = ((2) * 1000 + (0) * 100 + (18));

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDrivers", ExactSpelling = true)]
        public static extern int GetNumVideoDrivers();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVideoDriver", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetVideoDriver(int index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoInit", ExactSpelling = true)]
        public static extern int VideoInit([NativeTypeName("const char *")] sbyte* driver_name);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoQuit", ExactSpelling = true)]
        public static extern void VideoQuit();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentVideoDriver", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetCurrentVideoDriver();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDisplays", ExactSpelling = true)]
        public static extern int GetNumVideoDisplays();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDisplayName(int displayIndex);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayBounds", ExactSpelling = true)]
        public static extern int GetDisplayBounds(int displayIndex, SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayUsableBounds", ExactSpelling = true)]
        public static extern int GetDisplayUsableBounds(int displayIndex, SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayDPI", ExactSpelling = true)]
        public static extern int GetDisplayDPI(int displayIndex, float* ddpi, float* hdpi, float* vdpi);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayOrientation", ExactSpelling = true)]
        public static extern SDL_DisplayOrientation GetDisplayOrientation(int displayIndex);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumDisplayModes", ExactSpelling = true)]
        public static extern int GetNumDisplayModes(int displayIndex);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayMode", ExactSpelling = true)]
        public static extern int GetDisplayMode(int displayIndex, int modeIndex, SDL_DisplayMode* mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDesktopDisplayMode", ExactSpelling = true)]
        public static extern int GetDesktopDisplayMode(int displayIndex, SDL_DisplayMode* mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentDisplayMode", ExactSpelling = true)]
        public static extern int GetCurrentDisplayMode(int displayIndex, SDL_DisplayMode* mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClosestDisplayMode", ExactSpelling = true)]
        public static extern SDL_DisplayMode* GetClosestDisplayMode(int displayIndex, [NativeTypeName("const SDL_DisplayMode *")] SDL_DisplayMode* mode, SDL_DisplayMode* closest);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayIndex", ExactSpelling = true)]
        public static extern int GetWindowDisplayIndex(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowDisplayMode", ExactSpelling = true)]
        public static extern int SetWindowDisplayMode(SDL_Window* window, [NativeTypeName("const SDL_DisplayMode *")] SDL_DisplayMode* mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayMode", ExactSpelling = true)]
        public static extern int GetWindowDisplayMode(SDL_Window* window, SDL_DisplayMode* mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowICCProfile", ExactSpelling = true)]
        public static extern void* GetWindowICCProfile(SDL_Window* window, [NativeTypeName("size_t *")] nuint* size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPixelFormat", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint GetWindowPixelFormat(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindow", ExactSpelling = true)]
        public static extern SDL_Window* CreateWindow([NativeTypeName("const char *")] sbyte* title, int x, int y, int w, int h, [NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowFrom", ExactSpelling = true)]
        public static extern SDL_Window* CreateWindowFrom([NativeTypeName("const void *")] void* data);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowID", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint GetWindowID(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFromID", ExactSpelling = true)]
        public static extern SDL_Window* GetWindowFromID([NativeTypeName("Uint32")] uint id);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFlags", ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint GetWindowFlags(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowTitle", ExactSpelling = true)]
        public static extern void SetWindowTitle(SDL_Window* window, [NativeTypeName("const char *")] sbyte* title);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowTitle", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetWindowTitle(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowIcon", ExactSpelling = true)]
        public static extern void SetWindowIcon(SDL_Window* window, SDL_Surface* icon);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowData", ExactSpelling = true)]
        public static extern void* SetWindowData(SDL_Window* window, [NativeTypeName("const char *")] sbyte* name, void* userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowData", ExactSpelling = true)]
        public static extern void* GetWindowData(SDL_Window* window, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowPosition", ExactSpelling = true)]
        public static extern void SetWindowPosition(SDL_Window* window, int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPosition", ExactSpelling = true)]
        public static extern void GetWindowPosition(SDL_Window* window, int* x, int* y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowSize", ExactSpelling = true)]
        public static extern void SetWindowSize(SDL_Window* window, int w, int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSize", ExactSpelling = true)]
        public static extern void GetWindowSize(SDL_Window* window, int* w, int* h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBordersSize", ExactSpelling = true)]
        public static extern int GetWindowBordersSize(SDL_Window* window, int* top, int* left, int* bottom, int* right);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMinimumSize", ExactSpelling = true)]
        public static extern void SetWindowMinimumSize(SDL_Window* window, int min_w, int min_h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMinimumSize", ExactSpelling = true)]
        public static extern void GetWindowMinimumSize(SDL_Window* window, int* w, int* h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMaximumSize", ExactSpelling = true)]
        public static extern void SetWindowMaximumSize(SDL_Window* window, int max_w, int max_h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMaximumSize", ExactSpelling = true)]
        public static extern void GetWindowMaximumSize(SDL_Window* window, int* w, int* h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBordered", ExactSpelling = true)]
        public static extern void SetWindowBordered(SDL_Window* window, SDL_bool bordered);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowResizable", ExactSpelling = true)]
        public static extern void SetWindowResizable(SDL_Window* window, SDL_bool resizable);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowAlwaysOnTop", ExactSpelling = true)]
        public static extern void SetWindowAlwaysOnTop(SDL_Window* window, SDL_bool on_top);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowWindow", ExactSpelling = true)]
        public static extern void ShowWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HideWindow", ExactSpelling = true)]
        public static extern void HideWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RaiseWindow", ExactSpelling = true)]
        public static extern void RaiseWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MaximizeWindow", ExactSpelling = true)]
        public static extern void MaximizeWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MinimizeWindow", ExactSpelling = true)]
        public static extern void MinimizeWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RestoreWindow", ExactSpelling = true)]
        public static extern void RestoreWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowFullscreen", ExactSpelling = true)]
        public static extern int SetWindowFullscreen(SDL_Window* window, [NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSurface", ExactSpelling = true)]
        public static extern SDL_Surface* GetWindowSurface(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurface", ExactSpelling = true)]
        public static extern int UpdateWindowSurface(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurfaceRects", ExactSpelling = true)]
        public static extern int UpdateWindowSurfaceRects(SDL_Window* window, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int numrects);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGrab", ExactSpelling = true)]
        public static extern void SetWindowGrab(SDL_Window* window, SDL_bool grabbed);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowKeyboardGrab", ExactSpelling = true)]
        public static extern void SetWindowKeyboardGrab(SDL_Window* window, SDL_bool grabbed);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMouseGrab", ExactSpelling = true)]
        public static extern void SetWindowMouseGrab(SDL_Window* window, SDL_bool grabbed);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGrab", ExactSpelling = true)]
        public static extern SDL_bool GetWindowGrab(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowKeyboardGrab", ExactSpelling = true)]
        public static extern SDL_bool GetWindowKeyboardGrab(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMouseGrab", ExactSpelling = true)]
        public static extern SDL_bool GetWindowMouseGrab(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGrabbedWindow", ExactSpelling = true)]
        public static extern SDL_Window* GetGrabbedWindow();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMouseRect", ExactSpelling = true)]
        public static extern int SetWindowMouseRect(SDL_Window* window, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMouseRect", ExactSpelling = true)]
        [return: NativeTypeName("const SDL_Rect *")]
        public static extern SDL_Rect* GetWindowMouseRect(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBrightness", ExactSpelling = true)]
        public static extern int SetWindowBrightness(SDL_Window* window, float brightness);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBrightness", ExactSpelling = true)]
        public static extern float GetWindowBrightness(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowOpacity", ExactSpelling = true)]
        public static extern int SetWindowOpacity(SDL_Window* window, float opacity);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowOpacity", ExactSpelling = true)]
        public static extern int GetWindowOpacity(SDL_Window* window, float* out_opacity);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowModalFor", ExactSpelling = true)]
        public static extern int SetWindowModalFor(SDL_Window* modal_window, SDL_Window* parent_window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowInputFocus", ExactSpelling = true)]
        public static extern int SetWindowInputFocus(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGammaRamp", ExactSpelling = true)]
        public static extern int SetWindowGammaRamp(SDL_Window* window, [NativeTypeName("const Uint16 *")] ushort* red, [NativeTypeName("const Uint16 *")] ushort* green, [NativeTypeName("const Uint16 *")] ushort* blue);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGammaRamp", ExactSpelling = true)]
        public static extern int GetWindowGammaRamp(SDL_Window* window, [NativeTypeName("Uint16 *")] ushort* red, [NativeTypeName("Uint16 *")] ushort* green, [NativeTypeName("Uint16 *")] ushort* blue);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowHitTest", ExactSpelling = true)]
        public static extern int SetWindowHitTest(SDL_Window* window, [NativeTypeName("SDL_HitTest")] delegate* unmanaged[Cdecl]<SDL_Window*, SDL_Point*, void*, SDL_HitTestResult> callback, void* callback_data);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FlashWindow", ExactSpelling = true)]
        public static extern int FlashWindow(SDL_Window* window, SDL_FlashOperation operation);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyWindow", ExactSpelling = true)]
        public static extern void DestroyWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsScreenSaverEnabled", ExactSpelling = true)]
        public static extern SDL_bool IsScreenSaverEnabled();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnableScreenSaver", ExactSpelling = true)]
        public static extern void EnableScreenSaver();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DisableScreenSaver", ExactSpelling = true)]
        public static extern void DisableScreenSaver();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_LoadLibrary", ExactSpelling = true)]
        public static extern int GL_LoadLibrary([NativeTypeName("const char *")] sbyte* path);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetProcAddress", ExactSpelling = true)]
        public static extern void* GL_GetProcAddress([NativeTypeName("const char *")] sbyte* proc);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_UnloadLibrary", ExactSpelling = true)]
        public static extern void GL_UnloadLibrary();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_ExtensionSupported", ExactSpelling = true)]
        public static extern SDL_bool GL_ExtensionSupported([NativeTypeName("const char *")] sbyte* extension);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_ResetAttributes", ExactSpelling = true)]
        public static extern void GL_ResetAttributes();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetAttribute", ExactSpelling = true)]
        public static extern int GL_SetAttribute(SDL_GLattr attr, int value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetAttribute", ExactSpelling = true)]
        public static extern int GL_GetAttribute(SDL_GLattr attr, int* value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_CreateContext", ExactSpelling = true)]
        [return: NativeTypeName("SDL_GLContext")]
        public static extern void* GL_CreateContext(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_MakeCurrent", ExactSpelling = true)]
        public static extern int GL_MakeCurrent(SDL_Window* window, [NativeTypeName("SDL_GLContext")] void* context);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetCurrentWindow", ExactSpelling = true)]
        public static extern SDL_Window* GL_GetCurrentWindow();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetCurrentContext", ExactSpelling = true)]
        [return: NativeTypeName("SDL_GLContext")]
        public static extern void* GL_GetCurrentContext();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetDrawableSize", ExactSpelling = true)]
        public static extern void GL_GetDrawableSize(SDL_Window* window, int* w, int* h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetSwapInterval", ExactSpelling = true)]
        public static extern int GL_SetSwapInterval(int interval);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetSwapInterval", ExactSpelling = true)]
        public static extern int GL_GetSwapInterval();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SwapWindow", ExactSpelling = true)]
        public static extern void GL_SwapWindow(SDL_Window* window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_DeleteContext", ExactSpelling = true)]
        public static extern void GL_DeleteContext([NativeTypeName("SDL_GLContext")] void* context);

        [NativeTypeName("#define SDL_WINDOWPOS_UNDEFINED_MASK 0x1FFF0000u")]
        public const uint SDL_WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000U;

        [NativeTypeName("#define SDL_WINDOWPOS_UNDEFINED SDL_WINDOWPOS_UNDEFINED_DISPLAY(0)")]
        public const uint SDL_WINDOWPOS_UNDEFINED = (0x1FFF0000U | (0));

        [NativeTypeName("#define SDL_WINDOWPOS_CENTERED_MASK 0x2FFF0000u")]
        public const uint SDL_WINDOWPOS_CENTERED_MASK = 0x2FFF0000U;

        [NativeTypeName("#define SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED_DISPLAY(0)")]
        public const uint SDL_WINDOWPOS_CENTERED = (0x2FFF0000U | (0));
    }
}
