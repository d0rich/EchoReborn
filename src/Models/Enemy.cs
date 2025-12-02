namespace EchoReborn.Models;
using System.Collections.Generic;


public class Enemy
{
    public int Id { get; }
    public string Name { get; }
    public int MaxHP { get; }
    public int CurrentHP { get; private set; }
    public List<int> SkillIds { get; }
    public string AnimationClass { get; }
    public int RewardXP { get; }

    public bool IsDead => CurrentHP <= 0;

    public Enemy(int id, string name, int maxHP, List<int> skillIds, string animationClass, int rewardXP)
    {
        Id = id;
        Name = name;
        MaxHP = maxHP;
        CurrentHP = maxHP;
        SkillIds = skillIds ?? new List<int>();
        AnimationClass = animationClass;
        RewardXP = rewardXP;
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP < 0) CurrentHP = 0;
    }

    public void Heal(int amount)
    {
        CurrentHP += amount;
        if (CurrentHP > MaxHP) CurrentHP = MaxHP;
    }
}