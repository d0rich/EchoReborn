using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum Knigth2AnimationState
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

public class Knigth2Animation: CharacterAnimationBase<Knigth2AnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<Knigth2AnimationState, int> FrameCount = new()
    {
        { Knigth2AnimationState.Attack, 10 },
         {Knigth2AnimationState.Die, 10 },
          {Knigth2AnimationState.Hurt, 10 },
           {Knigth2AnimationState.Idle, 10 },
            {Knigth2AnimationState.Jump, 10 },
             {Knigth2AnimationState.Walk, 10 },
              {Knigth2AnimationState.Run, 10 },

        
    };
    
    private static readonly Dictionary<Knigth2AnimationState, string> AnimationFileNames = new()
    {
        
         { Knigth2AnimationState.Attack, "knigth2_attack" },
         {Knigth2AnimationState.Die, "knigth2_die" },
          {Knigth2AnimationState.Hurt, "knigth2_hurt" },
           {Knigth2AnimationState.Idle, "knigth2_idle" },
            {Knigth2AnimationState.Jump, "knigth2_jump" },
             {Knigth2AnimationState.Walk, "knigth2_walk" },
              {Knigth2AnimationState.Run, "knigth2_run" },
    };
    
    public Knigth2Animation(): 
        base(
            "Enemies/Knigths/knigth2", 
            Knigth2AnimationState.Idle, 
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
    PlayLoop(Knigth2AnimationState.Idle);
  }

  public void PlayRun()
  {
    PlayLoop(Knigth2AnimationState.Run);
  }

  public void PlayAttack()
  {
    PlayOnce(Knigth2AnimationState.Attack);
  }

  public void PlayHurt()
  {
    PlayOnce(Knigth2AnimationState.Hurt);
  }

  public void PlayDeath()
  {
    PlayAndFreeze(Knigth2AnimationState.Die);
  }
  public void PlayJump()
  {
    PlayAndFreeze(Knigth2AnimationState.Jump);
  }
  public void PlayWalk()
  {
    PlayAndFreeze(Knigth2AnimationState.Walk);
  }

}

