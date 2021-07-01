using static SDL2Sharp.SDL_ArrayOrder;
using static SDL2Sharp.SDL_BitmapOrder;
using static SDL2Sharp.SDL_PackedLayout;
using static SDL2Sharp.SDL_PackedOrder;
using static SDL2Sharp.SDL_PixelType;

namespace SDL2Sharp
{
    [NativeTypeName("int")]
    public enum SDL_PixelFormatEnum : uint
    {
        SDL_PIXELFORMAT_UNKNOWN,
        SDL_PIXELFORMAT_INDEX1LSB = ((1 << 28) | ((SDL_PIXELTYPE_INDEX1) << 24) | ((SDL_BITMAPORDER_4321) << 20) | ((0) << 16) | ((1) << 8) | ((0) << 0)),
        SDL_PIXELFORMAT_INDEX1MSB = ((1 << 28) | ((SDL_PIXELTYPE_INDEX1) << 24) | ((SDL_BITMAPORDER_1234) << 20) | ((0) << 16) | ((1) << 8) | ((0) << 0)),
        SDL_PIXELFORMAT_INDEX4LSB = ((1 << 28) | ((SDL_PIXELTYPE_INDEX4) << 24) | ((SDL_BITMAPORDER_4321) << 20) | ((0) << 16) | ((4) << 8) | ((0) << 0)),
        SDL_PIXELFORMAT_INDEX4MSB = ((1 << 28) | ((SDL_PIXELTYPE_INDEX4) << 24) | ((SDL_BITMAPORDER_1234) << 20) | ((0) << 16) | ((4) << 8) | ((0) << 0)),
        SDL_PIXELFORMAT_INDEX8 = ((1 << 28) | ((SDL_PIXELTYPE_INDEX8) << 24) | ((0) << 20) | ((0) << 16) | ((8) << 8) | ((1) << 0)),
        SDL_PIXELFORMAT_RGB332 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED8) << 24) | ((SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PACKEDLAYOUT_332) << 16) | ((8) << 8) | ((1) << 0)),
        SDL_PIXELFORMAT_XRGB4444 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PACKEDLAYOUT_4444) << 16) | ((12) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_RGB444 = SDL_PIXELFORMAT_XRGB4444,
        SDL_PIXELFORMAT_XBGR4444 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PACKEDLAYOUT_4444) << 16) | ((12) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_BGR444 = SDL_PIXELFORMAT_XBGR4444,
        SDL_PIXELFORMAT_XRGB1555 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PACKEDLAYOUT_1555) << 16) | ((15) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_RGB555 = SDL_PIXELFORMAT_XRGB1555,
        SDL_PIXELFORMAT_XBGR1555 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PACKEDLAYOUT_1555) << 16) | ((15) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_BGR555 = SDL_PIXELFORMAT_XBGR1555,
        SDL_PIXELFORMAT_ARGB4444 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_RGBA4444 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_RGBA) << 20) | ((SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_ABGR4444 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_ABGR) << 20) | ((SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_BGRA4444 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_BGRA) << 20) | ((SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_ARGB1555 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PACKEDLAYOUT_1555) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_RGBA5551 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_RGBA) << 20) | ((SDL_PACKEDLAYOUT_5551) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_ABGR1555 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_ABGR) << 20) | ((SDL_PACKEDLAYOUT_1555) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_BGRA5551 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_BGRA) << 20) | ((SDL_PACKEDLAYOUT_5551) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_RGB565 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PACKEDLAYOUT_565) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_BGR565 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PACKEDLAYOUT_565) << 16) | ((16) << 8) | ((2) << 0)),
        SDL_PIXELFORMAT_RGB24 = ((1 << 28) | ((SDL_PIXELTYPE_ARRAYU8) << 24) | ((SDL_ARRAYORDER_RGB) << 20) | ((0) << 16) | ((24) << 8) | ((3) << 0)),
        SDL_PIXELFORMAT_BGR24 = ((1 << 28) | ((SDL_PIXELTYPE_ARRAYU8) << 24) | ((SDL_ARRAYORDER_BGR) << 20) | ((0) << 16) | ((24) << 8) | ((3) << 0)),
        SDL_PIXELFORMAT_XRGB8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_RGB888 = SDL_PIXELFORMAT_XRGB8888,
        SDL_PIXELFORMAT_RGBX8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_RGBX) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_XBGR8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_BGR888 = SDL_PIXELFORMAT_XBGR8888,
        SDL_PIXELFORMAT_BGRX8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_BGRX) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_ARGB8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_RGBA8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_RGBA) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_ABGR8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_ABGR) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_BGRA8888 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_BGRA) << 20) | ((SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_ARGB2101010 = ((1 << 28) | ((SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PACKEDLAYOUT_2101010) << 16) | ((32) << 8) | ((4) << 0)),
        SDL_PIXELFORMAT_RGBA32 = SDL_PIXELFORMAT_ABGR8888,
        SDL_PIXELFORMAT_ARGB32 = SDL_PIXELFORMAT_BGRA8888,
        SDL_PIXELFORMAT_BGRA32 = SDL_PIXELFORMAT_ARGB8888,
        SDL_PIXELFORMAT_ABGR32 = SDL_PIXELFORMAT_RGBA8888,
        SDL_PIXELFORMAT_YV12 = (((uint)((byte)('Y')) << 0) | ((uint)((byte)('V')) << 8) | ((uint)((byte)('1')) << 16) | ((uint)((byte)('2')) << 24)),
        SDL_PIXELFORMAT_IYUV = (((uint)((byte)('I')) << 0) | ((uint)((byte)('Y')) << 8) | ((uint)((byte)('U')) << 16) | ((uint)((byte)('V')) << 24)),
        SDL_PIXELFORMAT_YUY2 = (((uint)((byte)('Y')) << 0) | ((uint)((byte)('U')) << 8) | ((uint)((byte)('Y')) << 16) | ((uint)((byte)('2')) << 24)),
        SDL_PIXELFORMAT_UYVY = (((uint)((byte)('U')) << 0) | ((uint)((byte)('Y')) << 8) | ((uint)((byte)('V')) << 16) | ((uint)((byte)('Y')) << 24)),
        SDL_PIXELFORMAT_YVYU = (((uint)((byte)('Y')) << 0) | ((uint)((byte)('V')) << 8) | ((uint)((byte)('Y')) << 16) | ((uint)((byte)('U')) << 24)),
        SDL_PIXELFORMAT_NV12 = (((uint)((byte)('N')) << 0) | ((uint)((byte)('V')) << 8) | ((uint)((byte)('1')) << 16) | ((uint)((byte)('2')) << 24)),
        SDL_PIXELFORMAT_NV21 = (((uint)((byte)('N')) << 0) | ((uint)((byte)('V')) << 8) | ((uint)((byte)('2')) << 16) | ((uint)((byte)('1')) << 24)),
        SDL_PIXELFORMAT_EXTERNAL_OES = (((uint)((byte)('O')) << 0) | ((uint)((byte)('E')) << 8) | ((uint)((byte)('S')) << 16) | ((uint)((byte)(' ')) << 24)),
    }
}
