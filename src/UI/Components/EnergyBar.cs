using Microsoft.Xna.Framework;
using EchoReborn.Battle;

namespace EchoReborn.UI.Components;

public class EnergyBar : RessourceBar
{
    private BattleActor _actor;
    public EnergyBar(Vector2 position, BattleActor actor)
        : base(position)
    {
        _actor = actor;
    }

    protected override int CurrentValue => _actor.Energy;

    protected override int MaxValue => _actor.MaxEnergy;

    protected override string Label => "Energy";

    protected override Color BgColor => Color.DarkBlue;

    protected override Color FgColor => Color.Blue;
}
