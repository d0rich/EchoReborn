
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
        private Models.Location _location;
        private Button _returnButton;


        public VictoryScreen(int locationId, Character character)
        {
            _location = DataManager.LoadLocationById(locationId);
            _backgroundTexture = DrawingContext.ContentManager.Load<Texture2D>($"Locations/Location{locationId}/bg");
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

            sb.End();
        }

        public void Destroy()
        {
            
        }

        private void UpdateSaveData(Character character)
        {
            var state = DataManager.LoadGameState();
            state.Player.Level = character.Level;
            state.Player.Experience = character.Exp;
            state.Player.MaxHealth = character.MaxHP;
            state.Player.CurrentHealth = character.HP;
            state.Player.MaxMana = character.MaxEnergy;
            state.Player.CurrentMana = character.Energy;
            if (state.World.LatestClearedLocationId < _location.Id)
            {
                state.World.LatestClearedLocationId = _location.Id;
            }
            DataManager.SaveGameState(state);
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
    }
}
