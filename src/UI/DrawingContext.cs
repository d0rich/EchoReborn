using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI;

public static class DrawingContext
{
    private static GraphicsDevice _graphicsDevice;
    private static SpriteBatch _spriteBatch;
    private static ContentManager _contentManager;
    private static bool _isInitialized = false;
    
    public static void Initialize(
        GraphicsDevice graphicsDevice, 
        SpriteBatch spriteBatch, 
        ContentManager contentManager)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;
        _contentManager = contentManager;
        _isInitialized = true;
    }

    public static GraphicsDevice GraphicsDevice
    {
        get
        {
            CheckInitialized();
            return _graphicsDevice;
        }
    }
    public static SpriteBatch SpriteBatch 
    {
        get
        {
            CheckInitialized();
            return _spriteBatch;
        }
    }

    public static Texture2D CreateTexture(Color color)
    {
        CheckInitialized();
        Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
        texture.SetData(new[] { color });
        return texture;
    }

    public static ContentManager ContentManager
    {
        get 
        {
            CheckInitialized();
            return _contentManager;
        }
    }
    
    private static void CheckInitialized()
    {
        if (!_isInitialized)
            throw new System.InvalidOperationException("DrawingContext is not initialized. Call Initialize() before accessing its properties.");
    }
}