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

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth=1500;
        _graphics.PreferredBackBufferHeight=1500;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    /// <summary>
    /// Loads game content including fonts and initializes the screen manager.
    /// </summary>
    protected override void LoadContent()
    {
        DrawingContext.Initialize(GraphicsDevice, new SpriteBatch(GraphicsDevice), Content);

        // Load fonts for the menu system
        GameFonts.Initialize(
            Content.Load<SpriteFont>("Fonts/TitleFont"),
            Content.Load<SpriteFont>("Fonts/ButtonFont")
        );

        // Initialize screen manager
        ScreenManager.Initialize(this);
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
        
        ScreenManager.Update(gameTime);

        base.Update(gameTime);
    }

    /// <summary>
    /// Renders the current game state.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        // Draw the current screen from screen manager
        if (ScreenManager.IsInitialized)
        {
            ScreenManager.Draw(gameTime);
        }
        else
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        base.Draw(gameTime);
    }
}

