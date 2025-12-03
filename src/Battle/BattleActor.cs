using System.Collections.Generic;

namespace EchoReborn.Battle;

public abstract  class BattleActor
{
    
    /*
     *
     * +Level: int
       
       +HP: int
       
       +MaxHP: int
       
       +Energy: int
       
       +MaxEnergy: int
     */
    public int Level { get; }
    public int MaxHP => 100;
    public int HP { get; protected set; }
    public int Energy { get; protected set; }
    public int MaxEnergy => 100;
    

    public bool IsDead => HP <= 0;
    public bool IsAlive => HP > 0;

    private List<BattleAction> _skills;

    public List<BattleAction> Skills => new List<BattleAction>(_skills);

    public BattleActor(int level, List<BattleAction> skills)
    {
        Level = level;
        HP = MaxHP;
        Energy = MaxEnergy;
        _skills = skills;
    }

    public void SpendEnergy(int amount)
    {
        Energy -= amount;
        if (Energy < 0) Energy = 0;
    }

    public void RestoreEnergy(int amount)
    {
        Energy += amount;
        if (Energy > MaxEnergy) Energy = MaxEnergy;
    }

    public void SpendHealth(int amount)
    {
        TakeDamage(amount);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
    }

    public void GetHeal(int amount)
    {
        HP += amount;
        if (HP > MaxHP) HP = MaxHP;
    }
}