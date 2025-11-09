using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.Screens;
using EchoReborn.UI;

namespace EchoReborn.Tests;

/// <summary>
/// Example test scene for demonstrating the battle system.
/// </summary>
public class BattleTestScene
{
    private DrawingContext _drawingContext;
    private GameFonts _fonts;
    private GraphicsDevice _graphicsDevice;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;
    
    public BattleTestScene(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, SpriteFont font = null)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;
        _font = font;
    }
    
    public void Update(GameTime gameTime)
    {
        // Add battle test logic here
    }
    
    public void Draw(GameTime gameTime)
    {
        _graphicsDevice.Clear(Color.DarkRed);
        
        _spriteBatch.Begin();
        
        if (_font != null)
        {
            _spriteBatch.DrawString(_font, "Battle Test Scene", new Vector2(300, 200), Color.White);
            _spriteBatch.DrawString(_font, "Press ESC to return", new Vector2(300, 250), Color.LightGray);
        }
        
        _spriteBatch.End();
    }
}

