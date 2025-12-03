using System;

namespace EchoReborn.Battle;

public class Character : BattleActor
{
    public int Exp { get; private set; }
    public int NextLevelExp () =>100;
    public Character(int level,int exp ): base(level)
    {
        Exp = exp;
    }

   

    public BattleAction ChooseAction()
    {
        // ici on pourra par exemple définir et retourner plusieurs actions(attack,bite,legkick,etc...) ,pas seulemnt un 
        
        
        return new BattleAction("Attack", 20);
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        
    }

    public bool IsAlive() => HP > 0;
}
// CHANGER POUR TRAVAILLER DANS MONOGAME 