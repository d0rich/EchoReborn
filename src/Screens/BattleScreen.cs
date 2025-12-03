using EchoReborn.Model;
using EchoReborn.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EchoReborn.Screens
{
    public class BattleScreen : IScreen
    {
        private Character _player;
        private Enemy _enemy;

        private CharacterHud _playerHud;
        private EnemyHud _enemyHud;

        private Texture2D _pixel;
        private Texture2D _playerSprite;
        private Texture2D _enemySprite;

        public BattleScreen(Character player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
            LoadContent();
        }

        private void LoadContent()
        {
            _pixel = new Texture2D(DrawingContext.GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

            _playerSprite = _pixel; // placeholder
            _enemySprite = _pixel;  // placeholder

            _playerHud = new CharacterHud(_player, _pixel, _playerSprite, GameFonts.ButtonFont, new Vector2(80, 350));
            _enemyHud = new EnemyHud(_enemy, _pixel, _enemySprite, GameFonts.ButtonFont, new Vector2(1000, 200));
        }

        public void Update(GameTime gameTime)
        {
            // ici tu peux faire bouger les HP pour tester
        }

        public void Draw(GameTime gameTime)
        {
            DrawingContext.GraphicsDevice.Clear(Color.Cornsilk);
            var sb = DrawingContext.SpriteBatch;

            sb.Begin();
            _playerHud.Draw(sb);
            _enemyHud.Draw(sb);
            sb.End();
        }

        public void Destroy()
        {
            _pixel?.Dispose();
        }
    }
}
