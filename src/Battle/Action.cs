using System;

namespace EchoReborn.Battle;

class Action
{
    public string Name { get; }
    public int Damage { get; }

    public Action(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public void Execute(Player target)
    {
        Console.WriteLine($"Action {Name} hits player!");
        target.TakeDamage(Damage);
    }

    public void Execute(Enemy target)
    {
        Console.WriteLine($"Action {Name} hits enemy!");
        target.TakeDamage(Damage);
    }
}