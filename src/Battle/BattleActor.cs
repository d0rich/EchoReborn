using System.Collections.Generic;
using EchoReborn.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System;

namespace EchoReborn.Battle;

public abstract  class BattleActor
{
    public int Level { get; protected set; }
    public int MaxHP { get; protected set; }
    public int HP { get; protected set; }
    public int Energy { get; protected set; }
    public int MaxEnergy { get; protected set; }

    public IBattleActorAnimations Animations { get; protected set; }
    protected String AnimationClassName = null;
    

    public bool IsDead => HP <= 0;
    public bool IsAlive => HP > 0;

    private List<BattleAction> _skills;

    public List<BattleAction> Skills => new List<BattleAction>(_skills);

    protected BattleActor(int level, int maxEnergy, int maxHP, List<BattleAction> skills, string animationClassName = null)
    {
        Level = level;
        MaxHP = maxHP;
        HP = MaxHP;
        MaxEnergy = maxEnergy;
        Energy = MaxEnergy;
        _skills = skills;
        AnimationClassName = animationClassName;
    }

    protected BattleActor(int level, int maxEnergy, int maxHP, Collection<int> skillRefs, string animationClassName = null) : this(
        level: level, 
        maxEnergy: maxEnergy,
        maxHP: maxHP,
        skills: DataManager
            .LoadSkillsByIds(skillRefs)
            .Select(s => new BattleAction(s))
            .ToList(),
        animationClassName: animationClassName
        ) { }

    public bool LoadAnimations(IBattleActorAnimations animations)
    {
        if (Animations != null)
        {
            return false;
        }
        Animations = animations;
        return true;
    }
    
    public bool LoadAnimations(string className)
    { 
        Type animType = Type.GetType($"EchoReborn.UI.Characters.{className}");
        if (animType == null)
        {
            throw new Exception($"Animation class '{className}' not found.");
        }
        IBattleActorAnimations animations = (IBattleActorAnimations)Activator.CreateInstance(animType);
        return LoadAnimations(animations);
    }

    public bool LoadAnimations()
    {
        if (AnimationClassName == null)
        {
            return false;
        }
        return LoadAnimations(AnimationClassName);
    }

    public void SpendEnergy(int amount)
    {
        Energy -= amount;
        if (Energy < 0) Energy = 0;
    }

    public void RestoreEnergy(int amount)
    {
        Energy += amount;
        if (Energy > MaxEnergy) Energy = MaxEnergy;
    }

    public void SpendHealth(int amount)
    {
        TakeDamage(amount);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
    }

    public void GetHeal(int amount)
    {
        HP += amount;
        if (HP > MaxHP) HP = MaxHP;
    }
}