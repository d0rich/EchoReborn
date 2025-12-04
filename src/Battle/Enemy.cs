using System;
using System.Collections.Generic;
using Models = EchoReborn.Data.Models.Generated;

namespace EchoReborn.Battle;

public class Enemy : BattleActor

{


    public Enemy(int level, List<BattleAction> skills) : base(level, skills)
    { }

    public Enemy(int level, Models.Enemy model) : base(
        level, 
        model.Skills
    ) { }



    public BattleAction ChooseAction()
    {
        Random rand = new Random();
        int index = rand.Next(Skills.Count);
        return Skills[index];
    }

}