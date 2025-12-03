
using EchoReborn.UI;
using EchoReborn.Battle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EchoReborn.Screens
{
    public class BattleScreen : IScreen
    {
        private Character _player;
        private CharacterHud _hud;
        private BattleSystem _battleSystem;

        private Texture2D _pixel;   

        public BattleScreen(Character player)
        {
            _battleSystem = new BattleSystem(player, new Enemy(1));
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
