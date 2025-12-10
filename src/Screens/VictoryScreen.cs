
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
    public class VictoryScreen : IScreen
    {
        
        private Texture2D _backgroundTexture;
        private Texture2D _fragmentTexture;

        private Models.Location _location;
        private Button _returnButton;
        private Models.GameState _gameState;
        private bool IsFirstClear { get; set; }


        public VictoryScreen(int locationId, Character character)
        {
            _gameState = DataManager.LoadGameState();
            _location = DataManager.LoadLocationById(locationId);
            IsFirstClear = _gameState.World.LatestClearedLocationId < _location.Id;
            _backgroundTexture = DrawingContext.ContentManager.Load<Texture2D>($"Locations/Location{locationId}/bg");
            _fragmentTexture = DrawingContext.ContentManager.Load<Texture2D>($"Locations/Location{locationId}/{_location.Fragment.Image}");
            _returnButton = new Button(
                bounds: new Rectangle(440, 600, 400, 60),
                text: "Return to Map",
                font: GameFonts.ButtonFont,
                onClickCallback: () => ScreenManager.SwitchScreen(new MapScreen())
            );
            UpdateSaveData(character);
        }

        public void Update(GameTime gameTime)
        {
            _returnButton.Update();
        }

        public void Draw(GameTime gameTime)
        {
            DrawingContext.GraphicsDevice.Clear(Color.Cornsilk);

            SpriteBatch sb = DrawingContext.SpriteBatch;
            sb.Begin();

            DrawingContext.DrawBackground(_backgroundTexture);
            DrawLabel();
            _returnButton.Draw();
            
            if (IsFirstClear)
            {
                DrawFragment();
            }

            sb.End();
        }

        public void Destroy()
        {
            
        }

        private void UpdateSaveData(Character character)
        {
            _gameState.Player.Level = character.Level;
            _gameState.Player.Experience = character.Exp;
            _gameState.Player.MaxHealth = character.MaxHP;
            _gameState.Player.CurrentHealth = character.HP;
            _gameState.Player.MaxMana = character.MaxEnergy;
            _gameState.Player.CurrentMana = character.Energy;
            if (_gameState.World.LatestClearedLocationId < _location.Id)
            {
                _gameState.World.LatestClearedLocationId = _location.Id;
                _gameState.Player.Skills.Add(_location.RewardSkillId);
            }
            DataManager.SaveGameState(_gameState);
        }
        
        private void DrawLabel()
        {
            var font = GameFonts.TitleFont;
            SpriteBatch spriteBatch = DrawingContext.SpriteBatch;
            Vector2 size = font.MeasureString("Victory");
            Vector2 position = new Vector2(
                (1280 - size.X) / 2,
                (720 - size.Y) / 2);

            spriteBatch.DrawString(
                font,
                "Victory",
                position,
                Color.Red);
        }
        
        private void DrawFragment()
        {
            SpriteBatch spriteBatch = DrawingContext.SpriteBatch;
            Rectangle position = new Rectangle(900, 300, 400, 300);

            spriteBatch.Draw(
                _fragmentTexture,
                position,
                Color.White);
            
            Vector2 textSize = GameFonts.ButtonFont.MeasureString(_location.Fragment.Name);
            Vector2 textPosition = new Vector2(
                1150 - textSize.X / 2,
                720 - 150);
            spriteBatch.DrawString(
                GameFonts.ButtonFont,
                _location.Fragment.Name,
                textPosition,
                Color.White
            );
        }
    }
}
