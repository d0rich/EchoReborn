using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EchoReborn.UI.Components;

/// <summary>
/// Represents a clickable button in the menu.
/// </summary>
public class Button
{
    // Tracks the previous mouse pressed state globally to prevent multiple click events
    private static ButtonState _previousMouseState = ButtonState.Released;
    private static ButtonState _currentMouseState = ButtonState.Released;
    
    private DrawingContext _drawingContext;
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
    /// <param name="drawingContext">The drawing context for rendering.</param>
    /// <param name="bounds">The bounding rectangle defining the button's position and size.</param>
    /// <param name="text">The text to display on the button.</param>
    /// <param name="font">The font to use for the button text.</param>
    /// <param name="onClickCallback">The callback to invoke when the button is clicked.</param>
    public Button(DrawingContext drawingContext, Rectangle bounds, string text, SpriteFont font, Action onClickCallback = null)
    {
        _drawingContext = drawingContext;
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
        Texture2D texture = CreateButtonTexture(_drawingContext.GraphicsDevice, backgroundColor);
        
        _drawingContext.SpriteBatch.Draw(
            texture,
            _bounds,
            Color.White
        );
    }

    private Texture2D CreateButtonTexture(GraphicsDevice graphicsDevice, Color color)
    {
        Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
        texture.SetData(new[] { color });
        return texture;
    }

    private void DrawBorder(Color color, int thickness)
    {
        Texture2D pixel = new Texture2D(_drawingContext.GraphicsDevice, 1, 1);
        pixel.SetData(new[] { color });

        var spriteBatch = _drawingContext.SpriteBatch;
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
            _drawingContext.SpriteBatch.DrawString(_font, _text, textPosition, textColor);
        }
    }
}

