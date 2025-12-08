using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Orc2AnimationState
{
    Hurt  
    ,
    Walk,
    Attack,
    Die,
    Idle,
    Jump,
    Run
}

public class Orc2Animation: CharacterAnimationBase<Orc2AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Orc2AnimationState, int> FrameCount = new()
    {
        { Orc2AnimationState.Attack, 10 },
         {Orc2AnimationState.Die, 10 },
          {Orc2AnimationState.Hurt, 10 },
           {Orc2AnimationState.Idle, 10 },
            {Orc2AnimationState.Jump, 10 },
             {Orc2AnimationState.Walk, 10 },
              {Orc2AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Orc2AnimationState, string> AnimationFileNames = new()
    {
        
         { Orc2AnimationState.Attack, "orc2_attack" },
         {Orc2AnimationState.Die, "orc2_die" },
          {Orc2AnimationState.Hurt, "orc2_hurt" },
           {Orc2AnimationState.Idle, "orc2_idle" },
            {Orc2AnimationState.Jump, "orc2_jump" },
             {Orc2AnimationState.Walk, "orc2_walk" },
              {Orc2AnimationState.Run, "orc2_run" },
    };
    
    public Orc2Animation(): 
        base(
            "Enemies/orcs/orc2", 
            Orc2AnimationState.Idle, 
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
    PlayLoop(Orc2AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Orc2AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Orc2AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Orc2AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Orc2AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Orc2AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Orc2AnimationState.Walk);
  }

}

