
using EchoReborn.UI;
using EchoReborn.Battle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using EchoReborn.Data;
using EchoReborn.UI.Components;
using Models = EchoReborn.Data.Models.Generated;
using System.Linq;

namespace EchoReborn.Screens
{
    public class MapScreen : IScreen
    {
        
        private Texture2D _backgroundTexture;
        private Models.GameState _gameState;
        private List<Models.Location> _locations;
        private List<Button> _locationButtons;


        public MapScreen()
        {
            _gameState = DataManager.LoadGameState();
            _locations = DataManager.LoadAllLocations();
            _locationButtons = _locations
                .Where(l => l.Id <= _gameState.World.LatestClearedLocationId + 1)
                .Select((l, i) => new Button(
                    new Rectangle(440, 200 + i * 80, 400, 60),
                    l.Name,
                    GameFonts.ButtonFont,
                    () => ScreenManager.SwitchScreen(new BattleSequenceScreen(l.Id))
                ))
                .ToList();
            _backgroundTexture = DrawingContext.ContentManager.Load<Texture2D>("Locations/BackgroundMenu");
        }

        public void Update(GameTime gameTime)
        {
            foreach (var locationButton in _locationButtons)
            {
                locationButton.Update();
            }
        }

        public void Draw(GameTime gameTime)
        {
            DrawingContext.GraphicsDevice.Clear(Color.Cornsilk);

            SpriteBatch sb = DrawingContext.SpriteBatch;
            sb.Begin();

            DrawingContext.DrawBackground(_backgroundTexture);
            foreach (var locationButton in _locationButtons)
            {
                locationButton.Draw();
            }

            sb.End();
        }

        public void Destroy()
        {
            
        }
    }
}
