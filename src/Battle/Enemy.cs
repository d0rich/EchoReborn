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
        Random rand = new Random();
        int
            num = rand.Next(
                2); // générer un numéro aléatoire qui va définir la prochaine action de l'ennemi ,on peut fait autant qu'on veut bien sur

        switch (num)
        {
            case 0:
                return new Action("kick", 20);
            case 1:
                return new Action("punch", 50);
            default:
                return new Action("kick", 20); // normalement ça ne doit jamais passer ça 
                break;




        }
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        Console.WriteLine($"{Name} takes {dmg} damage! ({HP} HP left)");
    }

    public bool IsAlive() => HP > 0;
}