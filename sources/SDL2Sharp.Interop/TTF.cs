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

using System.Runtime.InteropServices;

namespace SDL2Sharp.Interop
{
    public static unsafe partial class TTF
    {
        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Linked_Version", ExactSpelling = true)]
        [return: NativeTypeName("const SDL_version *")]
        public static extern SDL_version* Linked_Version();

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_ByteSwappedUNICODE", ExactSpelling = true)]
        public static extern void ByteSwappedUNICODE(int swapped);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Init", ExactSpelling = true)]
        public static extern int Init();

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFont", ExactSpelling = true)]
        [return: NativeTypeName("TTF_Font *")]
        public static extern _TTF_Font* OpenFont([NativeTypeName("const char *")] sbyte* file, int ptsize);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontIndex", ExactSpelling = true)]
        [return: NativeTypeName("TTF_Font *")]
        public static extern _TTF_Font* OpenFontIndex([NativeTypeName("const char *")] sbyte* file, int ptsize, [NativeTypeName("long")] int index);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontRW", ExactSpelling = true)]
        [return: NativeTypeName("TTF_Font *")]
        public static extern _TTF_Font* OpenFontRW(SDL_RWops* src, int freesrc, int ptsize);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontIndexRW", ExactSpelling = true)]
        [return: NativeTypeName("TTF_Font *")]
        public static extern _TTF_Font* OpenFontIndexRW(SDL_RWops* src, int freesrc, int ptsize, [NativeTypeName("long")] int index);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontStyle", ExactSpelling = true)]
        public static extern int GetFontStyle([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontStyle", ExactSpelling = true)]
        public static extern void SetFontStyle([NativeTypeName("TTF_Font *")] _TTF_Font* font, int style);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontOutline", ExactSpelling = true)]
        public static extern int GetFontOutline([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontOutline", ExactSpelling = true)]
        public static extern void SetFontOutline([NativeTypeName("TTF_Font *")] _TTF_Font* font, int outline);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontHinting", ExactSpelling = true)]
        public static extern int GetFontHinting([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontHinting", ExactSpelling = true)]
        public static extern void SetFontHinting([NativeTypeName("TTF_Font *")] _TTF_Font* font, int hinting);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontHeight", ExactSpelling = true)]
        public static extern int FontHeight([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontAscent", ExactSpelling = true)]
        public static extern int FontAscent([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontDescent", ExactSpelling = true)]
        public static extern int FontDescent([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontLineSkip", ExactSpelling = true)]
        public static extern int FontLineSkip([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontKerning", ExactSpelling = true)]
        public static extern int GetFontKerning([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontKerning", ExactSpelling = true)]
        public static extern void SetFontKerning([NativeTypeName("TTF_Font *")] _TTF_Font* font, int allowed);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaces", ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int FontFaces([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaceIsFixedWidth", ExactSpelling = true)]
        public static extern int FontFaceIsFixedWidth([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaceFamilyName", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* FontFaceFamilyName([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaceStyleName", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* FontFaceStyleName([NativeTypeName("const TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GlyphIsProvided", ExactSpelling = true)]
        public static extern int GlyphIsProvided([NativeTypeName("const TTF_Font *")] _TTF_Font* font, [NativeTypeName("Uint16")] ushort ch);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GlyphMetrics", ExactSpelling = true)]
        public static extern int GlyphMetrics([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("Uint16")] ushort ch, int* minx, int* maxx, int* miny, int* maxy, int* advance);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SizeText", ExactSpelling = true)]
        public static extern int SizeText([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, int* w, int* h);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SizeUTF8", ExactSpelling = true)]
        public static extern int SizeUTF8([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, int* w, int* h);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SizeUNICODE", ExactSpelling = true)]
        public static extern int SizeUNICODE([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const Uint16 *")] ushort* text, int* w, int* h);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Solid", ExactSpelling = true)]
        public static extern SDL_Surface* RenderText_Solid([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUTF8_Solid", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUTF8_Solid([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Solid", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUNICODE_Solid([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const Uint16 *")] ushort* text, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Solid", ExactSpelling = true)]
        public static extern SDL_Surface* RenderGlyph_Solid([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("Uint16")] ushort ch, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Shaded", ExactSpelling = true)]
        public static extern SDL_Surface* RenderText_Shaded([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg, SDL_Color bg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUTF8_Shaded", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUTF8_Shaded([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg, SDL_Color bg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Shaded", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUNICODE_Shaded([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const Uint16 *")] ushort* text, SDL_Color fg, SDL_Color bg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Shaded", ExactSpelling = true)]
        public static extern SDL_Surface* RenderGlyph_Shaded([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("Uint16")] ushort ch, SDL_Color fg, SDL_Color bg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Blended", ExactSpelling = true)]
        public static extern SDL_Surface* RenderText_Blended([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUTF8_Blended", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUTF8_Blended([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Blended", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUNICODE_Blended([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const Uint16 *")] ushort* text, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Blended_Wrapped", ExactSpelling = true)]
        public static extern SDL_Surface* RenderText_Blended_Wrapped([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg, [NativeTypeName("Uint32")] uint wrapLength);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUTF8_Blended_Wrapped([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const char *")] sbyte* text, SDL_Color fg, [NativeTypeName("Uint32")] uint wrapLength);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Blended_Wrapped", ExactSpelling = true)]
        public static extern SDL_Surface* RenderUNICODE_Blended_Wrapped([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("const Uint16 *")] ushort* text, SDL_Color fg, [NativeTypeName("Uint32")] uint wrapLength);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Blended", ExactSpelling = true)]
        public static extern SDL_Surface* RenderGlyph_Blended([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("Uint16")] ushort ch, SDL_Color fg);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_CloseFont", ExactSpelling = true)]
        public static extern void CloseFont([NativeTypeName("TTF_Font *")] _TTF_Font* font);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Quit", ExactSpelling = true)]
        public static extern void Quit();

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_WasInit", ExactSpelling = true)]
        public static extern int WasInit();

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontKerningSize", ExactSpelling = true)]
        public static extern int GetFontKerningSize([NativeTypeName("TTF_Font *")] _TTF_Font* font, int prev_index, int index);

        [DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontKerningSizeGlyphs", ExactSpelling = true)]
        public static extern int GetFontKerningSizeGlyphs([NativeTypeName("TTF_Font *")] _TTF_Font* font, [NativeTypeName("Uint16")] ushort previous_ch, [NativeTypeName("Uint16")] ushort ch);

        [NativeTypeName("#define SDL_TTF_MAJOR_VERSION 2")]
        public const int SDL_TTF_MAJOR_VERSION = 2;

        [NativeTypeName("#define SDL_TTF_MINOR_VERSION 0")]
        public const int SDL_TTF_MINOR_VERSION = 0;

        [NativeTypeName("#define SDL_TTF_PATCHLEVEL 15")]
        public const int SDL_TTF_PATCHLEVEL = 15;

        [NativeTypeName("#define TTF_MAJOR_VERSION SDL_TTF_MAJOR_VERSION")]
        public const int TTF_MAJOR_VERSION = 2;

        [NativeTypeName("#define TTF_MINOR_VERSION SDL_TTF_MINOR_VERSION")]
        public const int TTF_MINOR_VERSION = 0;

        [NativeTypeName("#define TTF_PATCHLEVEL SDL_TTF_PATCHLEVEL")]
        public const int TTF_PATCHLEVEL = 15;

        [NativeTypeName("#define SDL_TTF_COMPILEDVERSION SDL_VERSIONNUM(SDL_TTF_MAJOR_VERSION, SDL_TTF_MINOR_VERSION, SDL_TTF_PATCHLEVEL)")]
        public const int SDL_TTF_COMPILEDVERSION = ((2) * 1000 + (0) * 100 + (15));

        [NativeTypeName("#define UNICODE_BOM_NATIVE 0xFEFF")]
        public const int UNICODE_BOM_NATIVE = 0xFEFF;

        [NativeTypeName("#define UNICODE_BOM_SWAPPED 0xFFFE")]
        public const int UNICODE_BOM_SWAPPED = 0xFFFE;

        [NativeTypeName("#define TTF_STYLE_NORMAL 0x00")]
        public const int TTF_STYLE_NORMAL = 0x00;

        [NativeTypeName("#define TTF_STYLE_BOLD 0x01")]
        public const int TTF_STYLE_BOLD = 0x01;

        [NativeTypeName("#define TTF_STYLE_ITALIC 0x02")]
        public const int TTF_STYLE_ITALIC = 0x02;

        [NativeTypeName("#define TTF_STYLE_UNDERLINE 0x04")]
        public const int TTF_STYLE_UNDERLINE = 0x04;

        [NativeTypeName("#define TTF_STYLE_STRIKETHROUGH 0x08")]
        public const int TTF_STYLE_STRIKETHROUGH = 0x08;

        [NativeTypeName("#define TTF_HINTING_NORMAL 0")]
        public const int TTF_HINTING_NORMAL = 0;

        [NativeTypeName("#define TTF_HINTING_LIGHT 1")]
        public const int TTF_HINTING_LIGHT = 1;

        [NativeTypeName("#define TTF_HINTING_MONO 2")]
        public const int TTF_HINTING_MONO = 2;

        [NativeTypeName("#define TTF_HINTING_NONE 3")]
        public const int TTF_HINTING_NONE = 3;

        [NativeTypeName("#define TTF_SetError SDL_SetError")]
        public static readonly delegate*<sbyte*, int> TTF_SetError = &SDL.SetError;

        [NativeTypeName("#define TTF_GetError SDL_GetError")]
        public static readonly delegate*<sbyte*> TTF_GetError = &SDL.GetError;
    }
}
