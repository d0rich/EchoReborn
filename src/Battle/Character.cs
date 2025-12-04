using System.Collections.Generic;
using Models = EchoReborn.Data.Models.Generated;

namespace EchoReborn.Battle;

public class Character : BattleActor
{
    public int Exp { get; private set; }
    public int NextLevelExp => 100;
    public Character(int level, int exp, List<BattleAction> skills): base(level, skills)
    {
        Exp = exp;
    }

    public Character(Models.Character model) : base(
        model.Level, 
        model.Skills
    )
    {
        Exp = model.Experience;
    }
}