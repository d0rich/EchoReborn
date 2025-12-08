using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Elfe3AnimationState
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

public class Elfe3Animation: CharacterAnimationBase<Elfe3AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Elfe3AnimationState, int> FrameCount = new()
    {
        { Elfe3AnimationState.Attack, 10 },
         {Elfe3AnimationState.Die, 10 },
          {Elfe3AnimationState.Hurt, 10 },
           {Elfe3AnimationState.Idle, 10 },
            {Elfe3AnimationState.Jump, 10 },
             {Elfe3AnimationState.Walk, 10 },
              {Elfe3AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Elfe3AnimationState, string> AnimationFileNames = new()
    {
        
         { Elfe3AnimationState.Attack, "elfe3_attack" },
         {Elfe3AnimationState.Die, "elfe3_die" },
          {Elfe3AnimationState.Hurt, "elfe3_hurt" },
           {Elfe3AnimationState.Idle, "elfe3_idle" },
            {Elfe3AnimationState.Jump, "elfe3_jump" },
             {Elfe3AnimationState.Walk, "elfe3_walk" },
              {Elfe3AnimationState.Run, "elfe3_run" },
    };
    
    public Elfe3Animation(): 
        base(
            "Enemies/Elfes/elfe3", 
            Elfe3AnimationState.Idle, 
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
    PlayLoop(Elfe3AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Elfe3AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Elfe3AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Elfe3AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Elfe3AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Elfe3AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Elfe3AnimationState.Walk);
  }

}

