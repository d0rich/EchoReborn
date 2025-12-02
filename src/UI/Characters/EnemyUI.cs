using EchoReborn.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn; 

namespace EchoReborn.UI.Characters;

public class EnemyUI
{
    private readonly Enemy enemy;
    private readonly Texture2D sprite;
    
    private readonly Vector2 position;
    private readonly SpriteFont font;

    public EnemyUI(Enemy enemy, Texture2D sprite, Vector2 position, SpriteFont font)
    {
        this.enemy = enemy;
        this.sprite = sprite;
        this.position = position;
        this.font = font;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // 1. Enemy sprite
        spriteBatch.Draw(sprite, position, Color.White);

        // 2. Name
        spriteBatch.DrawString(
            font, 
            enemy.Name, 
            position + new Vector2(-20, -40), 
            Color.White
        );

        // 3. HP Bar
        float hpPercent = (float)enemy.CurrentHP / enemy.MaxHP;
        int width = 140;
        int height = 18;

        // Border (black)
        spriteBatch.Draw(DrawingContext.CreateTexture(Color.White), 
            new Rectangle((int)position.X - 10, (int)position.Y + sprite.Height + 10, width, height), 
            Color.Black);

        // Background (grey)
        spriteBatch.Draw(DrawingContext.CreateTexture(Color.White), 
            new Rectangle((int)position.X - 8, (int)position.Y + sprite.Height + 12, width - 4, height - 4), 
            Color.DarkGray);

        // HP Fill
        spriteBatch.Draw(DrawingContext.CreateTexture(Color.White), 
            new Rectangle((int)position.X - 8, (int)position.Y + sprite.Height + 12, 
                (int)((width - 4) * hpPercent), height - 4), 
            Color.Red);

        // 4. HP Text
        spriteBatch.DrawString(
            font,
            $"{enemy.CurrentHP}/{enemy.MaxHP}",
            position + new Vector2(0, sprite.Height + 10),
            Color.White
        );
    }
}