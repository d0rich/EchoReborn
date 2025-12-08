using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Elfe2AnimationState
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

public class Elfe2Animation: CharacterAnimationBase<Elfe2AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Elfe2AnimationState, int> FrameCount = new()
    {
        { Elfe2AnimationState.Attack, 10 },
         {Elfe2AnimationState.Die, 10 },
          {Elfe2AnimationState.Hurt, 10 },
           {Elfe2AnimationState.Idle, 10 },
            {Elfe2AnimationState.Jump, 10 },
             {Elfe2AnimationState.Walk, 10 },
              {Elfe2AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Elfe2AnimationState, string> AnimationFileNames = new()
    {
        
         { Elfe2AnimationState.Attack, "elfe2_attack" },
         {Elfe2AnimationState.Die, "elfe2_die" },
          {Elfe2AnimationState.Hurt, "elfe2_hurt" },
           {Elfe2AnimationState.Idle, "elfe2_idle" },
            {Elfe2AnimationState.Jump, "elfe2_jump" },
             {Elfe2AnimationState.Walk, "elfe2_walk" },
              {Elfe2AnimationState.Run, "elfe2_run" },
    };
    
    public Elfe2Animation(): 
        base(
            "Enemies/Elfes/elfe2", 
            Elfe2AnimationState.Idle, 
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
    PlayLoop(Elfe2AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Elfe2AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Elfe2AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Elfe2AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Elfe2AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Elfe2AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Elfe2AnimationState.Walk);
  }

}

