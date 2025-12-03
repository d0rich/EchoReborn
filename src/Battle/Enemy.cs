using System;

namespace EchoReborn.Battle;

public class Enemy : BattleActor

{


public Enemy(int level) : base(level)
{

}



public BattleAction ChooseAction()
{
    Random rand = new Random();
    int
        num = rand.Next(
            2); // générer un numéro aléatoire qui va définir la prochaine action de l'ennemi ,on peut fait autant qu'on veut bien sur

    switch (num)
    {
        case 0:
            return new BattleAction("kick", 20);
        case 1:
            return new BattleAction("punch", 50);
        default:
            return new BattleAction("kick", 20); // normalement ça ne doit jamais passer ça 
            break;




    }
}

}