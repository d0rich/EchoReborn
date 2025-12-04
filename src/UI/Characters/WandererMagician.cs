using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum WandererAnimationState
{
    Idle,
    Walk,
    Run,
    Jump,
    Attack1,
    Attack2,
    MagicSphere,
    MagicArrow,
    Hurt,
    Dead
}

public class WandererMagicianAnimation: CharacterAnimationBase<WandererAnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<WandererAnimationState, int> FrameCount = new()
    {
        { WandererAnimationState.Idle, 8 },
        { WandererAnimationState.Walk, 7 },
        { WandererAnimationState.Run, 8 },
        { WandererAnimationState.Jump, 8 },
        { WandererAnimationState.Attack1, 7 },
        { WandererAnimationState.Attack2, 9 },
        { WandererAnimationState.MagicSphere, 16 },
        { WandererAnimationState.MagicArrow, 6 },
        { WandererAnimationState.Hurt, 4 },
        { WandererAnimationState.Dead, 4 }
    };
    
    private static readonly Dictionary<WandererAnimationState, string> AnimationFileNames = new()
    {
        { WandererAnimationState.Idle, "Idle" },
        { WandererAnimationState.Walk, "Walk" },
        { WandererAnimationState.Run, "Run" },
        { WandererAnimationState.Jump, "Jump" },
        { WandererAnimationState.Attack1, "Attack_1" },
        { WandererAnimationState.Attack2, "Attack_2" },
        { WandererAnimationState.MagicSphere, "Magic_sphere" },
        { WandererAnimationState.MagicArrow, "Magic_arrow" },
        { WandererAnimationState.Hurt, "Hurt" },
        { WandererAnimationState.Dead, "Dead" }
    };
    
    public WandererMagicianAnimation(): 
        base(
            "Characters/WandererMagician", 
            WandererAnimationState.Idle, 
            FrameCount, 
            AnimationFileNames
    ) {}

    public void FaceRight()
  {
    FacingDirection = Direction.Right;
  }

  public void FaceLeft()
  {
    FacingDirection = Direction.Left;
  }

  public void PlayIdle()
  {
    PlayLoop(WandererAnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(WandererAnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(WandererAnimationState.Attack1);
  }

  public void PlayHurt()
  {
    PlayOnce(WandererAnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(WandererAnimationState.Dead);
  }

}

