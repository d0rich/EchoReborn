
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
    public class BattleSequenceScreen : IScreen
    {
        private Character _player;
        private BattleUI _hud;
        private BattleSystem _battleSystem;
        
        private Queue<Enemy> _enemyQueue = new Queue<Enemy>();


        public BattleSequenceScreen()
        {
            _player = new Character(DataManager.LoadBaseCharacter());
            _hud = new BattleUI( _player );
            for (int i = 0; i < 5; i++)
            {
                var enemyData = new Enemy(1, DataManager.LoadAllEnemies().First());
                _enemyQueue.Enqueue(enemyData);
            }
        }

        public void Update(GameTime gameTime)
        {
            _hud.Update(gameTime);
            _battleSystem?.Update(gameTime);
            
            if (_hud.CanInitiateNewBattle && _enemyQueue.Count > 0)
            {
                var enemy = _enemyQueue.Dequeue();
                _battleSystem = new BattleSystem(_player, enemy);
                _hud.NewBattle(enemy, _battleSystem);
            }
        }

        public void Draw(GameTime gameTime)
        {
            DrawingContext.GraphicsDevice.Clear(Color.Cornsilk);

            SpriteBatch sb = DrawingContext.SpriteBatch;
            sb.Begin();

            _hud.Draw(gameTime);

            sb.End();
        }

        public void Destroy()
        {
            
        }
    }
}
