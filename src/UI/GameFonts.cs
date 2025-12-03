using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI.bla;

public static class GameFonts
{
    static SpriteFont _titleFont;
    static SpriteFont _buttonFont;
    static bool _isInitialized = false;
    
    public static bool IsInitialized => _isInitialized;
    
    public static void Initialize(SpriteFont titleFont, SpriteFont buttonFont)
    {
        _titleFont = titleFont;
        _buttonFont = buttonFont;
        _isInitialized = true;
    }
    
    public static SpriteFont TitleFont
    {
        get
        {
            CheckInitialized();
            return _titleFont;
        }
    }
    
    public static SpriteFont ButtonFont
    {
        get
        {
            CheckInitialized();
            return _buttonFont;
        }
    }
    
    private static void CheckInitialized()
    {
        if (!_isInitialized)
            throw new System.InvalidOperationException("GameFonts is not initialized. Call Initialize() before accessing its properties.");
    }
}