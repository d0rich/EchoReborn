using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Elfe1AnimationState
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

public class Elfe1Animation: CharacterAnimationBase<Elfe1AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Elfe1AnimationState, int> FrameCount = new()
    {
        { Elfe1AnimationState.Attack, 10 },
         {Elfe1AnimationState.Die, 10 },
          {Elfe1AnimationState.Hurt, 10 },
           {Elfe1AnimationState.Idle, 10 },
            {Elfe1AnimationState.Jump, 10 },
             {Elfe1AnimationState.Walk, 10 },
              {Elfe1AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Elfe1AnimationState, string> AnimationFileNames = new()
    {
        
         { Elfe1AnimationState.Attack, "elfe1_attack" },
         {Elfe1AnimationState.Die, "elfe1_die" },
          {Elfe1AnimationState.Hurt, "elfe1_hurt" },
           {Elfe1AnimationState.Idle, "elfe1_idle" },
            {Elfe1AnimationState.Jump, "elfe1_jump" },
             {Elfe1AnimationState.Walk, "elfe1_walk" },
              {Elfe1AnimationState.Run, "elfe1_run" },
    };
    
    public Elfe1Animation(): 
        base(
            "Enemies/Elfes/elfe1", 
            Elfe1AnimationState.Idle, 
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
    PlayLoop(Elfe1AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Elfe1AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Elfe1AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Elfe1AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Elfe1AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Elfe1AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Elfe1AnimationState.Walk);
  }

}

