using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Orc1AnimationState
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

public class Orc1Animation: CharacterAnimationBase<Orc1AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Orc1AnimationState, int> FrameCount = new()
    {
        { Orc1AnimationState.Attack, 10 },
         {Orc1AnimationState.Die, 10 },
          {Orc1AnimationState.Hurt, 10 },
           {Orc1AnimationState.Idle, 10 },
            {Orc1AnimationState.Jump, 10 },
             {Orc1AnimationState.Walk, 10 },
              {Orc1AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Orc1AnimationState, string> AnimationFileNames = new()
    {
        
         { Orc1AnimationState.Attack, "orc1_attack" },
         {Orc1AnimationState.Die, "orc1_die" },
          {Orc1AnimationState.Hurt, "orc1_hurt" },
           {Orc1AnimationState.Idle, "orc1_idle" },
            {Orc1AnimationState.Jump, "orc1_jump" },
             {Orc1AnimationState.Walk, "orc1_walk" },
              {Orc1AnimationState.Run, "orc1_run" },
    };
    
    public Orc1Animation(): 
        base(
            "Enemies/orcs/orc1", 
            Orc1AnimationState.Idle, 
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
    PlayLoop(Orc1AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Orc1AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Orc1AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Orc1AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Orc1AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Orc1AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Orc1AnimationState.Walk);
  }

}

