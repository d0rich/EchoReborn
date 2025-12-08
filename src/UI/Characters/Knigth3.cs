using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Knigth3AnimationState
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

public class Knigth3Animation: CharacterAnimationBase<Knigth3AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Knigth3AnimationState, int> FrameCount = new()
    {
        { Knigth3AnimationState.Attack, 10 },
         {Knigth3AnimationState.Die, 10 },
          {Knigth3AnimationState.Hurt, 10 },
           {Knigth3AnimationState.Idle, 10 },
            {Knigth3AnimationState.Jump, 10 },
             {Knigth3AnimationState.Walk, 10 },
              {Knigth3AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Knigth3AnimationState, string> AnimationFileNames = new()
    {
        
         { Knigth3AnimationState.Attack, "knigth3_attack" },
         {Knigth3AnimationState.Die, "knigth3_die" },
          {Knigth3AnimationState.Hurt, "knigth3_hurt" },
           {Knigth3AnimationState.Idle, "knigth3_idle" },
            {Knigth3AnimationState.Jump, "knigth3_jump" },
             {Knigth3AnimationState.Walk, "knigth3_walk" },
              {Knigth3AnimationState.Run, "knigth3_run" },
    };
    
    public Knigth3Animation(): 
        base(
            "Enemies/Knigths/knigth3", 
            Knigth3AnimationState.Idle, 
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
    PlayLoop(Knigth3AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Knigth3AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Knigth3AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Knigth3AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Knigth3AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Knigth3AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Knigth3AnimationState.Walk);
  }

}

