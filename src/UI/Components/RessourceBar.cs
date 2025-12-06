using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using EchoReborn.UI;

namespace EchoReborn.UI.Components;

public abstract class RessourceBar
{
    public static readonly Vector2 Size = new Vector2(220, 28);
    private Texture2D _pixel;
    private Vector2 _position;
    private Vector2 _size = Size; 
    private Rectangle _bounds => new Rectangle((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y);

    public Vector2 Position => _position;

    public RessourceBar(Vector2 position)
    {
        _pixel = DrawingContext.CreateTexture(Color.White);
        _position = position;
    }

    public void Draw()
    {
        SpriteBatch spriteBatch = DrawingContext.SpriteBatch;
        SpriteFont font = GameFonts.ButtonFont;
        // Draw background
        spriteBatch.Draw(_pixel, _bounds, BgColor);

        // Calculate width of the filled portion
        int filledWidth = (int)((CurrentValue / (float)MaxValue) * _bounds.Width);

        // Draw foreground
        Rectangle filledRect = new Rectangle(_bounds.X, _bounds.Y, filledWidth, _bounds.Height);
        spriteBatch.Draw(_pixel, filledRect, FgColor);

        // Draw label and values
        string text = $"{Label}: {CurrentValue}/{MaxValue}";
        Vector2 textSize = font.MeasureString(text);
        Vector2 textPosition = new Vector2(
            _bounds.X + (_bounds.Width - textSize.X) / 2,
            _bounds.Y + (_bounds.Height - textSize.Y) / 2);

        spriteBatch.DrawString(font, text, textPosition, Color.White);
    }

    protected abstract int CurrentValue { get; }
    protected abstract int MaxValue { get; }
    protected abstract string Label { get; }

    protected abstract Color BgColor { get; }
    protected abstract Color FgColor { get; }
}