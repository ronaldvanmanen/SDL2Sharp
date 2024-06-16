// SDL2Sharp
//
// Copyright (C) 2021-2024 Ronald van Manen <rvanmanen@gmail.com>
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
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed class Platform : IDisposable
    {
        private VideoSubsystem _videoSubsystem = null!;

        private AudioSystem _audioSubsystem = null!;

        private EventSubsystem _eventsSubsystem = null!;

        public static Platform Instance { get; private set; } = null!;

        public VideoSubsystem Video => _videoSubsystem ??= new VideoSubsystem();

        public AudioSystem Audio => _audioSubsystem ??= new AudioSystem();

        public EventSubsystem Events => _eventsSubsystem ??= new EventSubsystem();

        internal Platform()
        {
            if (Instance != null)
            {
                throw new InvalidOperationException("Only one instance of Platform is allowed.");
            }

            Instance = this;

            SDL.Init(0);
        }

        void IDisposable.Dispose()
        {
            if (Instance != null)
            {
                SDL.Quit();
            }

            Instance = null!;
        }
    }

    public sealed class VideoSubsystem : IDisposable
    {
        internal VideoSubsystem()
        {
            SDL.InitSubSystem(SDL.SDL_INIT_VIDEO);
        }

        void IDisposable.Dispose()
        {
            SDL.QuitSubSystem(SDL.SDL_INIT_VIDEO);
        }
    }

    public sealed class AudioSystem : IDisposable
    {
        internal AudioSystem()
        {
            SDL.InitSubSystem(SDL.SDL_INIT_AUDIO);
        }

        void IDisposable.Dispose()
        {
            SDL.QuitSubSystem(SDL.SDL_INIT_AUDIO);
        }

        public AudioDevice CreateAudioDevice(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples)
        {
            return new AudioDevice(frequency, format, channels, samples);
        }

        public AudioDevice CreateAudioDevice(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback)
        {
            return new AudioDevice(frequency, format, channels, samples, callback);
        }

        public AudioDevice CreateAudioDevice(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback, AudioDeviceAllowedChanges allowedChanges)
        {
            return new AudioDevice(frequency, format, channels, samples, callback, allowedChanges);
        }
    }

    public sealed class EventSubsystem : IDisposable
    {
        internal EventSubsystem()
        {
            SDL.InitSubSystem(SDL.SDL_INIT_EVENTS);
        }

        void IDisposable.Dispose()
        {
            SDL.QuitSubSystem(SDL.SDL_INIT_EVENTS);
        }

        public bool HasEvent(uint eventType)
        {
            return SDL.HasEvent(eventType) == SDL_bool.SDL_TRUE;
        }

        public void PumpEvents()
        {
            SDL.PumpEvents();
        }
    }
}
