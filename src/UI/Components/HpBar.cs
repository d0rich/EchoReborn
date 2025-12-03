using Microsoft.Xna.Framework;
using EchoReborn.Battle;

namespace EchoReborn.UI.Components;

public class HpBar : RessourceBar
{
    private BattleActor _actor;
    public HpBar(Vector2 position, BattleActor actor)
        : base(position)
    {
        _actor = actor;
    }

    protected override int CurrentValue => _actor.HP;

    protected override int MaxValue => _actor.MaxHP;

    protected override string Label => "HP";

    protected override Color BgColor => Color.DarkRed;

    protected override Color FgColor => Color.Red;
}