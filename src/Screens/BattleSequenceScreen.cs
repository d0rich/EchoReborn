
using EchoReborn.UI;
using EchoReborn.Battle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using EchoReborn.Data;
using Models = EchoReborn.Data.Models.Generated;
using System.Linq;

namespace EchoReborn.Screens
{
    public class BattleSequenceScreen : IScreen
    {
        private Character _player;
        private BattleUI _hud;
        private BattleSystem _battleSystem;
        private Models.Location _location;
        private Texture2D _backgroundTexture;
        private Texture2D _fragmentTexture;
        
        private Queue<Enemy> _enemyQueue = new Queue<Enemy>();


        public BattleSequenceScreen(int locationId)
        {
            _player = new Character(DataManager.LoadBaseCharacter());
            _hud = new BattleUI( _player );
            _location = DataManager.LoadLocationById(locationId);
            
            _backgroundTexture = DrawingContext.ContentManager.Load<Texture2D>($"Locations/Location{locationId}/bg");
            _fragmentTexture = DrawingContext.ContentManager.Load<Texture2D>($"Locations/Location{locationId}/{_location.Fragment.Image}");
            
            foreach (int enemyRef in _location.Enemies)
            {
                var enemyData = new Enemy(1, DataManager.LoadEnemyById(enemyRef));
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
                _hud.NewBattle(enemy, _battleSystem, _enemyQueue.Count == 0);
            }
        }

        public void Draw(GameTime gameTime)
        {
            DrawingContext.GraphicsDevice.Clear(Color.Cornsilk);

            SpriteBatch sb = DrawingContext.SpriteBatch;
            sb.Begin();

            DrawBackground();
            _hud.Draw(gameTime);

            sb.End();
        }

        public void Destroy()
        {
            
        }
        
        private void DrawBackground()
        {
            var graphicsDevice = DrawingContext.GraphicsDevice;
            var spriteBatch = DrawingContext.SpriteBatch;
            spriteBatch.Draw(
                _backgroundTexture,
                new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height),
                Color.White
            );
        }
    }
}
