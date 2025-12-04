namespace EchoReborn.Battle;

public interface IBattleActorAnimations
{
    void FaceRight();
    void FaceLeft();
    void PlayIdle();
    void PlayRun();
    void PlayAttack();
    void PlayHurt();
    void PlayDeath();
}