
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


        public BattleScreen(Character player)
        {
            _battleSystem = new BattleSystem(player, new Enemy(1));
            _player = player;
            LoadContent();
        }

        private void LoadContent()
        {

            
            _hud = new CharacterHud( _player );
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            DrawingContext.GraphicsDevice.Clear(Color.Cornsilk);

            SpriteBatch sb = DrawingContext.SpriteBatch;
            sb.Begin();

            _hud.Draw();

            sb.End();
        }

        public void Destroy()
        {
            
        }
    }
}
