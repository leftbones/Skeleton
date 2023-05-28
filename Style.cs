using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Skeleton;

public class Style {
    // Main
    public Color Background;
    public Color Foreground;

    // Button
    public Color ButtonBackground;
    public Color ButtonBackgroundHover;
    public Color ButtonBackgroundClick;

    public Color ButtonForeground;
    public Color ButtonForegroundHover;
    public Color ButtonForegroundClick;

    // Font
    public Font Font;
    public int FontSize;
    public int FontSpacing;

    public Style(
	    Color? foreground = null,
	    Color? background = null,
        Color? button_background = null,
        Color? button_background_hover = null,
        Color? button_background_click = null,
        Color? button_foreground = null,
        Color? button_foreground_hover = null,
        Color? button_foreground_click = null,
        Font? font = null,
        int? font_size = null,
        int? font_spacing = null
	) {
        Foreground = foreground ?? Color.WHITE;
        Background = background ?? Color.DARKGRAY;

        ButtonBackground = button_background ?? Color.GRAY;
        ButtonBackgroundHover = button_background_hover ?? Color.RED;
        ButtonBackgroundClick = button_background_click ?? Color.MAROON;
        ButtonForeground = button_foreground ?? Color.WHITE;
        ButtonForegroundHover = button_foreground_hover ?? Color.WHITE;
        ButtonForegroundClick = button_foreground_click ?? Color.WHITE;

		//Font = font ?? LoadFont("Resources/pixantiqua.png");
		Font = font ?? LoadFontEx("Resources/monogram.ttf", 18, null, 250);
        FontSize = font_size ?? Font.baseSize;
        FontSpacing = font_spacing ?? 0;
    }
}
