﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.Screens;
using EchoReborn.UI;

namespace EchoReborn.Tests;

/// <summary>
/// Example test scene for UI component testing.
/// </summary>
public class UITestScene : IScreen
{
    private GameFonts _fonts;
    
    public UITestScene(GameFonts fonts)
    {
        _fonts = fonts;
    }
    
    public void Update(GameTime gameTime)
    {
        // Add UI test logic here
    }
    
    public void Draw(GameTime gameTime)
    {
        var graphicsDevice = DrawingContext.GraphicsDevice;
        var spriteBatch = DrawingContext.SpriteBatch;
        
        graphicsDevice.Clear(Color.DarkGreen);
        
        spriteBatch.Begin();
        
        if (_fonts.ButtonFont != null)
        {
            spriteBatch.DrawString(_fonts.ButtonFont, "UI Test Scene", new Vector2(300, 200), Color.White);
            spriteBatch.DrawString(_fonts.ButtonFont, "Press ESC to return", new Vector2(300, 250), Color.LightGray);
        }
        
        spriteBatch.End();
    }
    
    public void Destroy()
    {
        // Clean up resources if needed
    }
}

