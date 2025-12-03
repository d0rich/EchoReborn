using System;
// RENOMMER EN BATTLE ACTION
namespace EchoReborn.Battle;

 public class BattleAction
{
    public string Name { get; }
    public int Damage { get; }
    // on peut définir plusier actions (legkick,bite,headkick,etc...)
    public BattleAction(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public void Execute(Character target)
    {
        
        target.TakeDamage(Damage);
    }

    public void Execute(Enemy target)
    {
        
        target.TakeDamage(Damage);
    }
}