﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.UI.Components;
using EchoReborn.UI;

namespace EchoReborn.Screens;

/// <summary>
/// Main menu screen displaying the game title and navigation buttons.
/// </summary>
public class MainMenuScreen : IScreen
{
    private Button _testsButton;
    private Button _exitButton;

    public MainMenuScreen()
    {
        _testsButton = new Button(
            bounds: new Rectangle(300, 250, 200, 60),
            text: "Tests",
            font: GameFonts.ButtonFont,
            onClickCallback: () => ScreenManager.SwitchScreen(new TestSelectionScreen())
        );

        _exitButton = new Button(
            bounds: new Rectangle(300, 350, 200, 60),
            text: "Exit",
            font: GameFonts.ButtonFont,
            onClickCallback: ScreenManager.QuitGame
        );
    }

    public void Update(GameTime gameTime)
    {
        _testsButton.Update();
        _exitButton.Update();
    }

    public void Draw(GameTime gameTime)
    {
        var graphicsDevice = DrawingContext.GraphicsDevice;
        var spriteBatch = DrawingContext.SpriteBatch;
        
        graphicsDevice.Clear(Color.Black);
        spriteBatch.Begin();

        // Draw title
        if (GameFonts.TitleFont != null)
        {
            string title = "ECHO REBORN";
            Vector2 titleSize = GameFonts.TitleFont.MeasureString(title);
            Vector2 titlePosition = new Vector2(
                (graphicsDevice.Viewport.Width - titleSize.X) / 2,
                80
            );
            spriteBatch.DrawString(GameFonts.TitleFont, title, titlePosition, Color.Cyan);
        }
        else
        {
            // Draw placeholder when fonts not loaded
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            spriteBatch.Draw(pixel, new Rectangle((graphicsDevice.Viewport.Width - 300) / 2, 70, 300, 40), Color.DarkSlateBlue);
        }

        // Draw buttons
        _testsButton.Draw();
        _exitButton.Draw();

        spriteBatch.End();
    }
    
    public void Destroy()
    {
        // Cleanup resources if needed
    }
}

