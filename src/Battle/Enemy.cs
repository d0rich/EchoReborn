using System;
using System.Collections.Generic;

namespace EchoReborn.Battle;

public class Enemy : BattleActor

{


    public Enemy(int level, List<BattleAction> skills) : base(level, skills)
    {

    }



    public BattleAction ChooseAction()
    {
        Random rand = new Random();
        int index = rand.Next(Skills.Count);
        return Skills[index];
    }

}