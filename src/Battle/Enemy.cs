using System;
using System.Collections.Generic;
using Models = EchoReborn.Data.Models.Generated;

namespace EchoReborn.Battle;

public class Enemy : BattleActor

{


    public Enemy(int level, List<BattleAction> skills, IBattleActorAnimations animations = null)
        : base(level: level, skills: skills)
    {
        LoadAnimations(animations);
    }

    public Enemy(int level, Models.Enemy model) : base(
        level: level, 
        skillRefs: model.Skills,
        animationClassName: model.AnimationClass
    ) { }



    public BattleAction ChooseAction()
    {
        Random rand = new Random();
        int index = rand.Next(Skills.Count);
        return Skills[index];
    }

}