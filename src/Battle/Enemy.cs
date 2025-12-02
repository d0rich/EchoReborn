using System;

namespace EchoReborn.Battle;

class Enemy
{
    public string Name { get; }
    public int HP { get; private set; }

    public Enemy(string name, int hp)
    {
        Name = name;
        HP = hp;
    }

    public void Initialize()
    {
        Console.WriteLine($"{Name} appears! ({HP} HP)");
    }

    public Action ChooseAction()
    {
        Console.WriteLine($"{Name} attacks!");
        return new Action("Claw", 15);
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        Console.WriteLine($"{Name} takes {dmg} damage! ({HP} HP left)");
    }

    public bool IsAlive() => HP > 0;
}