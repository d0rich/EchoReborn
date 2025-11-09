using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI;

public static class DrawingContext
{
    private static GraphicsDevice _graphicsDevice;
    private static SpriteBatch _spriteBatch;
    private static bool _isInitialized = false;
    
    public static void Initialize(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;
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
    
    private static void CheckInitialized()
    {
        if (!_isInitialized)
            throw new System.InvalidOperationException("DrawingContext is not initialized. Call Initialize() before accessing its properties.");
    }
}