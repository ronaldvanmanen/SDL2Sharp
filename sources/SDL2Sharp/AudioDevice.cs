﻿// SDL2Sharp
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
using System.Runtime.InteropServices;
using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public sealed unsafe class AudioDevice : IDisposable
    {
        private uint _deviceID = 0;

        private AudioDeviceCallback _callback = null!;

        private AudioDeviceCallbackDelegate _unmanagedCallback = null!;

        private GCHandle _unmanagedUserdata = default;

        private bool _disposed = false;

        public bool IsDisposed => _disposed;

        public bool IsOpen => _deviceID != 0;

        public int Frequency { get; private set; }

        public AudioFormat Format { get; private set; }

        public AudioChannelLayout Channels { get; private set; }

        public byte Silence { get; private set; }

        public ushort Samples { get; private set; }

        public uint Size { get; private set; }

        public AudioDevice()
        { }

        public AudioDevice(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples)
        : this(frequency, format, channels, samples, null!)
        { }

        public AudioDevice(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback)
        : this(frequency, format, channels, samples, callback, AudioDeviceAllowedChanges.None)
        { }

        public AudioDevice(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback, AudioDeviceAllowedChanges allowedChanges)
        {
            Open(frequency, format, channels, samples, callback, allowedChanges);
        }

        ~AudioDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool _)
        {
            if (!_disposed)
            {
                try
                {
                    Close();
                }
                finally
                {
                    _disposed = true;
                }
            }
        }

        public void Open(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples)
        {
            Open(frequency, format, channels, samples, null!);
        }

        public void Open(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback)
        {
            Open(frequency, format, channels, samples, callback, AudioDeviceAllowedChanges.None);
        }

        public void Open(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback, AudioDeviceAllowedChanges allowedChanges)
        {
            if (!TryOpen(frequency, format, channels, samples, callback, allowedChanges, out var error))
            {
                throw error;
            }
        }

        public bool TryOpen(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, out Error error)
        {
            return TryOpen(frequency, format, channels, samples, null!, out error);
        }

        public bool TryOpen(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback, out Error error)
        {
            return TryOpen(frequency, format, channels, samples, callback, AudioDeviceAllowedChanges.None, out error);
        }

        public bool TryOpen(int frequency, AudioFormat format, AudioChannelLayout channels, ushort samples, AudioDeviceCallback callback, AudioDeviceAllowedChanges allowedChanges, out Error error)
        {
            ThrowIfDisposed();
            ThrowIfOpen();

            var desiredSpec = new SDL_AudioSpec
            {
                freq = frequency,
                format = (ushort)format,
                channels = (byte)channels,
                silence = 0,
                samples = 0,
                padding = 0,
                size = 0
            };

            if (callback != null)
            {
                _callback = callback;
                _unmanagedUserdata = GCHandle.Alloc(this, GCHandleType.Normal);
                _unmanagedCallback = new AudioDeviceCallbackDelegate(OnAudioDeviceCallback);

                desiredSpec.callback = Marshal.GetFunctionPointerForDelegate(_unmanagedCallback);
                desiredSpec.userdata = (void*)(IntPtr)_unmanagedUserdata;
            }

            var obtainedSpec = new SDL_AudioSpec();
            _deviceID = SDL.OpenAudioDevice(null, 0, &desiredSpec, &obtainedSpec, (int)allowedChanges);
            if (_deviceID == 0)
            {
                error = new Error(new string(SDL.GetError()));
                return false;
            }
            else
            {
                Frequency = obtainedSpec.freq;
                Format = (AudioFormat)obtainedSpec.format;
                Channels = (AudioChannelLayout)obtainedSpec.channels;
                Silence = obtainedSpec.silence;
                Samples = obtainedSpec.samples;
                Size = obtainedSpec.size;
                error = null!;
                return true;
            }
        }

        public void Close()
        {
            ThrowIfDisposed();

            if (_deviceID != 0)
            {
                SDL.CloseAudioDevice(_deviceID);

                _deviceID = 0;
                _callback = null!;
                _unmanagedCallback = null!;

                if (_unmanagedUserdata.IsAllocated)
                {
                    _unmanagedUserdata.Free();
                }
            }
        }

        public void Pause()
        {
            ThrowIfDisposed();
            ThrowIfClosed();
            SDL.PauseAudioDevice(_deviceID, 1);
        }

        public void Unpause()
        {
            ThrowIfDisposed();
            ThrowIfClosed();
            SDL.PauseAudioDevice(_deviceID, 0);
        }

        public void Lock()
        {
            ThrowIfDisposed();
            ThrowIfClosed();
            SDL.LockAudioDevice(_deviceID);
        }

        public void Unlock()
        {
            ThrowIfDisposed();
            ThrowIfClosed();
            SDL.UnlockAudioDevice(_deviceID);
        }

        public void Queue(Span<byte> buffer)
        {
            ThrowIfDisposed();
            ThrowIfClosed();
            fixed (void* data = &buffer[0])
            {
                Error.ThrowOnFailure(
                    SDL.QueueAudio(_deviceID, data, (uint)buffer.Length)
                );
            }
        }

        private void ThrowIfOpen()
        {
            if (IsOpen)
            {
                throw new InvalidOperationException("The Audio Device is open");
            }
        }

        private void ThrowIfClosed()
        {
            if (!IsOpen)
            {
                throw new InvalidOperationException("The Audio Device is closed");
            }
        }

        private void ThrowIfDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void AudioDeviceCallbackDelegate(void* userdata, byte* stream, int len);

        private static void OnAudioDeviceCallback(void* userdata, byte* stream, int len)
        {
            var audioDeviceHandle = GCHandle.FromIntPtr((IntPtr)userdata);
            if (audioDeviceHandle.Target is AudioDevice audioDevice)
            {
                audioDevice._callback(new Span<byte>(stream, len));
            }
        }
    }
}
