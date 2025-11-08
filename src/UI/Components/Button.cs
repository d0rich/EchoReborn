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
    // Tracks the previous mouse pressed state to prevent multiple click events
    private static bool _wasMousePressed;
    
    private Vector2 _position;
    private int _width;
    private int _height;
    private string _text;
    private SpriteFont _font;
    private bool _isHovered;
    private Action _onClickCallback;

    /// <summary>
    /// Creates a new button with the specified parameters.
    /// </summary>
    /// <param name="position">The position of the button on screen.</param>
    /// <param name="width">The width of the button.</param>
    /// <param name="height">The height of the button.</param>
    /// <param name="text">The text to display on the button.</param>
    /// <param name="font">The font to use for the button text.</param>
    /// <param name="onClickCallback">The callback to invoke when the button is clicked.</param>
    public Button(Vector2 position, int width, int height, string text, SpriteFont font, Action onClickCallback = null)
    {
        _position = position;
        _width = width;
        _height = height;
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

    public void Update(MouseState mouseState)
    {
        Rectangle buttonRect = new Rectangle(
            (int)_position.X,
            (int)_position.Y,
            _width,
            _height
        );

        _isHovered = buttonRect.Contains(mouseState.Position);

        bool isMousePressed = mouseState.LeftButton == ButtonState.Pressed;

        if (_isHovered && isMousePressed && !_wasMousePressed)
        {
            _onClickCallback?.Invoke();
        }

        _wasMousePressed = isMousePressed;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw button background
        Color backgroundColor = _isHovered ? Color.Cyan : Color.DarkSlateBlue;
        Texture2D texture = CreateButtonTexture(spriteBatch.GraphicsDevice, backgroundColor);
        
        spriteBatch.Draw(
            texture,
            new Rectangle((int)_position.X, (int)_position.Y, _width, _height),
            Color.White
        );

        // Draw button border
        Color borderColor = _isHovered ? Color.White : Color.LightGray;
        DrawRectangleOutline(spriteBatch, new Rectangle((int)_position.X, (int)_position.Y, _width, _height), borderColor, 2);

        // Draw button text
        if (_font != null)
        {
            Vector2 textSize = _font.MeasureString(_text);
            Vector2 textPosition = new Vector2(
                _position.X + (_width - textSize.X) / 2,
                _position.Y + (_height - textSize.Y) / 2
            );

            Color textColor = _isHovered ? Color.Black : Color.White;
            spriteBatch.DrawString(_font, _text, textPosition, textColor);
        }
    }

    private Texture2D CreateButtonTexture(GraphicsDevice graphicsDevice, Color color)
    {
        Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
        texture.SetData(new[] { color });
        return texture;
    }

    private void DrawRectangleOutline(SpriteBatch spriteBatch, Rectangle rect, Color color, int thickness)
    {
        Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        pixel.SetData(new[] { color });

        // Top line
        spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color);
        // Bottom line
        spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y + rect.Height - thickness, rect.Width, thickness), color);
        // Left line
        spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color);
        // Right line
        spriteBatch.Draw(pixel, new Rectangle(rect.X + rect.Width - thickness, rect.Y, thickness, rect.Height), color);
    }
}

