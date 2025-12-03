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
        private readonly Rectangle _frameRect = new Rectangle(0, 530, 1280, 300);

        public CharacterHud(Character character)
        {
            _character = character;
            _battleSystem = new BattleSystem(character, new Enemy(1));

            // Layout
            int barSpacing = 8;

            _levelDiamond = new LevelDiamond(new Vector2(60, 580), character.Level);
            Vector2 barsPsn = new Vector2(160, 580);
            _hpBar = new HpBar(barsPsn, character);
            _energyBar = new EnergyBar(barsPsn + new Vector2(0, RessourceBar.Size.Y + barSpacing), character);
            _xpBar = new XpBar(barsPsn + new Vector2(0, 2 * (RessourceBar.Size.Y + barSpacing)), character);
        }

        public void Draw()
        {
            SpriteBatch spriteBatch = DrawingContext.SpriteBatch;

            spriteBatch.Draw(
                DrawingContext.CreateTexture(Color.LightGray * 0.5f),
                _frameRect,
                Color.Wheat);


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
                new Vector2(20, 680),
                Color.Black);
        }
    }
}
