using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum MedusaAnimationState
{
    Idle,
    Walk,
    Attack,
    Stones,    
    Hurt,
    Dead
}

public class MedusaAnimation : CharacterAnimationBase<MedusaAnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<MedusaAnimationState, int> FrameCount = new()
    {
        { MedusaAnimationState.Idle,   3 }, 
        { MedusaAnimationState.Walk,   4 }, 
        { MedusaAnimationState.Attack, 6 }, 
        { MedusaAnimationState.Stones, 8 }, 
        { MedusaAnimationState.Hurt,   2 }, 
        { MedusaAnimationState.Dead,   6 }  
    };

    private static readonly Dictionary<MedusaAnimationState, string> AnimationFileNames = new()
    {
        { MedusaAnimationState.Idle,   "medusa_idle" },
        { MedusaAnimationState.Walk,   "medusa_walk" },
        { MedusaAnimationState.Attack, "medusa_attack" },
        { MedusaAnimationState.Stones, "medusa_stons" }, 
        { MedusaAnimationState.Hurt,   "medusa_hurt" },
        { MedusaAnimationState.Dead,   "medusa_die" }
    };

    public MedusaAnimation() :
        base(
            "Enemies/Spirits/medusa",   
            MedusaAnimationState.Idle, 
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
        PlayLoop(MedusaAnimationState.Idle);
    }

    public void PlayRun()
    {
        PlayLoop(MedusaAnimationState.Walk);
    }

    public void PlayAttack()
    {
        PlayOnce(MedusaAnimationState.Attack);
    }

    public void PlayStoneAttack()
    {
        PlayOnce(MedusaAnimationState.Stones);
    }

    public void PlayHurt()
    {
        PlayOnce(MedusaAnimationState.Hurt);
    }

    public void PlayDeath()
    {
        PlayAndFreeze(MedusaAnimationState.Dead);
    }
}
