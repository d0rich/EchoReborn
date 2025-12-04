using Microsoft.Xna.Framework;

namespace EchoReborn.Battle;

public interface IBattleActorAnimations
{
    Vector2 Position { get; set; }
    float Scale { get; set; }
    void Draw(GameTime gameTime, Vector2? position = null);
    void DrawCopy(Vector2 position);
    void FaceRight();
    void FaceLeft();
    void PlayIdle();
    void PlayRun();
    void PlayAttack();
    void PlayHurt();
    void PlayDeath();
}