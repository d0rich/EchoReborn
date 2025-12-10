using System;
// RENOMMER EN BATTLE ACTION
namespace EchoReborn.Battle;
using Models = EchoReborn.Data.Models.Generated;

public class BattleAction
{
    public enum TargetType { Enemy, Ally }
    public int Id { get; init; }
    public string Name { get; }
    public string Description { get; }
    public TargetType Target { get; }
    public int EnergyCost { get; }
    public int HealthCost { get; }
    public int Damage { get; }
    public int HealAmount { get; }
    
    public BattleAction(
        int id,
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

    public BattleAction(Models.Skill skillData) : this(
        id: skillData.Id,
        name: skillData.Name,
        description: skillData.Description,
        target: skillData.TargetType == Models.TargetType.Enemies ? TargetType.Enemy : TargetType.Ally,
        energyCost: skillData.ManaCost,
        healthCost: skillData.HealthCost,
        damage: skillData.Damage,
        healAmount: skillData.Heal
    ) {}

    public void Execute(BattleActor caster, BattleActor target)
    {
        caster.Animations?.PlayAttack();
        if (EnergyCost > 0) {
            caster.SpendEnergy(EnergyCost);
        }
        if (HealthCost > 0) {
            caster.SpendHealth(HealthCost);
        }
        if (Damage > 0) {
            target.TakeDamage(Damage);
            target.Animations?.PlayHurt();
        }
        if (HealAmount > 0) {
            target.GetHeal(HealAmount);
        }
    }
}