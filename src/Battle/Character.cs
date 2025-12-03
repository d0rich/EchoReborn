using System;

namespace EchoReborn.Battle;

public class Character : BattleActor
{
    public int Exp { get; private set; }
    public int NextLevelExp => 100;
    public Character(int level, int exp ): base(level)
    {
        Exp = exp;
    }
}
// CHANGER POUR TRAVAILLER DANS MONOGAME 