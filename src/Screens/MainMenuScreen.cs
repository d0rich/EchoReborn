using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EchoReborn.UI.Components;
using EchoReborn.UI;
    
using EchoReborn.Screens;     

namespace EchoReborn.Screens
{
    public class MainMenuScreen : IScreen
    {
        private Texture2D _backgroundTexture;
        private Button _startGameButton;
        private Button _testsButton;
        private Button _exitButton;

        public MainMenuScreen()
        {
            _backgroundTexture = DrawingContext.ContentManager.Load<Texture2D>("Locations/BackgroundMenu");
            // bouton Start Game
            _startGameButton = new Button(
                bounds: new Rectangle(540, 200, 200, 60),
                text: "Start Game",
                font: GameFonts.ButtonFont,
                onClickCallback: () => ScreenManager.SwitchScreen(new BattleSequenceScreen(1))
            );

            _testsButton = new Button(
                bounds: new Rectangle(540, 300, 200, 60),
                text: "Tests",
                font: GameFonts.ButtonFont,
                onClickCallback: () => ScreenManager.SwitchScreen(new TestSelectionScreen())
            );

            _exitButton = new Button(
                bounds: new Rectangle(540, 400, 200, 60),
                text: "Exit",
                font: GameFonts.ButtonFont,
                onClickCallback: ScreenManager.QuitGame
            );
        }

        public void Update(GameTime gameTime)
        {
            _startGameButton.Update();
            _testsButton.Update();
            _exitButton.Update();
        }

        public void Draw(GameTime gameTime)
        {
            var spriteBatch = DrawingContext.SpriteBatch;
            
            DrawingContext.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            DrawBackground();
            DrawTitle();
            _startGameButton.Draw();
            _testsButton.Draw();
            _exitButton.Draw();

            spriteBatch.End();
        }
        
        public void Destroy()
        {
            // rien à détruire
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

        private void DrawTitle()
        {
            var graphicsDevice = DrawingContext.GraphicsDevice;
            var spriteBatch = DrawingContext.SpriteBatch;
            
            string title = "ECHO REBORN";
            Vector2 titleSize = GameFonts.TitleFont.MeasureString(title);
            Vector2 titlePosition = new Vector2(
                (graphicsDevice.Viewport.Width - titleSize.X) / 2,
                80
            );
            spriteBatch.DrawString(GameFonts.TitleFont, title, titlePosition, Color.Cyan);
        }
    }
}
