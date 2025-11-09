using Microsoft.Xna.Framework;

namespace EchoReborn.Screens;

public interface IScreen
{
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
    void Destroy();
}