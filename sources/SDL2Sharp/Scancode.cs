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

using SDL2Sharp.Interop;

namespace SDL2Sharp
{
    public enum Scancode
    {
        Unknown = SDL_Scancode.SDL_SCANCODE_UNKNOWN,
        A = SDL_Scancode.SDL_SCANCODE_A,
        B = SDL_Scancode.SDL_SCANCODE_B,
        C = SDL_Scancode.SDL_SCANCODE_C,
        D = SDL_Scancode.SDL_SCANCODE_D,
        E = SDL_Scancode.SDL_SCANCODE_E,
        F = SDL_Scancode.SDL_SCANCODE_F,
        G = SDL_Scancode.SDL_SCANCODE_G,
        H = SDL_Scancode.SDL_SCANCODE_H,
        I = SDL_Scancode.SDL_SCANCODE_I,
        J = SDL_Scancode.SDL_SCANCODE_J,
        K = SDL_Scancode.SDL_SCANCODE_K,
        L = SDL_Scancode.SDL_SCANCODE_L,
        M = SDL_Scancode.SDL_SCANCODE_M,
        N = SDL_Scancode.SDL_SCANCODE_N,
        O = SDL_Scancode.SDL_SCANCODE_O,
        P = SDL_Scancode.SDL_SCANCODE_P,
        Q = SDL_Scancode.SDL_SCANCODE_Q,
        R = SDL_Scancode.SDL_SCANCODE_R,
        S = SDL_Scancode.SDL_SCANCODE_S,
        T = SDL_Scancode.SDL_SCANCODE_T,
        U = SDL_Scancode.SDL_SCANCODE_U,
        V = SDL_Scancode.SDL_SCANCODE_V,
        W = SDL_Scancode.SDL_SCANCODE_W,
        X = SDL_Scancode.SDL_SCANCODE_X,
        Y = SDL_Scancode.SDL_SCANCODE_Y,
        Z = SDL_Scancode.SDL_SCANCODE_Z,
        D1 = SDL_Scancode.SDL_SCANCODE_1,
        D2 = SDL_Scancode.SDL_SCANCODE_2,
        D3 = SDL_Scancode.SDL_SCANCODE_3,
        D4 = SDL_Scancode.SDL_SCANCODE_4,
        D5 = SDL_Scancode.SDL_SCANCODE_5,
        D6 = SDL_Scancode.SDL_SCANCODE_6,
        D7 = SDL_Scancode.SDL_SCANCODE_7,
        D8 = SDL_Scancode.SDL_SCANCODE_8,
        D9 = SDL_Scancode.SDL_SCANCODE_9,
        D0 = SDL_Scancode.SDL_SCANCODE_0,
        Return = SDL_Scancode.SDL_SCANCODE_RETURN,
        Escape = SDL_Scancode.SDL_SCANCODE_ESCAPE,
        Backspace = SDL_Scancode.SDL_SCANCODE_BACKSPACE,
        Tab = SDL_Scancode.SDL_SCANCODE_TAB,
        Space = SDL_Scancode.SDL_SCANCODE_SPACE,
        Minus = SDL_Scancode.SDL_SCANCODE_MINUS,
        Equals = SDL_Scancode.SDL_SCANCODE_EQUALS,
        LeftBracket = SDL_Scancode.SDL_SCANCODE_LEFTBRACKET,
        RightBracket = SDL_Scancode.SDL_SCANCODE_RIGHTBRACKET,
        Backslash = SDL_Scancode.SDL_SCANCODE_BACKSLASH,
        NonUsHash = SDL_Scancode.SDL_SCANCODE_NONUSHASH,
        Semicolon = SDL_Scancode.SDL_SCANCODE_SEMICOLON,
        Apostrophe = SDL_Scancode.SDL_SCANCODE_APOSTROPHE,
        Grave = SDL_Scancode.SDL_SCANCODE_GRAVE,
        Comma = SDL_Scancode.SDL_SCANCODE_COMMA,
        Period = SDL_Scancode.SDL_SCANCODE_PERIOD,
        Slash = SDL_Scancode.SDL_SCANCODE_SLASH,
        Capslock = SDL_Scancode.SDL_SCANCODE_CAPSLOCK,
        F1 = SDL_Scancode.SDL_SCANCODE_F1,
        F2 = SDL_Scancode.SDL_SCANCODE_F2,
        F3 = SDL_Scancode.SDL_SCANCODE_F3,
        F4 = SDL_Scancode.SDL_SCANCODE_F4,
        F5 = SDL_Scancode.SDL_SCANCODE_F5,
        F6 = SDL_Scancode.SDL_SCANCODE_F6,
        F7 = SDL_Scancode.SDL_SCANCODE_F7,
        F8 = SDL_Scancode.SDL_SCANCODE_F8,
        F9 = SDL_Scancode.SDL_SCANCODE_F9,
        F10 = SDL_Scancode.SDL_SCANCODE_F10,
        F11 = SDL_Scancode.SDL_SCANCODE_F11,
        F12 = SDL_Scancode.SDL_SCANCODE_F12,
        PrintScreen = SDL_Scancode.SDL_SCANCODE_PRINTSCREEN,
        ScrollLock = SDL_Scancode.SDL_SCANCODE_SCROLLLOCK,
        Pause = SDL_Scancode.SDL_SCANCODE_PAUSE,
        Insert = SDL_Scancode.SDL_SCANCODE_INSERT,
        Home = SDL_Scancode.SDL_SCANCODE_HOME,
        PageUp = SDL_Scancode.SDL_SCANCODE_PAGEUP,
        Delete = SDL_Scancode.SDL_SCANCODE_DELETE,
        End = SDL_Scancode.SDL_SCANCODE_END,
        PageDown = SDL_Scancode.SDL_SCANCODE_PAGEDOWN,
        Right = SDL_Scancode.SDL_SCANCODE_RIGHT,
        Left = SDL_Scancode.SDL_SCANCODE_LEFT,
        Down = SDL_Scancode.SDL_SCANCODE_DOWN,
        Up = SDL_Scancode.SDL_SCANCODE_UP,
        NumLockClear = SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR,
        KeypadDivide = SDL_Scancode.SDL_SCANCODE_KP_DIVIDE,
        KeypadMultiply = SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY,
        KeypadMinus = SDL_Scancode.SDL_SCANCODE_KP_MINUS,
        KeypadPlus = SDL_Scancode.SDL_SCANCODE_KP_PLUS,
        KeypadEnter = SDL_Scancode.SDL_SCANCODE_KP_ENTER,
        Keypad1 = SDL_Scancode.SDL_SCANCODE_KP_1,
        Keypad2 = SDL_Scancode.SDL_SCANCODE_KP_2,
        Keypad3 = SDL_Scancode.SDL_SCANCODE_KP_3,
        Keypad4 = SDL_Scancode.SDL_SCANCODE_KP_4,
        Keypad5 = SDL_Scancode.SDL_SCANCODE_KP_5,
        Keypad6 = SDL_Scancode.SDL_SCANCODE_KP_6,
        Keypad7 = SDL_Scancode.SDL_SCANCODE_KP_7,
        Keypad8 = SDL_Scancode.SDL_SCANCODE_KP_8,
        Keypad9 = SDL_Scancode.SDL_SCANCODE_KP_9,
        Keypad0 = SDL_Scancode.SDL_SCANCODE_KP_0,
        KeypadPeriod = SDL_Scancode.SDL_SCANCODE_KP_PERIOD,
        NonUsBackslash = SDL_Scancode.SDL_SCANCODE_NONUSBACKSLASH,
        Application = SDL_Scancode.SDL_SCANCODE_APPLICATION,
        Power = SDL_Scancode.SDL_SCANCODE_POWER,
        KeypadEquals = SDL_Scancode.SDL_SCANCODE_KP_EQUALS,
        F13 = SDL_Scancode.SDL_SCANCODE_F13,
        F14 = SDL_Scancode.SDL_SCANCODE_F14,
        F15 = SDL_Scancode.SDL_SCANCODE_F15,
        F16 = SDL_Scancode.SDL_SCANCODE_F16,
        F17 = SDL_Scancode.SDL_SCANCODE_F17,
        F18 = SDL_Scancode.SDL_SCANCODE_F18,
        F19 = SDL_Scancode.SDL_SCANCODE_F19,
        F20 = SDL_Scancode.SDL_SCANCODE_F20,
        F21 = SDL_Scancode.SDL_SCANCODE_F21,
        F22 = SDL_Scancode.SDL_SCANCODE_F22,
        F23 = SDL_Scancode.SDL_SCANCODE_F23,
        F24 = SDL_Scancode.SDL_SCANCODE_F24,
        Execute = SDL_Scancode.SDL_SCANCODE_EXECUTE,
        Help = SDL_Scancode.SDL_SCANCODE_HELP,
        Menu = SDL_Scancode.SDL_SCANCODE_MENU,
        Select = SDL_Scancode.SDL_SCANCODE_SELECT,
        Stop = SDL_Scancode.SDL_SCANCODE_STOP,
        Again = SDL_Scancode.SDL_SCANCODE_AGAIN,
        Undo = SDL_Scancode.SDL_SCANCODE_UNDO,
        Cut = SDL_Scancode.SDL_SCANCODE_CUT,
        Copy = SDL_Scancode.SDL_SCANCODE_COPY,
        Paste = SDL_Scancode.SDL_SCANCODE_PASTE,
        Find = SDL_Scancode.SDL_SCANCODE_FIND,
        Mute = SDL_Scancode.SDL_SCANCODE_MUTE,
        VolumeUp = SDL_Scancode.SDL_SCANCODE_VOLUMEUP,
        VolumeDown = SDL_Scancode.SDL_SCANCODE_VOLUMEDOWN,
        KeypadComma = SDL_Scancode.SDL_SCANCODE_KP_COMMA,
        KeypadEqualsAS400 = SDL_Scancode.SDL_SCANCODE_KP_EQUALSAS400,
        International1 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL1,
        International2 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL2,
        International3 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL3,
        International4 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL4,
        International5 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL5,
        International6 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL6,
        International7 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL7,
        International8 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL8,
        International9 = SDL_Scancode.SDL_SCANCODE_INTERNATIONAL9,
        Lang1 = SDL_Scancode.SDL_SCANCODE_LANG1,
        Lang2 = SDL_Scancode.SDL_SCANCODE_LANG2,
        Lang3 = SDL_Scancode.SDL_SCANCODE_LANG3,
        Lang4 = SDL_Scancode.SDL_SCANCODE_LANG4,
        Lang5 = SDL_Scancode.SDL_SCANCODE_LANG5,
        Lang6 = SDL_Scancode.SDL_SCANCODE_LANG6,
        Lang7 = SDL_Scancode.SDL_SCANCODE_LANG7,
        Lang8 = SDL_Scancode.SDL_SCANCODE_LANG8,
        Lang9 = SDL_Scancode.SDL_SCANCODE_LANG9,
        AltErase = SDL_Scancode.SDL_SCANCODE_ALTERASE,
        SysReq = SDL_Scancode.SDL_SCANCODE_SYSREQ,
        Cancel = SDL_Scancode.SDL_SCANCODE_CANCEL,
        Clear = SDL_Scancode.SDL_SCANCODE_CLEAR,
        Prior = SDL_Scancode.SDL_SCANCODE_PRIOR,
        Return2 = SDL_Scancode.SDL_SCANCODE_RETURN2,
        Separator = SDL_Scancode.SDL_SCANCODE_SEPARATOR,
        Out = SDL_Scancode.SDL_SCANCODE_OUT,
        Oper = SDL_Scancode.SDL_SCANCODE_OPER,
        ClearAgain = SDL_Scancode.SDL_SCANCODE_CLEARAGAIN,
        CrSel = SDL_Scancode.SDL_SCANCODE_CRSEL,
        ExSel = SDL_Scancode.SDL_SCANCODE_EXSEL,
        Keypad00 = SDL_Scancode.SDL_SCANCODE_KP_00,
        Keypad000 = SDL_Scancode.SDL_SCANCODE_KP_000,
        ThousandsSeparator = SDL_Scancode.SDL_SCANCODE_THOUSANDSSEPARATOR,
        DecimalsSeparator = SDL_Scancode.SDL_SCANCODE_DECIMALSEPARATOR,
        CurrencyUnit = SDL_Scancode.SDL_SCANCODE_CURRENCYUNIT,
        CurrencySubUnit = SDL_Scancode.SDL_SCANCODE_CURRENCYSUBUNIT,
        KeypadLeftParenthesis = SDL_Scancode.SDL_SCANCODE_KP_LEFTPAREN,
        KeypadRightParenthesis = SDL_Scancode.SDL_SCANCODE_KP_RIGHTPAREN,
        KeypadLeftBrace = SDL_Scancode.SDL_SCANCODE_KP_LEFTBRACE,
        KeypadRightBrace = SDL_Scancode.SDL_SCANCODE_KP_RIGHTBRACE,
        KeypadTab = SDL_Scancode.SDL_SCANCODE_KP_TAB,
        KeypadBackspace = SDL_Scancode.SDL_SCANCODE_KP_BACKSPACE,
        KeypadA = SDL_Scancode.SDL_SCANCODE_KP_A,
        KeypadB = SDL_Scancode.SDL_SCANCODE_KP_B,
        KeypadC = SDL_Scancode.SDL_SCANCODE_KP_C,
        KeypadD = SDL_Scancode.SDL_SCANCODE_KP_D,
        KeypadE = SDL_Scancode.SDL_SCANCODE_KP_E,
        KeypadF = SDL_Scancode.SDL_SCANCODE_KP_F,
        KeypadXor = SDL_Scancode.SDL_SCANCODE_KP_XOR,
        KeypadPower = SDL_Scancode.SDL_SCANCODE_KP_POWER,
        KeypadPercent = SDL_Scancode.SDL_SCANCODE_KP_PERCENT,
        KeypadLess = SDL_Scancode.SDL_SCANCODE_KP_LESS,
        KeypadGreater = SDL_Scancode.SDL_SCANCODE_KP_GREATER,
        KeypadAmpersand = SDL_Scancode.SDL_SCANCODE_KP_AMPERSAND,
        KeypadDoubleAmpersand = SDL_Scancode.SDL_SCANCODE_KP_DBLAMPERSAND,
        KeypadVerticalBar = SDL_Scancode.SDL_SCANCODE_KP_VERTICALBAR,
        KeypadDoubleVerticalBar = SDL_Scancode.SDL_SCANCODE_KP_DBLVERTICALBAR,
        KeypadColon = SDL_Scancode.SDL_SCANCODE_KP_COLON,
        KeypadHash = SDL_Scancode.SDL_SCANCODE_KP_HASH,
        KeypadSpace = SDL_Scancode.SDL_SCANCODE_KP_SPACE,
        KeypadAt = SDL_Scancode.SDL_SCANCODE_KP_AT,
        KeypadExclamation = SDL_Scancode.SDL_SCANCODE_KP_EXCLAM,
        KeypadMemStore = SDL_Scancode.SDL_SCANCODE_KP_MEMSTORE,
        KeypadMemRecall = SDL_Scancode.SDL_SCANCODE_KP_MEMRECALL,
        KeypadMemClear = SDL_Scancode.SDL_SCANCODE_KP_MEMCLEAR,
        KeypadMemAdd = SDL_Scancode.SDL_SCANCODE_KP_MEMADD,
        KeypadMemSubtract = SDL_Scancode.SDL_SCANCODE_KP_MEMSUBTRACT,
        KeypadMemMultiply = SDL_Scancode.SDL_SCANCODE_KP_MEMMULTIPLY,
        KeypadMemDivide = SDL_Scancode.SDL_SCANCODE_KP_MEMDIVIDE,
        KeypadPlusMinus = SDL_Scancode.SDL_SCANCODE_KP_PLUSMINUS,
        KeypadClear = SDL_Scancode.SDL_SCANCODE_KP_CLEAR,
        KeypadClearEntry = SDL_Scancode.SDL_SCANCODE_KP_CLEARENTRY,
        KeypadBinary = SDL_Scancode.SDL_SCANCODE_KP_BINARY,
        KeypadOctal = SDL_Scancode.SDL_SCANCODE_KP_OCTAL,
        KeypadDecimal = SDL_Scancode.SDL_SCANCODE_KP_DECIMAL,
        KeypadHexadecimal = SDL_Scancode.SDL_SCANCODE_KP_HEXADECIMAL,
        LeftCtrl = SDL_Scancode.SDL_SCANCODE_LCTRL,
        LeftShift = SDL_Scancode.SDL_SCANCODE_LSHIFT,
        LeftAlt = SDL_Scancode.SDL_SCANCODE_LALT,
        LeftGui = SDL_Scancode.SDL_SCANCODE_LGUI,
        RightCtrl = SDL_Scancode.SDL_SCANCODE_RCTRL,
        RightShift = SDL_Scancode.SDL_SCANCODE_RSHIFT,
        RightAlt = SDL_Scancode.SDL_SCANCODE_RALT,
        RightGui = SDL_Scancode.SDL_SCANCODE_RGUI,
        Mode = SDL_Scancode.SDL_SCANCODE_MODE,
        AudioNext = SDL_Scancode.SDL_SCANCODE_AUDIONEXT,
        AudioPrev = SDL_Scancode.SDL_SCANCODE_AUDIOPREV,
        AudioStop = SDL_Scancode.SDL_SCANCODE_AUDIOSTOP,
        AudioPlay = SDL_Scancode.SDL_SCANCODE_AUDIOPLAY,
        AudioMute = SDL_Scancode.SDL_SCANCODE_AUDIOMUTE,
        MediaSelect = SDL_Scancode.SDL_SCANCODE_MEDIASELECT,
        Www = SDL_Scancode.SDL_SCANCODE_WWW,
        Mail = SDL_Scancode.SDL_SCANCODE_MAIL,
        Calculator = SDL_Scancode.SDL_SCANCODE_CALCULATOR,
        Computer = SDL_Scancode.SDL_SCANCODE_COMPUTER,
        AcSearch = SDL_Scancode.SDL_SCANCODE_AC_SEARCH,
        AcHome = SDL_Scancode.SDL_SCANCODE_AC_HOME,
        AcBack = SDL_Scancode.SDL_SCANCODE_AC_BACK,
        AcForeward = SDL_Scancode.SDL_SCANCODE_AC_FORWARD,
        AcStop = SDL_Scancode.SDL_SCANCODE_AC_STOP,
        AcRefresh = SDL_Scancode.SDL_SCANCODE_AC_REFRESH,
        AcBookmarks = SDL_Scancode.SDL_SCANCODE_AC_BOOKMARKS,
        BrightnessDown = SDL_Scancode.SDL_SCANCODE_BRIGHTNESSDOWN,
        BrightnessUp = SDL_Scancode.SDL_SCANCODE_BRIGHTNESSUP,
        DisplaySwitch = SDL_Scancode.SDL_SCANCODE_DISPLAYSWITCH,
        KeyboardIlluminationToggle = SDL_Scancode.SDL_SCANCODE_KBDILLUMTOGGLE,
        KeyboardIlluminationDown = SDL_Scancode.SDL_SCANCODE_KBDILLUMDOWN,
        KeyboardIlluminationUp = SDL_Scancode.SDL_SCANCODE_KBDILLUMUP,
        Eject = SDL_Scancode.SDL_SCANCODE_EJECT,
        Sleep = SDL_Scancode.SDL_SCANCODE_SLEEP,
        App1 = SDL_Scancode.SDL_SCANCODE_APP1,
        App2 = SDL_Scancode.SDL_SCANCODE_APP2,
        AudioRewind = SDL_Scancode.SDL_SCANCODE_AUDIOREWIND,
        AudioFastForward = SDL_Scancode.SDL_SCANCODE_AUDIOFASTFORWARD,
    }
}
