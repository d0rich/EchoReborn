using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum SkeletonArcherAnimationState
{
    Idle,
    Walk,
    Attack1,
    Attack2,
    Attack3,
    Shot1,
    Shot2,
    Evasion,
    Hurt,
    Dead
}

public class SkeletonArcherAnimation : CharacterAnimationBase<SkeletonArcherAnimationState>, IBattleActorAnimations
{
    // TODO : adapte les nombres de frames à tes sprites
    private static readonly Dictionary<SkeletonArcherAnimationState, int> FrameCount = new()
    {
        { SkeletonArcherAnimationState.Idle,    7 }, 
        { SkeletonArcherAnimationState.Walk,    8 }, 
        { SkeletonArcherAnimationState.Attack1, 5 }, 
        { SkeletonArcherAnimationState.Attack2, 4 }, 
        { SkeletonArcherAnimationState.Attack3, 3 },
        { SkeletonArcherAnimationState.Shot1,   15 }, 
        { SkeletonArcherAnimationState.Shot2,   15 },
        { SkeletonArcherAnimationState.Evasion, 6 }, 
        { SkeletonArcherAnimationState.Hurt,    2 }, 
        { SkeletonArcherAnimationState.Dead,    5 }  
    };

    private static readonly Dictionary<SkeletonArcherAnimationState, string> AnimationFileNames = new()
    {
        { SkeletonArcherAnimationState.Idle,    "Idle" },
        { SkeletonArcherAnimationState.Walk,    "Walk" },
        { SkeletonArcherAnimationState.Attack1, "Attack_1" },
        { SkeletonArcherAnimationState.Attack2, "Attack_2" },
        { SkeletonArcherAnimationState.Attack3, "Attack_3" },
        { SkeletonArcherAnimationState.Shot1,   "Shot_1" },
        { SkeletonArcherAnimationState.Shot2,   "Shot_2" },
        { SkeletonArcherAnimationState.Evasion, "Evasion" },
        { SkeletonArcherAnimationState.Hurt,    "Hurt" },
        { SkeletonArcherAnimationState.Dead,    "Dead" }
    };

    public SkeletonArcherAnimation() :
        base(
            "Enemies/Skeleton/Skeleton_Archer",
            SkeletonArcherAnimationState.Idle,
            FrameCount,
            AnimationFileNames
        )
    { }

    public void FaceRight() => FacingDirection = Direction.Right;
    public void FaceLeft()  => FacingDirection = Direction.Left;

    public void PlayIdle() => PlayLoop(SkeletonArcherAnimationState.Idle);

    public void PlayRun()  => PlayLoop(SkeletonArcherAnimationState.Walk);

    public void PlayAttack() => PlayOnce(SkeletonArcherAnimationState.Attack1);

    public void PlayShot1() => PlayOnce(SkeletonArcherAnimationState.Shot1);

    public void PlayShot2() => PlayOnce(SkeletonArcherAnimationState.Shot2);

    public void PlayEvasion() => PlayOnce(SkeletonArcherAnimationState.Evasion);

    public void PlayHurt() => PlayOnce(SkeletonArcherAnimationState.Hurt);

    public void PlayDeath() => PlayAndFreeze(SkeletonArcherAnimationState.Dead);
}
