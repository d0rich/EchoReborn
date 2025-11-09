using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.Screens;
using EchoReborn.UI;

namespace EchoReborn.Tests;

/// <summary>
/// Example test scene for demonstrating the battle system.
/// </summary>
public class BattleTestScene : IScreen
{
    public BattleTestScene()
    {
    }
    
    public void Update(GameTime gameTime)
    {
        // Add battle test logic here
    }
    
    public void Draw(GameTime gameTime)
    {
        var graphicsDevice = DrawingContext.GraphicsDevice;
        var spriteBatch = DrawingContext.SpriteBatch;
        
        graphicsDevice.Clear(Color.DarkRed);
        
        spriteBatch.Begin();
        
        if (GameFonts.ButtonFont != null)
        {
            spriteBatch.DrawString(GameFonts.ButtonFont, "Battle Test Scene", new Vector2(300, 200), Color.White);
            spriteBatch.DrawString(GameFonts.ButtonFont, "Press ESC to return", new Vector2(300, 250), Color.LightGray);
        }
        
        spriteBatch.End();
    }
    
    public void Destroy()
    {
        // Clean up resources if needed
    }
}

