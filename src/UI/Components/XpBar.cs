using Microsoft.Xna.Framework;
using EchoReborn.Battle;

namespace EchoReborn.UI.Components;

public class XpBar : RessourceBar
{
    private Character _character;
    public XpBar(Vector2 position, Character character)
        : base(position)
    {
        _character = character;
    }

    protected override int CurrentValue => _character.Exp;

    protected override int MaxValue => _character.NextLevelExp;

    protected override string Label => "XP";

    protected override Color BgColor => Color.DarkGreen;

    protected override Color FgColor => Color.Green;
}