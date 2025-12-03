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
    public int Energy { get; }
    public int MaxEnergy => 100;
    

    public bool IsDead => HP <= 0;
    public bool IsAlive => HP > 0;
    public BattleActor( int level)
    {
        Level = level;
        HP = MaxHP;
        Energy = MaxEnergy;
        


    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
    }

    public void Heal(int amount)
    {
        HP += amount;
        if (HP > MaxHP) HP = MaxHP;
    }
}