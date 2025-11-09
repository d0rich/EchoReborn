using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI;

public class GameFonts
{
    SpriteFont _titleFont;
    SpriteFont _buttonFont;
    
    public GameFonts(SpriteFont titleFont, SpriteFont buttonFont)
    {
        _titleFont = titleFont;
        _buttonFont = buttonFont;
    }
    
    public SpriteFont TitleFont
    {
        get { return _titleFont; }
    }
    
    public SpriteFont ButtonFont
    {
        get { return _buttonFont; }
    }
}