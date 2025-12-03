using Microsoft.Xna.Framework;
using EchoReborn.Battle;

namespace EchoReborn.UI.Components;

public class HpBar : RessourceBar
{
    private Character _character;
    public HpBar(Vector2 position, Character character)
        : base(position)
    {
        _character = character;
    }

    protected override int CurrentValue => _character.HP;

    protected override int MaxValue => _character.MaxHP;

    protected override string Label => "HP";

    protected override Color BgColor => Color.DarkRed;

    protected override Color FgColor => Color.Red;
}