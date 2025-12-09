using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum DemonAnimationState
{
    Idle,
    Walk,
    Attack,
    Hurt,
    Dead
}

public class DemonAnimation : CharacterAnimationBase<DemonAnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<DemonAnimationState, int> FrameCount = new()
    {
        { DemonAnimationState.Idle,   3 }, 
        { DemonAnimationState.Walk,   6 }, 
        { DemonAnimationState.Attack, 4 }, 
        { DemonAnimationState.Hurt,   2 }, 
        { DemonAnimationState.Dead,   6 }  
    };

    
    private static readonly Dictionary<DemonAnimationState, string> AnimationFileNames = new()
    {
        { DemonAnimationState.Idle,   "demon_idle" },
        { DemonAnimationState.Walk,   "demon_walk" },
        { DemonAnimationState.Attack, "demon_attack" },
        { DemonAnimationState.Hurt,   "demon_hurt" },
        { DemonAnimationState.Dead,   "demon_die" }
    };

    public DemonAnimation() :
        base(
            "Enemies/Spirits/demon",  
            DemonAnimationState.Idle,  
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
        PlayLoop(DemonAnimationState.Idle);
    }

    public void PlayRun()
    {
        PlayLoop(DemonAnimationState.Walk);
    }

    public void PlayAttack()
    {
        PlayOnce(DemonAnimationState.Attack);
    }

    public void PlayHurt()
    {
        PlayOnce(DemonAnimationState.Hurt);
    }

    public void PlayDeath()
    {
        PlayAndFreeze(DemonAnimationState.Dead);
    }
}
