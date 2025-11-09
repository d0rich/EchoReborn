using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EchoReborn.Screens;

namespace EchoReborn.UI;

/// <summary>
/// Manages screen transitions between main menu and test selection.
/// </summary>
public class ScreenManager
{
    private MainMenuScreen _mainMenuScreen;
    private TestSelectionScreen _testSelectionScreen;
    private string _currentScreen;

    public string CurrentScreen => _currentScreen;
    public string SelectedTest => _testSelectionScreen?.SelectedTest;

    public ScreenManager(DrawingContext drawingContext, GameFonts fonts)
    {
        _mainMenuScreen = new MainMenuScreen(drawingContext, fonts);
        _testSelectionScreen = new TestSelectionScreen(drawingContext, fonts);
        _currentScreen = "MainMenu";
    }

    /// <summary>
    /// Register a test scene with its name and class type.
    /// </summary>
    public void RegisterTestScene(string testName, System.Type sceneClass)
    {
        _testSelectionScreen.RegisterTestScene(testName, sceneClass);
    }

    public void Update(GameTime gameTime)
    {
        if (_currentScreen == "MainMenu")
        {
            _mainMenuScreen.Update(gameTime);
            if (_mainMenuScreen.CurrentScreen != "MainMenu")
            {
                _currentScreen = _mainMenuScreen.CurrentScreen;
            }
        }
        else if (_currentScreen == "TestSelection")
        {
            _testSelectionScreen.Update(gameTime);
            if (_testSelectionScreen.CurrentScreen != "TestSelection")
            {
                _currentScreen = _testSelectionScreen.CurrentScreen;
            }
        }
    }

    public void Draw(GameTime gameTime)
    {
        if (_currentScreen == "MainMenu")
        {
            _mainMenuScreen.Draw(gameTime);
        }
        else if (_currentScreen == "TestSelection")
        {
            _testSelectionScreen.Draw(gameTime);
        }
    }

    public bool ShouldExit()
    {
        return _currentScreen == "Exit";
    }
}

