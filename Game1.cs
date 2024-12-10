using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame___Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum Screen
        {
            Intro,
            mid,
            Outro, 
        }
        Rectangle window;

        Screen screen;

        Texture2D introBackround;
        Texture2D midBackround;
        Texture2D outroBackround;


        MouseState prevMousestate;
        MouseState mouseState;





        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 500);

            screen = Screen.Intro;

            screen = Screen.mid;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introBackround = Content.Load<Texture2D>("intro Backround");
            midBackround = Content.Load<Texture2D>("mid Backround");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Backrounds
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.mid;



            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();


            _spriteBatch.Draw(introBackround, window, Color.White);

            _spriteBatch.Draw(midBackround, window, Color.White);













            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
