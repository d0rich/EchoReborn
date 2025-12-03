using EchoReborn.Battle;
using EchoReborn.UI.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI
{
    /// <summary>
    /// Affichage d’un Character (niveau, HP, Energie, XP)
    /// </summary>
    public class CharacterHud
    {
        private readonly Character _character;
        private BattleSystem _battleSystem;
        private SpriteFont _font = GameFonts.ButtonFont;

        private readonly LevelDiamond _levelDiamond;
        private readonly HpBar _hpBar;
        private readonly EnergyBar _energyBar;
        private readonly XpBar _xpBar;

        public CharacterHud(Character character)
        {
            _character = character;
            _battleSystem = new BattleSystem(character, new Enemy(1));

            // Layout
            int barSpacing = 8;

            _levelDiamond = new LevelDiamond(new Vector2(60, 20), character.Level);
            _hpBar = new HpBar(new Vector2(140, 60), character);
            _energyBar = new EnergyBar(new Vector2(140, 60 + RessourceBar.Size.Y + barSpacing), character);
            _xpBar = new XpBar(new Vector2(140, 60 + 2 * (RessourceBar.Size.Y + barSpacing)), character);
        }

        public void Draw()
        {
            SpriteBatch spriteBatch = DrawingContext.SpriteBatch;


            //  Niveau 
            _levelDiamond.Draw();

            //  Barres de stats
            _hpBar.Draw();
            _energyBar.Draw();
            _xpBar.Draw();

            //  Label "Character"
            spriteBatch.DrawString(
                GameFonts.ButtonFont,
                "Character",
                new Vector2(20, 120),
                Color.Black);
        }
    }
}
