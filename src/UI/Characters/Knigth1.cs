using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Knigth1AnimationState
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

public class Knigth1Animation: CharacterAnimationBase<Knigth1AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Knigth1AnimationState, int> FrameCount = new()
    {
        { Knigth1AnimationState.Attack, 10 },
         {Knigth1AnimationState.Die, 10 },
          {Knigth1AnimationState.Hurt, 10 },
           {Knigth1AnimationState.Idle, 10 },
            {Knigth1AnimationState.Jump, 10 },
             {Knigth1AnimationState.Walk, 10 },
              {Knigth1AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Knigth1AnimationState, string> AnimationFileNames = new()
    {
        
         { Knigth1AnimationState.Attack, "knigth1_attack" },
         {Knigth1AnimationState.Die, "knigth1_die" },
          {Knigth1AnimationState.Hurt, "knigth1_hurt" },
           {Knigth1AnimationState.Idle, "knigth1_idle" },
            {Knigth1AnimationState.Jump, "knigth1_jump" },
             {Knigth1AnimationState.Walk, "knigth1_walk" },
              {Knigth1AnimationState.Run, "knigth1_run" },
    };
    
    public Knigth1Animation(): 
        base(
            "Enemies/Knigths/knigth1", 
            Knigth1AnimationState.Idle, 
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
    PlayLoop(Knigth1AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Knigth1AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Knigth1AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Knigth1AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Knigth1AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Knigth1AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Knigth1AnimationState.Walk);
  }

}

