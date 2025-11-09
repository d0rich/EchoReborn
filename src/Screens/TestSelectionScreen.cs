using Microsoft.Xna.Framework;
using EchoReborn.UI.Components;
using EchoReborn.UI;
using EchoReborn.Tests;
using System.Collections.Generic;

namespace EchoReborn.Screens;

/// <summary>
/// Test selection screen displaying a list of available test scenes.
/// </summary>
public class TestSelectionScreen : IScreen
{
    private DrawingContext _drawingContext;
    private GameFonts _fonts;
    private List<Button> _testButtons;
    private Button _backButton;
    private List<TestSceneInfo> _testScenes;

    public TestSelectionScreen(DrawingContext drawingContext, GameFonts fonts)
    {
        _drawingContext = drawingContext;
        _fonts = fonts;
        _testButtons = new List<Button>();
        _testScenes = new List<TestSceneInfo>();
        
        // Register test scenes from EchoReborn.Tests namespace
        RegisterTestScene("Battle Test", () => new BattleTestScene(drawingContext, fonts));
        RegisterTestScene("UI Test", () => new UITestScene(drawingContext, fonts));
        RegisterTestScene("Graphics Test", () => new GraphicsTestScene(drawingContext, fonts));
        
        // Create back button
        _backButton = new Button(
            position: new Vector2(10, 10),
            width: 200,
            height: 60,
            text: "Back",
            font: fonts.ButtonFont,
            onClickCallback: () => ScreenManager.SwitchScreen(new MainMenuScreen(drawingContext, fonts))
        );
    }

    /// <summary>
    /// Register a test scene with its name and factory callback.
    /// </summary>
    public void RegisterTestScene(string testName, System.Func<IScreen> createInstance)
    {
        _testScenes.Add(new TestSceneInfo
        {
            Name = testName,
            CreateInstance = createInstance
        });
        
        // Recreate buttons to include the new test
        RegisterTestButtons();
    }

    private void RegisterTestButtons()
    {
        _testButtons.Clear();
        
        int startY = 150;
        int buttonSpacing = 80;
        
        for (int i = 0; i < _testScenes.Count; i++)
        {
            int index = i; // Capture index for closure
            Button button = new Button(
                position: new Vector2(300, startY + i * buttonSpacing),
                width: 200,
                height: 60,
                text: _testScenes[i].Name,
                font: _fonts.ButtonFont,
                onClickCallback: () =>
                {
                    IScreen testScreen = _testScenes[index].CreateInstance();
                    ScreenManager.SwitchScreen(testScreen);
                }
            );
            _testButtons.Add(button);
        }
    }

    public void Update(GameTime gameTime)
    {
        // Update all test buttons
        foreach (var button in _testButtons)
        {
            button.Update();
        }
        
        // Update back button
        _backButton.Update();
    }

    public void Draw(GameTime gameTime)
    {
        var graphicsDevice = _drawingContext.GraphicsDevice;
        var spriteBatch = _drawingContext.SpriteBatch;
        
        graphicsDevice.Clear(Color.Black);
        spriteBatch.Begin();

        // Draw title
        string title = "SELECT TEST";
        Vector2 titleSize = _fonts.TitleFont.MeasureString(title);
        Vector2 titlePosition = new Vector2(
            (graphicsDevice.Viewport.Width - titleSize.X) / 2,
            50
        );
        spriteBatch.DrawString(_fonts.TitleFont, title, titlePosition, Color.Cyan);

        // Draw test buttons
        foreach (var button in _testButtons)
        {
            button.Draw(spriteBatch);
        }
        
        // Draw back button
        _backButton.Draw(spriteBatch);

        spriteBatch.End();
    }

    public void Destroy()
    {
        // Cleanup resources if needed
    }
}

/// <summary>
/// Information about a test scene.
/// </summary>
public class TestSceneInfo
{
    public string Name { get; set; }
    public System.Func<IScreen> CreateInstance { get; set; }
}
