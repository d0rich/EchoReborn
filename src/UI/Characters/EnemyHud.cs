using EchoReborn.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI
{
    /// <summary>
    /// HUD simple pour un ennemi : niveau, sprite, HP.
    /// </summary>
    public class EnemyHud
    {
        private readonly Enemy _enemy;
        private readonly Texture2D _pixel;
        private readonly Texture2D _sprite;
        private readonly SpriteFont _font;
        private readonly Vector2 _pos;

        private readonly Rectangle _hpBar;

        public EnemyHud(Enemy enemy,
                        Texture2D pixel,
                        Texture2D sprite,
                        SpriteFont font,
                        Vector2 position)
        {
            _enemy = enemy;
            _pixel = pixel;
            _sprite = sprite;
            _font = font;
            _pos = position;

            // Barre de vie : en bas à gauche de la zone ennemi
            int barWidth = 260;
            int barHeight = 24;
            _hpBar = new Rectangle(
                (int)_pos.X - barWidth - 40,            // à gauche du perso
                (int)_pos.Y + 70,                       // un peu sous le centre
                barWidth,
                barHeight);
        }

        public void Draw(SpriteBatch sb)
        {
            DrawEnemySpriteAndTexts(sb);
            DrawLevelDiamond(sb);
            DrawHpBar(sb);
        }

        // ---------------- SPRITE + TEXTES ----------------

        private void DrawEnemySpriteAndTexts(SpriteBatch sb)
        {
            // Sprite de l’ennemi (stickman)
            Rectangle spriteRect = new Rectangle(
                (int)_pos.X,
                (int)_pos.Y,
                80,
                110);

            sb.Draw(_sprite, spriteRect, Color.White);

            // Texte "Enemy" sous le sprite
            string name = _enemy.Name ?? "Enemy";
            Vector2 nameSize = _font.MeasureString(name);
            Vector2 namePos = new Vector2(
                spriteRect.X + (spriteRect.Width - nameSize.X) / 2,
                spriteRect.Bottom + 5);

            sb.DrawString(_font, name, namePos, Color.Black);
        }

        // ---------------- LOSANGE DU NIVEAU ----------------

        private void DrawLevelDiamond(SpriteBatch sb)
        {
            // Position au-dessus de la tête de l’ennemi
            Vector2 center = new Vector2(_pos.X + 40, _pos.Y - 25);
            int size = 32;

            // carré tourné
            Rectangle dest = new Rectangle((int)center.X, (int)center.Y, size, size);

            sb.Draw(_pixel, dest, null,
                Color.White,
                MathHelper.PiOver4,
                new Vector2(0.5f, 0.5f),
                SpriteEffects.None,
                0f);

            // bord noir
            DrawBorder(sb, new Rectangle(dest.X - size / 2, dest.Y - size / 2, size, size), 2, Color.Black);

            // texte du niveau/difficulté
            string lvl = _enemy.Difficulty.ToString();
            Vector2 lvlSize = _font.MeasureString(lvl);
            sb.DrawString(_font, lvl, center - lvlSize / 2, Color.Black);
        }

        // ---------------- BARRE DE HP ----------------

        private void DrawHpBar(SpriteBatch sb)
        {
            float ratio = _enemy.MaxHP > 0 ? (float)_enemy.CurrentHP / _enemy.MaxHP : 0f;
            ratio = MathHelper.Clamp(ratio, 0f, 1f);

            // Fond
            sb.Draw(_pixel, _hpBar, Color.White * 0.8f);

            // Remplissage
            int filledWidth = (int)(_hpBar.Width * ratio);
            Rectangle filled = new Rectangle(_hpBar.X, _hpBar.Y, filledWidth, _hpBar.Height);
            sb.Draw(_pixel, filled, Color.Red * 0.85f);

            // Bordure
            DrawBorder(sb, _hpBar, 2, Color.Black);

            // Texte centré (ex : 40/100)
            string txt = $"{_enemy.CurrentHP}/{_enemy.MaxHP}";
            Vector2 txtSize = _font.MeasureString(txt);
            Vector2 txtPos = new Vector2(
                _hpBar.X + (_hpBar.Width - txtSize.X) / 2,
                _hpBar.Y + (_hpBar.Height - txtSize.Y) / 2);

            sb.DrawString(_font, txt, txtPos, Color.Black);

            // Label "HP" à droite de la barre
            Vector2 hpPos = new Vector2(_hpBar.Right + 8, _hpBar.Y + (_hpBar.Height - _font.LineSpacing) / 2);
            sb.DrawString(_font, "HP", hpPos, Color.Black);
        }

        // ---------------- OUTIL : BORDURE ----------------

        private void DrawBorder(SpriteBatch sb, Rectangle rect, int thickness, Color color)
        {
            sb.Draw(_pixel, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color);
            sb.Draw(_pixel, new Rectangle(rect.X, rect.Bottom - thickness, rect.Width, thickness), color);
            sb.Draw(_pixel, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color);
            sb.Draw(_pixel, new Rectangle(rect.Right - thickness, rect.Y, thickness, rect.Height), color);
        }
    }
}
