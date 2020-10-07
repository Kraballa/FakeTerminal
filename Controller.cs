using FakeTerminal.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FakeTerminal
{
    /// <summary>
    /// Main class that handles updating everything else.
    /// </summary>
    public class Controller : Game
    {
        GraphicsDeviceManager graphics;
        public static Controller Instance;

        public static int Width = 960;
        public static int Height = 720;

        public TextController TextController;
        public IDisplay Display;

        public Controller()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            Content.RootDirectory = ".";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            FakeTerminal.Draw.Initialize(graphics.GraphicsDevice);
            MouseInput.Initialize();
            KeyboardInput.Initialize();
            base.Initialize();
            TextController = new TextController();
            Display = new LinearDisplay();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MouseInput.Update();
            KeyboardInput.Update();
            TextController.Update();
            Display.Update();
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            FakeTerminal.Draw.Begin();
            Display.Render();
            FakeTerminal.Draw.End();
            base.Draw(gameTime);
        }

        public void SendText(string text)
        {
            Display.SendText(text);
        }
    }
}