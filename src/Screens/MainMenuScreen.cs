using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.UI.Components;
using EchoReborn.UI;

namespace EchoReborn.Screens;

/// <summary>
/// Main menu screen displaying the game title and navigation buttons.
/// </summary>
public class MainMenuScreen : IScreen
{
    private DrawingContext _drawingContext;
    private GameFonts _fonts;
    private Button _testsButton;
    private Button _exitButton;

    public MainMenuScreen(DrawingContext drawingContext, GameFonts fonts)
    {
        _fonts = fonts;
        _drawingContext = drawingContext;
        
        _testsButton = new Button(
            position: new Vector2(300, 250),
            width: 200,
            height: 60,
            text: "Tests",
            font: _fonts.ButtonFont,
            onClickCallback: () => ScreenManager.SwitchScreen(new TestSelectionScreen(drawingContext, fonts))
        );

        _exitButton = new Button(
            position: new Vector2(300, 350),
            width: 200,
            height: 60,
            text: "Exit",
            font: _fonts.ButtonFont,
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
        var graphicsDevice = _drawingContext.GraphicsDevice;
        var spriteBatch = _drawingContext.SpriteBatch;
        
        graphicsDevice.Clear(Color.Black);
        spriteBatch.Begin();

        // Draw title
        if (_fonts.TitleFont != null)
        {
            string title = "ECHO REBORN";
            Vector2 titleSize = _fonts.TitleFont.MeasureString(title);
            Vector2 titlePosition = new Vector2(
                (graphicsDevice.Viewport.Width - titleSize.X) / 2,
                80
            );
            spriteBatch.DrawString(_fonts.TitleFont, title, titlePosition, Color.Cyan);
        }
        else
        {
            // Draw placeholder when fonts not loaded
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            spriteBatch.Draw(pixel, new Rectangle((graphicsDevice.Viewport.Width - 300) / 2, 70, 300, 40), Color.DarkSlateBlue);
        }

        // Draw buttons
        _testsButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);

        spriteBatch.End();
    }
    
    public void Destroy()
    {
        // Cleanup resources if needed
    }
}

