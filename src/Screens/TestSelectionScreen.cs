using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    
    public string CurrentScreen { get; set; } = "TestSelection";
    public string SelectedTest { get; private set; } = null;

    public TestSelectionScreen(DrawingContext drawingContext, GameFonts fonts)
    {
        _drawingContext = drawingContext;
        _fonts = fonts;
        _testButtons = new List<Button>();
        _testScenes = new List<TestSceneInfo>();
        
        // Register test scenes from EchoReborn.Tests namespace
        RegisterTestScene("Battle Test", typeof(BattleTestScene));
        RegisterTestScene("UI Test", typeof(UITestScene));
        RegisterTestScene("Graphics Test", typeof(GraphicsTestScene));
        
        // Create back button
        _backButton = new Button(
            position: new Vector2(300, 500),
            width: 200,
            height: 60,
            text: "Back",
            font: fonts.ButtonFont,
            onClickCallback: () => CurrentScreen = "MainMenu"
        );
    }

    /// <summary>
    /// Register a test scene with its name and class type.
    /// </summary>
    public void RegisterTestScene(string testName, System.Type sceneClass)
    {
        _testScenes.Add(new TestSceneInfo
        {
            Name = testName,
            SceneClass = sceneClass
        });
        
        // Recreate buttons to include the new test
        CreateTestButtons();
    }

    private void CreateTestButtons()
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
                    SelectedTest = _testScenes[index].Name;
                    CurrentScreen = "TestScene";
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
        if (_fonts.TitleFont != null)
        {
            string title = "SELECT TEST";
            Vector2 titleSize = _fonts.TitleFont.MeasureString(title);
            Vector2 titlePosition = new Vector2(
                (graphicsDevice.Viewport.Width - titleSize.X) / 2,
                50
            );
            spriteBatch.DrawString(_fonts.TitleFont, title, titlePosition, Color.Cyan);
        }
        else
        {
            // Draw placeholder when fonts not loaded
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            spriteBatch.Draw(pixel, new Rectangle((graphicsDevice.Viewport.Width - 300) / 2, 40, 300, 40), Color.DarkSlateBlue);
        }

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
    public System.Type SceneClass { get; set; }
}
