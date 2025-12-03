using EchoReborn.Battle;
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
        private readonly Texture2D _pixel;         
        private readonly Texture2D _characterSprite;
        private readonly SpriteFont _font;

        private readonly Vector2 _position;       

        private readonly Rectangle _hpBarRect;
        private readonly Rectangle _energyBarRect;
        private readonly Rectangle _xpBarRect;

        public CharacterHud(
            Character character,
            Texture2D pixel,
            Texture2D characterSprite,
            SpriteFont font,
            Vector2 position)
        {
            _character = character;
            _battleSystem = new BattleSystem(character, new Enemy(1));
            _pixel = pixel;
            _characterSprite = characterSprite;
            _font = font;
            _position = position;

            // Layout
            int barWidth = 220;
            int barHeight = 28;
            int barSpacing = 8;

            Vector2 barStart = position + new Vector2(140, 60);

            _hpBarRect = new Rectangle((int)barStart.X,
                                       (int)barStart.Y,
                                       barWidth,
                                       barHeight);

            _energyBarRect = new Rectangle(
                _hpBarRect.X,
                _hpBarRect.Y + barHeight + barSpacing,
                barWidth,
                barHeight);

            _xpBarRect = new Rectangle(
                _energyBarRect.X,
                _energyBarRect.Y + barHeight + barSpacing,
                barWidth,
                barHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Sprite du personnage
            Vector2 charPos = _position + new Vector2(40, 60);
            spriteBatch.Draw(_characterSprite, charPos, Color.White);

            //  Niveau 
            DrawLevelDiamond(spriteBatch);

            //  Barres de stats
            DrawHpBar(spriteBatch);
            DrawEnergyBar(spriteBatch);
            DrawXpBar(spriteBatch);

            //  Label "Character"
            spriteBatch.DrawString(
                _font,
                "Character",
                _position + new Vector2(20, 120),
                Color.Black);
        }

        // ---------- Barres ----------

        private void DrawHpBar(SpriteBatch spriteBatch)
        {
            float ratio = _character.HP / (float)_character.MaxHP;

            DrawBar(spriteBatch, _hpBarRect, ratio, Color.Red);

            string text = $"{_character.HP}/{_character.MaxHP}";
            DrawCenteredText(spriteBatch, text, _hpBarRect);

            spriteBatch.DrawString(
                _font,
                "HP",
                new Vector2(_hpBarRect.X - 35, _hpBarRect.Y + 4),
                Color.Black);
        }

        private void DrawEnergyBar(SpriteBatch spriteBatch)
        {
            float ratio = _character.Energy / (float)_character.MaxEnergy;

            DrawBar(spriteBatch, _energyBarRect, ratio, Color.Gold);

            string text = $"{_character.Energy}/{_character.MaxEnergy}";
            DrawCenteredText(spriteBatch, text, _energyBarRect);

            spriteBatch.DrawString(
                _font,
                "Energy",
                new Vector2(_energyBarRect.X - 70, _energyBarRect.Y + 4),
                Color.Black);
        }

        private void DrawXpBar(SpriteBatch spriteBatch)
        {
            float ratio = _character.Exp / (float)_character.NextLevelExp;

            DrawBar(spriteBatch, _xpBarRect, ratio, Color.CornflowerBlue);

            string text = $"{_character.Exp}/{_character.NextLevelExp}";
            DrawCenteredText(spriteBatch, text, _xpBarRect);

            spriteBatch.DrawString(
                _font,
                "XP",
                new Vector2(_xpBarRect.X - 30, _xpBarRect.Y + 4),
                Color.Black);
        }

        private void DrawBar(SpriteBatch spriteBatch, Rectangle rect, float ratio, Color fillColor)
        {
            ratio = MathHelper.Clamp(ratio, 0f, 1f);

            
            spriteBatch.Draw(_pixel, rect, Color.White * 0.2f);

            // Remplissage
            int filledWidth = (int)(rect.Width * ratio);
            var filledRect = new Rectangle(rect.X, rect.Y, filledWidth, rect.Height);
            spriteBatch.Draw(_pixel, filledRect, fillColor * 0.8f);

            // Bord
            DrawRectangleBorder(spriteBatch, rect, Color.Black, 2);
        }

        private void DrawRectangleBorder(SpriteBatch spriteBatch, Rectangle rect, Color color, int thickness)
        {
            
            spriteBatch.Draw(_pixel, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color);
            
            spriteBatch.Draw(_pixel, new Rectangle(rect.X, rect.Bottom - thickness, rect.Width, thickness), color);
            
            spriteBatch.Draw(_pixel, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color);
            
            spriteBatch.Draw(_pixel, new Rectangle(rect.Right - thickness, rect.Y, thickness, rect.Height), color);
        }

        private void DrawCenteredText(SpriteBatch spriteBatch, string text, Rectangle rect)
        {
            Vector2 size = _font.MeasureString(text);
            Vector2 pos = new Vector2(
                rect.X + (rect.Width - size.X) / 2f,
                rect.Y + (rect.Height - size.Y) / 2f);

            spriteBatch.DrawString(_font, text, pos, Color.Orange);
        }

        // ---------- Losange du niveau ----------

        private void DrawLevelDiamond(SpriteBatch spriteBatch)
        {
            // On dessine un carré
            Vector2 center = _position + new Vector2(60, 20);
            int size = 32;

            
            Rectangle dest = new Rectangle(
                (int)center.X,
                (int)center.Y,
                size,
                size);

            // On dessine le carre
            spriteBatch.Draw(
                _pixel,
                destinationRectangle: dest,
                sourceRectangle: null,
                color: Color.White,
                rotation: MathHelper.PiOver4,      
                origin: new Vector2(0.5f, 0.5f),   
                effects: SpriteEffects.None,
                layerDepth: 0f);

            
            Rectangle borderRect = new Rectangle(
                dest.X - size / 2,
                dest.Y - size / 2,
                size,
                size);
            DrawRectangleBorder(spriteBatch, borderRect, Color.Black, 2);

            // Texte du niveau
            string lvl = _character.Level.ToString();
            Vector2 textSize = _font.MeasureString(lvl);
            spriteBatch.DrawString(
                _font,
                lvl,
                center - textSize / 2f,
                Color.Black);
        }
    }
}
