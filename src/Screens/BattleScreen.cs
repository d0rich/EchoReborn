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
        private readonly Character _player;
        private CharacterHud _hud;

        private Texture2D _pixel;   

        public BattleScreen(Character player)
        {
            _player = player;
            LoadContent();
        }

        private void LoadContent()
        {
            // On crée une simple texture 1x1 blanche
            _pixel = new Texture2D(DrawingContext.GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

            
            _hud = new CharacterHud(
                _player,
                _pixel,             
                _pixel,              
                GameFonts.ButtonFont,
                new Vector2(100, 100)
            );
        }

        public void Update(GameTime gameTime)
        {
            // Juste un test 
            var k = Keyboard.GetState();
            if (k.IsKeyDown(Keys.H))
            {
                _player.CurrentHealth = Math.Max(0, _player.CurrentHealth - 1);
            }
        }

        public void Draw(GameTime gameTime)
        {
            DrawingContext.GraphicsDevice.Clear(Color.Cornsilk);

            SpriteBatch sb = DrawingContext.SpriteBatch;
            sb.Begin();

            _hud.Draw(sb);

            sb.End();
        }

        public void Destroy()
        {
            _pixel?.Dispose();
        }
    }
}
