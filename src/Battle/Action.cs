using System;

namespace EchoReborn.Battle;

class Action
{
    public string Name { get; }
    public int Damage { get; }
    // on peut définir plusier actions (legkick,bite,headkick,etc...)
    public Action(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public void Execute(Player target)
    {
        
        target.TakeDamage(Damage);
    }

    public void Execute(Enemy target)
    {
        
        target.TakeDamage(Damage);
    }
}