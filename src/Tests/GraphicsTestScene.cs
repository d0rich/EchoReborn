using EchoReborn.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.UI;

namespace EchoReborn.Tests;

/// <summary>
/// Example test scene for graphics rendering tests.
/// </summary>
public class GraphicsTestScene : IScreen
{
    private DrawingContext _drawingContext;
    private GameFonts _fonts; 
    
    public GraphicsTestScene(DrawingContext drawingContext, GameFonts fonts)
    {
        _drawingContext = drawingContext;
        _fonts = fonts;
    }
    
    public void Update(GameTime gameTime)
    {
        // Add graphics test logic here
    }
    
    public void Draw(GameTime gameTime)
    {
        var graphicsDevice = _drawingContext.GraphicsDevice;
        var spriteBatch = _drawingContext.SpriteBatch;
        
        graphicsDevice.Clear(Color.DarkBlue);
        
        spriteBatch.Begin();
        
        if (_fonts.ButtonFont != null)
        {
            spriteBatch.DrawString(_fonts.ButtonFont, "Graphics Test Scene", new Vector2(300, 200), Color.White);
            spriteBatch.DrawString(_fonts.ButtonFont, "Press ESC to return", new Vector2(300, 250), Color.LightGray);
        }
        
        spriteBatch.End();
    }

    public void Destroy()
    {
        // Clean up resources if needed
    }
}

