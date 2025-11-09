using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI;

public class DrawingContext
{
    private GraphicsDevice _graphicsDevice;
    private SpriteBatch _spriteBatch;
    
    public DrawingContext(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;
    }

    public GraphicsDevice GraphicsDevice
    {
        get { return _graphicsDevice; }
    }
    public SpriteBatch SpriteBatch 
    {
        get { return _spriteBatch; }
    }
}