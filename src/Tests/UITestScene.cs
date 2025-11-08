using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.Tests;

/// <summary>
/// Example test scene for UI component testing.
/// </summary>
public class UITestScene
{
    private GraphicsDevice _graphicsDevice;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;
    
    public UITestScene(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, SpriteFont font = null)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;
        _font = font;
    }
    
    public void Update(GameTime gameTime)
    {
        // Add UI test logic here
    }
    
    public void Draw()
    {
        _graphicsDevice.Clear(Color.DarkGreen);
        
        _spriteBatch.Begin();
        
        if (_font != null)
        {
            _spriteBatch.DrawString(_font, "UI Test Scene", new Vector2(300, 200), Color.White);
            _spriteBatch.DrawString(_font, "Press ESC to return", new Vector2(300, 250), Color.LightGray);
        }
        
        _spriteBatch.End();
    }
}

