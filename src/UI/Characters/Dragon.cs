using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum DragonAnimationState
{
    Idle,
    Walk,
    Attack,
    FireAttack,
    Hurt,
    Dead
}

public class DragonAnimation : CharacterAnimationBase<DragonAnimationState>, IBattleActorAnimations
{
    
    private static readonly Dictionary<DragonAnimationState, int> FrameCount = new()
    {
        { DragonAnimationState.Idle,       3 }, 
        { DragonAnimationState.Walk,       5 }, 
        { DragonAnimationState.Attack,     4 }, 
        { DragonAnimationState.FireAttack, 6 }, 
        { DragonAnimationState.Hurt,       2 }, 
        { DragonAnimationState.Dead,       5 }  
    };

 
    private static readonly Dictionary<DragonAnimationState, string> AnimationFileNames = new()
    {
        { DragonAnimationState.Idle,       "dragon_idle" },
        { DragonAnimationState.Walk,       "dragon_walk" },
        { DragonAnimationState.Attack,     "dragon_attack" },
        { DragonAnimationState.FireAttack, "dragon_fireAttack" },
        { DragonAnimationState.Hurt,       "dragon_hurt" },
        { DragonAnimationState.Dead,       "dragon_die" }
    };

    public DragonAnimation() :
        base(
            "Enemies/Spirits/dragon",   
            DragonAnimationState.Idle,  
            FrameCount,
            AnimationFileNames
        )
    { }

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
        PlayLoop(DragonAnimationState.Idle);
    }

    public void PlayRun()
    {
        PlayLoop(DragonAnimationState.Walk);
    }

    public void PlayAttack()
    {
        PlayOnce(DragonAnimationState.Attack);
    }

    public void PlayFireAttack()
    {
        PlayOnce(DragonAnimationState.FireAttack);
    }

    public void PlayHurt()
    {
        PlayOnce(DragonAnimationState.Hurt);
    }

    public void PlayDeath()
    {
        PlayAndFreeze(DragonAnimationState.Dead);
    }
}
