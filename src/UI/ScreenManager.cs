using Microsoft.Xna.Framework;
using EchoReborn.Screens;
using EchoReborn.UI.Components;

namespace EchoReborn.UI;

/// <summary>
/// Manages screen transitions between main menu and test selection.
/// </summary>
public static class ScreenManager
{
    private static Game _game;
    private static IScreen _currentScreen;
    private static bool _isInitialized = false;

    public static IScreen CurrentScreen => _currentScreen;
    public static bool IsInitialized => _isInitialized;

    public static void Initialize(Game game)
    {
        _game = game;
        _currentScreen = new MainMenuScreen();
        _isInitialized = true;
    }

    public static void Update(GameTime gameTime)
    {
        // Update global button mouse state once per frame
        Button.UpdateMouseState();
        
        _currentScreen.Update(gameTime);
    }

    public static void Draw(GameTime gameTime)
    {
        _currentScreen.Draw(gameTime);
    }
    
    public static void SwitchScreen(IScreen newScreen)
    {
        _currentScreen.Destroy();
        _currentScreen = newScreen;
    }

    public static void QuitGame()
    {
        _game.Exit();
    }
}

