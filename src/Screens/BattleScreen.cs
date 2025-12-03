
using EchoReborn.UI;
using EchoReborn.Battle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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
            var demoSkills = new List<BattleAction>
            {
                new BattleAction(
                    name: "Basic Attack",
                    description: "Une attaque simple.",
                    target: BattleAction.TargetType.Enemy,
                    energyCost: 0,
                    healthCost: 0,
                    damage: 10,
                    healAmount: 0
                ),
                new BattleAction(
                    name: "Small Heal",
                    description: "Soigne un allié.",
                    target: BattleAction.TargetType.Ally,
                    energyCost: 5,
                    healthCost: 0,
                    damage: 0,
                    healAmount: 15
                ),
                new BattleAction(
                    name: "Attaque puissante",
                    description: "Une attaque puissante qui coûte de la santé.",
                    target: BattleAction.TargetType.Enemy,
                    energyCost: 5,
                    healthCost: 10,
                    damage: 35,
                    healAmount: 0
                )
            };
            _player = new Character(1, 0, demoSkills);
            _enemy = new Enemy(1, demoSkills);
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
