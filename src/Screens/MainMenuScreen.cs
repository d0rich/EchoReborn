using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EchoReborn.UI.Components;

namespace EchoReborn.Screens;

/// <summary>
/// Main menu screen displaying the game title and navigation buttons.
/// </summary>
public class MainMenuScreen
{
    private SpriteFont _titleFont;
    private SpriteFont _buttonFont;
    private Button _testsButton;
    private Button _exitButton;
    
    public string CurrentScreen { get; set; } = "MainMenu";
    public int SelectedTestScene { get; set; } = 0;

    public MainMenuScreen(SpriteFont titleFont, SpriteFont buttonFont)
    {
        _titleFont = titleFont;
        _buttonFont = buttonFont;
        
        _testsButton = new Button(
            position: new Vector2(300, 250),
            width: 200,
            height: 60,
            text: "Tests",
            font: buttonFont,
            onClickCallback: () => CurrentScreen = "TestSelection"
        );

        _exitButton = new Button(
            position: new Vector2(300, 350),
            width: 200,
            height: 60,
            text: "Exit",
            font: buttonFont,
            onClickCallback: () => CurrentScreen = "Exit"
        );
    }

    public void Update(MouseState mouseState)
    {
        _testsButton.Update(mouseState);
        _exitButton.Update(mouseState);
    }

    public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
    {
        graphicsDevice.Clear(Color.Black);

        spriteBatch.Begin();

        // Draw title
        if (_titleFont != null)
        {
            string title = "ECHO REBORN";
            Vector2 titleSize = _titleFont.MeasureString(title);
            Vector2 titlePosition = new Vector2(
                (graphicsDevice.Viewport.Width - titleSize.X) / 2,
                80
            );
            spriteBatch.DrawString(_titleFont, title, titlePosition, Color.Cyan);
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
}

