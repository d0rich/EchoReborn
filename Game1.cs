using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EchoReborn.UI;

namespace EchoReborn;

/// <summary>
/// Main game class for Echo Reborn.
/// </summary>
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ScreenManager _screenManager;
    private SpriteFont _titleFont;
    private SpriteFont _buttonFont;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    /// <summary>
    /// Loads game content including fonts and initializes the screen manager with test scenes.
    /// </summary>
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Load fonts for the menu system
        _titleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
        _buttonFont = Content.Load<SpriteFont>("Fonts/ButtonFont");

        // Initialize screen manager with loaded fonts
        _screenManager = new ScreenManager(_titleFont, _buttonFont);
    }

    /// <summary>
    /// Updates game state each frame.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Update the screen manager
        MouseState mouseState = Mouse.GetState();
        KeyboardState keyboardState = Keyboard.GetState();
        _screenManager.Update(mouseState, keyboardState);

        base.Update(gameTime);
    }

    /// <summary>
    /// Renders the current game state.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        // Draw the current screen from screen manager
        if (_screenManager != null)
        {
            _screenManager.Draw(_spriteBatch, GraphicsDevice);
        }
        else
        {
            GraphicsDevice.Clear(Color.Black);
        }

        base.Draw(gameTime);
    }
}