using EchoReborn.Battle;
using EchoReborn.UI.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI;
public class CharacterHud
{
    private readonly Character _character;
    private readonly Enemy _enemy;
    private BattleSystem _battleSystem;
    private SpriteFont _font = GameFonts.ButtonFont;

    private readonly LevelDiamond _charlevel;
    private readonly LevelDiamond _enemylevel;
    private readonly HpBar _hpBar;
    private readonly HpBar _enemyHpBar;
    private readonly EnergyBar _energyBar;
    private readonly XpBar _xpBar;
    private readonly Rectangle _frameRect = new Rectangle(0, 530, 1280, 300);

    private SkillsList _skillsList;

    public CharacterHud(Character character, Enemy enemy, BattleSystem battleSystem)
    {
        _character = character;
        _enemy = enemy;
        _battleSystem = battleSystem;

        // Layout
        int barSpacing = 8;

        _charlevel = new LevelDiamond(new Vector2(60, 580), character.Level);
        _enemylevel = new LevelDiamond(new Vector2(1260, 580), enemy.Level);
        Vector2 barsPsn = new Vector2(160, 580);
        _hpBar = new HpBar(barsPsn, character);
        _enemyHpBar = new HpBar(barsPsn + new Vector2(800, 0), enemy);
        _energyBar = new EnergyBar(barsPsn + new Vector2(0, RessourceBar.Size.Y + barSpacing), character);
        _xpBar = new XpBar(barsPsn + new Vector2(0, 2 * (RessourceBar.Size.Y + barSpacing)), character);
        _skillsList = new SkillsList(
            position: new Vector2(400, 580),
            skills: character.Skills,
            onSkillButtonClicked: (skill) =>
            {
                _battleSystem.AcceptPlayerAction(skill);
            });
    }

    public void Draw()
    {
        SpriteBatch spriteBatch = DrawingContext.SpriteBatch;

        spriteBatch.Draw(
            DrawingContext.CreateTexture(Color.LightGray * 0.5f),
            _frameRect,
            Color.Wheat);


        //  Niveau 
        _charlevel.Draw();

        //  Barres de stats
        _hpBar.Draw();
        _energyBar.Draw();
        _xpBar.Draw();

        //  Label "Character"
        spriteBatch.DrawString(
            GameFonts.ButtonFont,
            "Character",
            new Vector2(20, 680),
            Color.Black);

        _enemylevel.Draw();
        _enemyHpBar.Draw();

        spriteBatch.DrawString(
            GameFonts.ButtonFont,
            "Enemy",
            new Vector2(1200, 680),
            Color.Black);

        if (_battleSystem.State == BattleEtape.PENDING_PLAYER)
        {
            //  Compétences
            _skillsList.Draw();
        }
    }
}
