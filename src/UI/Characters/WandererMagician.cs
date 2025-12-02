using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EchoReborn.UI.Characters;

public enum WandererAnimationState
{
    Idle,
    Walk,
    Run,
    Jump,
    Attack1,
    Attack2,
    MagicSphere,
    MagicArrow,
    Hurt,
    Dead
}

public class WandererMagicianAnimation: CharacterAnimationBase<WandererAnimationState>
{
    private static readonly Dictionary<WandererAnimationState, int> FrameCount = new()
    {
        { WandererAnimationState.Idle, 8 },
        { WandererAnimationState.Walk, 7 },
        { WandererAnimationState.Run, 8 },
        { WandererAnimationState.Jump, 8 },
        { WandererAnimationState.Attack1, 7 },
        { WandererAnimationState.Attack2, 9 },
        { WandererAnimationState.MagicSphere, 16 },
        { WandererAnimationState.MagicArrow, 6 },
        { WandererAnimationState.Hurt, 4 },
        { WandererAnimationState.Dead, 4 }
    };
    
    private static readonly Dictionary<WandererAnimationState, string> AnimationFileNames = new()
    {
        { WandererAnimationState.Idle, "Idle" },
        { WandererAnimationState.Walk, "Walk" },
        { WandererAnimationState.Run, "Run" },
        { WandererAnimationState.Jump, "Jump" },
        { WandererAnimationState.Attack1, "Attack_1" },
        { WandererAnimationState.Attack2, "Attack_2" },
        { WandererAnimationState.MagicSphere, "Magic_sphere" },
        { WandererAnimationState.MagicArrow, "Magic_arrow" },
        { WandererAnimationState.Hurt, "Hurt" },
        { WandererAnimationState.Dead, "Dead" }
    };
    
    public WandererMagicianAnimation(): 
        base(
            "Characters/WandererMagician", 
            WandererAnimationState.Idle, 
            FrameCount, 
            AnimationFileNames
            )
    {}
}

