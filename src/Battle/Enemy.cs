using System;
using System.Collections.Generic;
using Models = EchoReborn.Data.Models.Generated;

namespace EchoReborn.Battle;

public class Enemy : BattleActor

{
    public string Name { get; init; }
    public int RewardXp { get; init; }

    public Enemy(Models.Enemy model) : base(
        level: model.Difficulty,
        maxEnergy: 999999,
        maxHP: model.MaxHp,
        skillRefs: model.Skills,
        animationClassName: model.AnimationClass
    )
    {
        Name = model.Name;
        RewardXp = model.RewardXp;
    }



    public BattleAction ChooseAction()
    {
        Random rand = new Random();
        int index = rand.Next(Skills.Count);
        return Skills[index];
    }

}