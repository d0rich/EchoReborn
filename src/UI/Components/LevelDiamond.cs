using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using EchoReborn.UI;

namespace EchoReborn.UI.Components;

public class LevelDiamond
{
    private Vector2 _position;
    private int _level;
    private SpriteFont _font;

    public LevelDiamond(Vector2 position, int level)
    {
        _position = position;
        _level = level;
        _font = GameFonts.ButtonFont;
    }

    public void Draw()
    {
        SpriteBatch spriteBatch = DrawingContext.SpriteBatch;
        // On dessine un carré
        Vector2 center = _position;
        int size = 32;

        Rectangle dest = new Rectangle(
            (int)(center.X + size / 2),
            (int)(center.Y + size / 2),
            size,
            size);

        // On dessine le carre
        spriteBatch.Draw(
            DrawingContext.CreateTexture(Color.Gold),
            destinationRectangle: dest,
            sourceRectangle: null,
            color: Color.White,
            rotation: MathHelper.ToRadians(45),
            origin: new Vector2(0.5f, 0.5f),
            effects: SpriteEffects.None,
            layerDepth: 0f);

        // On dessine le niveau au centre
        string levelText = _level.ToString();
        Vector2 textSize = _font.MeasureString(levelText);
        Vector2 textPos = new Vector2(
            center.X + 5 + textSize.X / 2,
            center.Y + 2);

        spriteBatch.DrawString(_font, levelText, textPos, Color.Black);
    }
}