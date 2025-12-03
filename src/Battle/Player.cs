using System;

namespace EchoReborn.Battle;

class Player
{
    public string Name { get; }
    public int HP { get; private set; }

    public Player(string name, int hp)
    {
        Name = name;
        HP = hp;
    }

   

    public Action ChooseAction()
    {
        // ici on pourra par exemple définir et retourner plusieurs actions(attack,bite,legkick,etc...) ,pas seulemnt un 
        
        
        return new Action("Attack", 20);
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        
    }

    public bool IsAlive() => HP > 0;
}