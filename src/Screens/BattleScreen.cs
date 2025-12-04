
using EchoReborn.UI;
using EchoReborn.Battle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using EchoReborn.Data;
using ModelMesh = EchoReborn.Data.Models.Generated;
using System.Linq;

namespace EchoReborn.Screens
{
    public class BattleScreen : IScreen
    {
        private Character _player;
        private Enemy _enemy;
        private CharacterHud _hud;
        private BattleSystem _battleSystem;


        public BattleScreen()
        {
            _player = new Character(DataManager.LoadBaseCharacter());
            _enemy = new Enemy(1, DataManager.LoadAllEnemies().First());
            _battleSystem = new BattleSystem(_player, _enemy);
            _hud = new CharacterHud( _player, _enemy, _battleSystem );
        }

        public void Update(GameTime gameTime)
        {
            _hud.Update();
            _battleSystem.Update();
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
