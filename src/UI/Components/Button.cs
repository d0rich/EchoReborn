using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using EchoReborn.UI;

namespace EchoReborn.UI.Components;

/// <summary>
/// Represents a clickable button in the menu.
/// </summary>
public class Button
{
    // Tracks the previous mouse pressed state globally to prevent multiple click events
    private static ButtonState _previousMouseState = ButtonState.Released;
    private static ButtonState _currentMouseState = ButtonState.Released;
    
    private Rectangle _bounds;
    private string _text;
    private SpriteFont _font;
    private bool _isHovered;
    private Action _onClickCallback;

    /// <summary>
    /// Updates the global mouse state. Call this once per frame before updating any buttons.
    /// </summary>
    public static void UpdateMouseState()
    {
        _previousMouseState = _currentMouseState;
        _currentMouseState = Mouse.GetState().LeftButton;
    }

    /// <summary>
    /// Creates a new button with the specified parameters.
    /// </summary>
    /// <param name="bounds">The bounding rectangle defining the button's position and size.</param>
    /// <param name="text">The text to display on the button.</param>
    /// <param name="font">The font to use for the button text.</param>
    /// <param name="onClickCallback">The callback to invoke when the button is clicked.</param>
    public Button(Rectangle bounds, string text, SpriteFont font, Action onClickCallback = null)
    {
        _bounds = bounds;
        _text = text;
        _font = font;
        _isHovered = false;
        _onClickCallback = onClickCallback;
    }

    /// <summary>
    /// Sets or updates the click callback for this button.
    /// </summary>
    /// <param name="callback">The callback to invoke when the button is clicked.</param>
    public void SetOnClickCallback(Action callback)
    {
        _onClickCallback = callback;
    }

    public void Update()
    {
        MouseState mouseState = Mouse.GetState();
        _isHovered = _bounds.Contains(mouseState.Position);

        // Detect click on mouse button release (transition from Pressed to Released)
        if (_isHovered && 
            _currentMouseState == ButtonState.Released && 
            _previousMouseState == ButtonState.Pressed)
        {
            _onClickCallback?.Invoke();
        }
    }

    public void Draw()
    {
        Color backgroundColor = _isHovered ? Color.Cyan : Color.DarkSlateBlue;
        Color borderColor = _isHovered ? Color.White : Color.LightGray;
        DrawBackground(backgroundColor);
        DrawBorder(borderColor, 2);
        DrawText();
    }
    
    private void DrawBackground(Color backgroundColor)
    {
        Texture2D texture = DrawingContext.CreateTexture(backgroundColor);
        
        DrawingContext.SpriteBatch.Draw(
            texture,
            _bounds,
            Color.White
        );
    }

    private void DrawBorder(Color color, int thickness)
    {
        Texture2D pixel = new Texture2D(DrawingContext.GraphicsDevice, 1, 1);
        pixel.SetData(new[] { color });

        var spriteBatch = DrawingContext.SpriteBatch;
        // Top line
        spriteBatch.Draw(pixel, new Rectangle(_bounds.X, _bounds.Y, _bounds.Width, thickness), color);
        // Bottom line
        spriteBatch.Draw(pixel, new Rectangle(_bounds.X, _bounds.Y + _bounds.Height - thickness, _bounds.Width, thickness), color);
        // Left line
        spriteBatch.Draw(pixel, new Rectangle(_bounds.X, _bounds.Y, thickness, _bounds.Height), color);
        // Right line
        spriteBatch.Draw(pixel, new Rectangle(_bounds.X + _bounds.Width - thickness, _bounds.Y, thickness, _bounds.Height), color);
    }
    
    private void DrawText()
    {
        if (_font != null)
        {
            Vector2 textSize = _font.MeasureString(_text);
            Vector2 textPosition = new Vector2(
                _bounds.X + (_bounds.Width - textSize.X) / 2,
                _bounds.Y + (_bounds.Height - textSize.Y) / 2
            );

            Color textColor = _isHovered ? Color.Black : Color.White;
            DrawingContext.SpriteBatch.DrawString(_font, _text, textPosition, textColor);
        }
    }
}

