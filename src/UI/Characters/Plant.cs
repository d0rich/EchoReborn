using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum PlantAnimationState
{
    Idle,
    Walk,
    Attack1,
    Attack2,
    Attack3,
    Hurt,
    Dead
}

public class PlantAnimation: CharacterAnimationBase<PlantAnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<PlantAnimationState, int> FrameCount = new()
    {
        { PlantAnimationState.Idle, 5 },
        { PlantAnimationState.Walk, 9 },
        { PlantAnimationState.Attack1, 6 },
        { PlantAnimationState.Attack2, 5 },
        { PlantAnimationState.Attack3, 8 },
        { PlantAnimationState.Hurt, 3 },
        { PlantAnimationState.Dead, 2 }
    };
    
    private static readonly Dictionary<PlantAnimationState, string> AnimationFileNames = new()
    {
        { PlantAnimationState.Idle, "Idle" },
        { PlantAnimationState.Walk, "Walk" },
        { PlantAnimationState.Attack1, "Attack_1" },
        { PlantAnimationState.Attack2, "Attack_2" },
        { PlantAnimationState.Attack3, "Attack_3" },
        { PlantAnimationState.Hurt, "Hurt" },
        { PlantAnimationState.Dead, "Dead" }
    };
    
    public PlantAnimation(): 
        base(
            "Enemies/Plant", 
            PlantAnimationState.Idle, 
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
    PlayLoop(PlantAnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(PlantAnimationState.Walk);
  }

  public void PlayAttack()
  {
    PlayOnce(PlantAnimationState.Attack1);
  }

  public void PlayHurt()
  {
    PlayOnce(PlantAnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(PlantAnimationState.Dead);
  }

}

