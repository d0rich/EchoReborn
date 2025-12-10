using System.Collections.Generic;
using Models = EchoReborn.Data.Models.Generated;

namespace EchoReborn.Battle;

public class Character : BattleActor
{
    public int Exp { get; private set; }
    public int NextLevelExp => 50 * Level;

    public Character(Models.Character model) : base(
        level: model.Level, 
        maxEnergy: model.MaxMana,
        maxHP: model.MaxHealth,
        skillRefs: model.Skills,
        animationClassName: "WandererMagicianAnimation"
    )
    {
        Exp = model.Experience;
    }
    
    public void GainExp(int amount)
    {
        Exp += amount;
        while (Exp >= NextLevelExp)
        {
            LevelUp();
        }
    }
    
    public void LevelUp()
    {
        Exp -= NextLevelExp;
        MaxHP += 20;
        HP = MaxHP;
        MaxEnergy += 10;
        Energy = MaxEnergy;
        Level += 1;
    }
}