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

        private SDL_AudioSpec _obtainedSpec;

        private object _userdata = null!;

        private GCHandle _unmanagedUserdata = default;

        private bool _disposed = false;

        public bool IsDisposed => _disposed;

        public bool IsOpen => _deviceID != 0;

        public AudioDeviceSpec ObtainedSpec
        {
            get
            {
                ThrowIfDisposed();
                ThrowIfClosed();
                return new AudioDeviceSpec(_obtainedSpec);
            }
        }

        public AudioDevice()
        : this(null!)
        { }

        public AudioDevice(AudioDeviceSpec spec)
        : this(spec, null!)
        { }

        public AudioDevice(AudioDeviceSpec spec, AudioDeviceCallback callback)
        : this(spec, callback, null!)
        { }

        public AudioDevice(AudioDeviceSpec spec, AudioDeviceCallback callback, object userdata)
        {
            Open(spec, callback, userdata);
        }

        public AudioDevice(AudioDeviceSpec spec, AudioDeviceCallback callback, object userdata, AudioDeviceAllowedChanges allowedChanges)
        {
            Open(spec, callback, userdata, allowedChanges);
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

        public void Open(AudioDeviceSpec spec)
        {
            if (!TryOpen(spec, null!, null!, out var error))
            {
                throw error;
            }
        }

        public void Open(AudioDeviceSpec spec, AudioDeviceCallback callback)
        {
            if (!TryOpen(spec, callback, null!, out var error))
            {
                throw error;
            }
        }

        public void Open(AudioDeviceSpec spec, AudioDeviceCallback callback, object userdata)
        {
            if (!TryOpen(spec, callback, userdata, out var error))
            {
                throw error;
            }
        }

        public void Open(AudioDeviceSpec spec, AudioDeviceCallback callback, object userdata, AudioDeviceAllowedChanges allowedChanges)
        {
            if (!TryOpen(spec, callback, userdata, allowedChanges, out var error))
            {
                throw error;
            }
        }

        public bool TryOpen(AudioDeviceSpec spec, out Error error)
        {
            return TryOpen(spec, null!, null!, out error);
        }

        public bool TryOpen(AudioDeviceSpec spec, AudioDeviceCallback callback, out Error error)
        {
            return TryOpen(spec, callback, null!, out error);
        }

        public bool TryOpen(AudioDeviceSpec spec, AudioDeviceCallback callback, object userdata, out Error error)
        {
            return TryOpen(spec, callback, userdata, AudioDeviceAllowedChanges.None, out error);
        }

        public bool TryOpen(AudioDeviceSpec spec, AudioDeviceCallback callback, object userdata, AudioDeviceAllowedChanges allowedChanges, out Error error)
        {
            ThrowIfDisposed();
            ThrowIfOpen();

            var desiredSpec = new SDL_AudioSpec
            {
                freq = spec.Frequency,
                format = (ushort)spec.Format,
                channels = (byte)spec.Channels,
                silence = 0,
                samples = 0,
                padding = 0,
                size = spec.Size
            };

            if (callback != null)
            {
                _callback = callback;
                _userdata = userdata;
                _unmanagedUserdata = GCHandle.Alloc(this, GCHandleType.Normal);
                _unmanagedCallback = new AudioDeviceCallbackDelegate(OnAudioDeviceCallback);

                desiredSpec.callback = Marshal.GetFunctionPointerForDelegate(_unmanagedCallback);
                desiredSpec.userdata = (void*)(IntPtr)_unmanagedUserdata;
            }

            fixed (SDL_AudioSpec* obtainedSpec = &_obtainedSpec)
            {
                _deviceID = SDL.OpenAudioDevice(null, 0, &desiredSpec, obtainedSpec, (int)allowedChanges);

                if (_deviceID == 0)
                {
                    error = new Error(new string(SDL.GetError()));
                    return false;
                }
                else
                {
                    error = null!;
                    return true;
                }
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
                _userdata = null!;
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
                audioDevice._callback(audioDevice._userdata, new Span<byte>(stream, len));
            }
        }
    }
}
