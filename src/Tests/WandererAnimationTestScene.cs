using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.Screens;
using EchoReborn.UI;
using EchoReborn.UI.Characters;

namespace EchoReborn.Tests;

/// <summary>
/// Test scene for demonstrating WandererMagician character animations.
/// </summary>
public class WandererAnimationTestScene : IScreen
{
    private WandererMagicianAnimation _wanderer;
    private KeyboardState _previousKeyboardState;
    private int _currentAnimationIndex;
    private WandererAnimationState[] _animationStates;
    
    public WandererAnimationTestScene()
    {
        _animationStates = new[]
        {
            WandererAnimationState.Idle,
            WandererAnimationState.Walk,
            WandererAnimationState.Run,
            WandererAnimationState.Jump,
            WandererAnimationState.Attack1,
            WandererAnimationState.Attack2,
            WandererAnimationState.MagicSphere,
            WandererAnimationState.MagicArrow,
            WandererAnimationState.Hurt,
            WandererAnimationState.Dead
        };
        _currentAnimationIndex = 0;
        
        // Initialize the wanderer animation
        _wanderer = new WandererMagicianAnimation();
        _wanderer.Position = new Vector2(400, 200);
        _wanderer.Scale = 2f;
        
        // Load initial animation
        _wanderer.SwitchAnimation(_animationStates[_currentAnimationIndex]);
    }
    
    public void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        
        // Press Right Arrow to cycle through animations
        if (keyboardState.IsKeyDown(Keys.Right) && _previousKeyboardState.IsKeyUp(Keys.Right))
        {
            _currentAnimationIndex = (_currentAnimationIndex + 1) % _animationStates.Length;
            _wanderer.SwitchAnimation(_animationStates[_currentAnimationIndex]);
        }
        
        // Press Left Arrow to go back through animations
        if (keyboardState.IsKeyDown(Keys.Left) && _previousKeyboardState.IsKeyUp(Keys.Left))
        {
            _currentAnimationIndex--;
            if (_currentAnimationIndex < 0)
                _currentAnimationIndex = _animationStates.Length - 1;
            _wanderer.SwitchAnimation(_animationStates[_currentAnimationIndex]);
        }
        
        _previousKeyboardState = keyboardState;
    }
    
    public void Draw(GameTime gameTime)
    {
        var graphicsDevice = DrawingContext.GraphicsDevice;
        var spriteBatch = DrawingContext.SpriteBatch;
        
        graphicsDevice.Clear(Color.DarkSlateGray);
        
        spriteBatch.Begin();
        
        // Draw the wanderer animation
        _wanderer.Draw(gameTime);
        
        // Draw instructions
        if (GameFonts.ButtonFont != null)
        {
            spriteBatch.DrawString(GameFonts.ButtonFont, "WandererMagician Animation Test", 
                new Vector2(20, 20), Color.White);
            spriteBatch.DrawString(GameFonts.ButtonFont, 
                $"Current Animation: {_animationStates[_currentAnimationIndex]}", 
                new Vector2(20, 50), Color.Yellow);
            spriteBatch.DrawString(GameFonts.ButtonFont, "Left/Right Arrow: Change Animation", 
                new Vector2(20, 80), Color.LightGray);
            spriteBatch.DrawString(GameFonts.ButtonFont, "Space: Play/Pause", 
                new Vector2(20, 110), Color.LightGray);
            spriteBatch.DrawString(GameFonts.ButtonFont, "ESC: Return to Menu", 
                new Vector2(20, 140), Color.LightGray);
        }
        
        spriteBatch.End();
    }
    
    public void Destroy()
    {
        // Cleanup resources if needed
    }
}

