using Microsoft.Xna.Framework;
using EchoReborn.Battle;

namespace EchoReborn.UI.Components;

public class EnergyBar : RessourceBar
{
    private Character _character;
    public EnergyBar(Vector2 position, Character character)
        : base(position)
    {
        _character = character;
    }

    protected override int CurrentValue => _character.Energy;

    protected override int MaxValue => _character.MaxEnergy;

    protected override string Label => "Energy";

    protected override Color BgColor => Color.DarkBlue;

    protected override Color FgColor => Color.Blue;
}
