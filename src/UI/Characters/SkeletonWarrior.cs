using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum SkeletonWarriorAnimationState
{
    Idle,
    Walk,
    Run,
    Attack1,
    Attack2,
    Attack3,
    RunAttack,
    Protect,
    Hurt,
    Dead
}

public class SkeletonWarriorAnimation : CharacterAnimationBase<SkeletonWarriorAnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<SkeletonWarriorAnimationState, int> FrameCount = new()
    {
        { SkeletonWarriorAnimationState.Idle,      7 }, 
        { SkeletonWarriorAnimationState.Walk,      7 }, 
        { SkeletonWarriorAnimationState.Run,       8 }, 
        { SkeletonWarriorAnimationState.Attack1,   5 }, 
        { SkeletonWarriorAnimationState.Attack2,   6 }, 
        { SkeletonWarriorAnimationState.Attack3,   4 }, 
        { SkeletonWarriorAnimationState.RunAttack, 7 }, 
        { SkeletonWarriorAnimationState.Protect,   1 }, 
        { SkeletonWarriorAnimationState.Hurt,      2 }, 
        { SkeletonWarriorAnimationState.Dead,      4 } 
    };

    private static readonly Dictionary<SkeletonWarriorAnimationState, string> AnimationFileNames = new()
    {
        { SkeletonWarriorAnimationState.Idle,      "Idle" },
        { SkeletonWarriorAnimationState.Walk,      "Walk" },
        { SkeletonWarriorAnimationState.Run,       "Run" },
        { SkeletonWarriorAnimationState.Attack1,   "Attack_1" },
        { SkeletonWarriorAnimationState.Attack2,   "Attack_2" },
        { SkeletonWarriorAnimationState.Attack3,   "Attack_3" },
        { SkeletonWarriorAnimationState.RunAttack, "Run+attack" },
        { SkeletonWarriorAnimationState.Protect,   "Protect" },
        { SkeletonWarriorAnimationState.Hurt,      "Hurt" },
        { SkeletonWarriorAnimationState.Dead,      "Dead" }
    };

    public SkeletonWarriorAnimation() :
        base(
            "Enemies/Skeleton/Skeleton_Warrior",
            SkeletonWarriorAnimationState.Idle,
            FrameCount,
            AnimationFileNames
        )
    { }

    public void FaceRight() => FacingDirection = Direction.Right;
    public void FaceLeft()  => FacingDirection = Direction.Left;

    public void PlayIdle() => PlayLoop(SkeletonWarriorAnimationState.Idle);

    public void PlayRun()  => PlayLoop(SkeletonWarriorAnimationState.Run);

    public void PlayAttack() => PlayOnce(SkeletonWarriorAnimationState.Attack1);

    public void PlayAttack2() => PlayOnce(SkeletonWarriorAnimationState.Attack2);

    public void PlayAttack3() => PlayOnce(SkeletonWarriorAnimationState.Attack3);

    public void PlayRunAttack() => PlayOnce(SkeletonWarriorAnimationState.RunAttack);

    public void PlayProtect() => PlayOnce(SkeletonWarriorAnimationState.Protect);

    public void PlayHurt() => PlayOnce(SkeletonWarriorAnimationState.Hurt);

    public void PlayDeath() => PlayAndFreeze(SkeletonWarriorAnimationState.Dead);
}
