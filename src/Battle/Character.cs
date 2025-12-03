using System.Collections.Generic;

namespace EchoReborn.Battle;

public class Character : BattleActor
{
    public int Exp { get; private set; }
    public int NextLevelExp => 100;
    public Character(int level, int exp, List<BattleAction> skills): base(level, skills)
    {
        Exp = exp;
    }
}
// CHANGER POUR TRAVAILLER DANS MONOGAME 