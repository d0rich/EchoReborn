using System.Collections.Generic;
using EchoReborn.Battle;

namespace EchoReborn.UI.Characters;

public enum SkeletonSpearmanAnimationState
{
    Idle,
    Walk,
    Run,
    Attack1,
    Attack2,
    RunAttack,
    Protect,
    Fall,
    Hurt,
    Dead
}

public class SkeletonSpearmanAnimation : CharacterAnimationBase<SkeletonSpearmanAnimationState>, IBattleActorAnimations
{
    private static readonly Dictionary<SkeletonSpearmanAnimationState, int> FrameCount = new()
    {
        { SkeletonSpearmanAnimationState.Idle,      7 }, 
        { SkeletonSpearmanAnimationState.Walk,      7 }, 
        { SkeletonSpearmanAnimationState.Run,       6 }, 
        { SkeletonSpearmanAnimationState.Attack1,   4 }, 
        { SkeletonSpearmanAnimationState.Attack2,   4 }, 
        { SkeletonSpearmanAnimationState.RunAttack, 5 }, 
        { SkeletonSpearmanAnimationState.Protect,   2 }, 
        { SkeletonSpearmanAnimationState.Fall,      6 }, 
        { SkeletonSpearmanAnimationState.Hurt,      3 }, 
        { SkeletonSpearmanAnimationState.Dead,      5 }  
    };

    private static readonly Dictionary<SkeletonSpearmanAnimationState, string> AnimationFileNames = new()
    {
        { SkeletonSpearmanAnimationState.Idle,      "Idle" },
        { SkeletonSpearmanAnimationState.Walk,      "Walk" },
        { SkeletonSpearmanAnimationState.Run,       "Run" },
        { SkeletonSpearmanAnimationState.Attack1,   "Attack_1" },
        { SkeletonSpearmanAnimationState.Attack2,   "Attack_2" },
        { SkeletonSpearmanAnimationState.RunAttack, "Run+attack" },
        { SkeletonSpearmanAnimationState.Protect,   "Protect" },
        { SkeletonSpearmanAnimationState.Fall,      "Fall" },
        { SkeletonSpearmanAnimationState.Hurt,      "Hurt" },
        { SkeletonSpearmanAnimationState.Dead,      "Dead" }
    };

    public SkeletonSpearmanAnimation() :
        base(
            "Enemies/Skeleton/Skeleton_Spearman",
            SkeletonSpearmanAnimationState.Idle,
            FrameCount,
            AnimationFileNames
        )
    { }

    public void FaceRight() => FacingDirection = Direction.Right;
    public void FaceLeft()  => FacingDirection = Direction.Left;

    public void PlayIdle() => PlayLoop(SkeletonSpearmanAnimationState.Idle);

    public void PlayRun()  => PlayLoop(SkeletonSpearmanAnimationState.Run);

    public void PlayAttack() => PlayOnce(SkeletonSpearmanAnimationState.Attack1);

    public void PlayRunAttack() => PlayOnce(SkeletonSpearmanAnimationState.RunAttack);

    public void PlayProtect() => PlayOnce(SkeletonSpearmanAnimationState.Protect);

    public void PlayFall() => PlayOnce(SkeletonSpearmanAnimationState.Fall);

    public void PlayHurt() => PlayOnce(SkeletonSpearmanAnimationState.Hurt);

    public void PlayDeath() => PlayAndFreeze(SkeletonSpearmanAnimationState.Dead);
}
