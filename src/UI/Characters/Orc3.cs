using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Orc3AnimationState
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

public class Orc3Animation: CharacterAnimationBase<Orc3AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Orc3AnimationState, int> FrameCount = new()
    {
        { Orc3AnimationState.Attack, 10 },
         {Orc3AnimationState.Die, 10 },
          {Orc3AnimationState.Hurt, 10 },
           {Orc3AnimationState.Idle, 10 },
            {Orc3AnimationState.Jump, 10 },
             {Orc3AnimationState.Walk, 10 },
              {Orc3AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Orc3AnimationState, string> AnimationFileNames = new()
    {
        
         { Orc3AnimationState.Attack, "orc3_attack" },
         {Orc3AnimationState.Die, "orc3_die" },
          {Orc3AnimationState.Hurt, "orc3_hurt" },
           {Orc3AnimationState.Idle, "orc3_idle" },
            {Orc3AnimationState.Jump, "orc3_jump" },
             {Orc3AnimationState.Walk, "orc3_walk" },
              {Orc3AnimationState.Run, "orc3_run" },
    };
    
    public Orc3Animation(): 
        base(
            "Enemies/orcs/orc3", 
            Orc3AnimationState.Idle, 
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
    PlayLoop(Orc3AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Orc3AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Orc3AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Orc3AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Orc3AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Orc3AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Orc3AnimationState.Walk);
  }

}

