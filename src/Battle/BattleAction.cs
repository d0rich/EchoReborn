using System;
// RENOMMER EN BATTLE ACTION
namespace EchoReborn.Battle;

public class BattleAction
{
    public enum TargetType { Enemy, Ally }
    public string Name { get; }
    public string Description { get; }
    public TargetType Target { get; }
    public int EnergyCost { get; }
    public int HealthCost { get; }
    public int Damage { get; }
    public int HealAmount { get; }
    
    public BattleAction(
        string name,
        string description,
        TargetType target,
        int energyCost,
        int healthCost,
        int damage = 0,
        int healAmount = 0)
    {
        Name = name;
        Description = description;
        Target = target;
        EnergyCost = energyCost;
        HealthCost = healthCost;
        Damage = damage;
        HealAmount = healAmount;
    }

    public void Execute(BattleActor caster, BattleActor target)
    {
        if (EnergyCost > 0) {
            caster.SpendEnergy(EnergyCost);
        }
        if (HealthCost > 0) {
            caster.SpendHealth(HealthCost);
        }
        if (Damage > 0) {
            target.TakeDamage(Damage);
        }
        if (HealAmount > 0) {
            target.GetHeal(HealAmount);
        }
    }
}