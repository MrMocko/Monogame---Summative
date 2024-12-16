using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame___Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        float seconds;

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


        Texture2D startButtonTexture;
        Rectangle startButtonRect;

        Texture2D exitButtonTexture;
        Rectangle exitButtonRect;


        MouseState prevMousestate;
        MouseState mouseState;

        Texture2D waterGunTexture;
        Rectangle waterGunRect;

        Texture2D shotTargetTexture;
        Rectangle shotTargetRect;
        Vector2 shotTargetSpeed;

        Texture2D waterTexture;
        Rectangle waterRect;






        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            startButtonRect = new Rectangle(590, 510, 200, 80);
            exitButtonRect = new Rectangle(590, 510, 200, 80);
            waterGunRect = new Rectangle(530, 320, 300, 300);
            shotTargetRect = new Rectangle(530, 290, 100, 100);
            shotTargetSpeed = new Vector2(-2, 0);
            waterRect = new Rectangle(530, 180, 200, 300); 



            screen = Screen.Intro;


            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introBackround = Content.Load<Texture2D>("intro Backround");
            midBackround = Content.Load<Texture2D>("mid Backround");
            outroBackround = Content.Load<Texture2D>("outro Backround");
            startButtonTexture = Content.Load<Texture2D>("start Button");
            exitButtonTexture = Content.Load<Texture2D>("exit Button");
            waterGunTexture = Content.Load<Texture2D>("waterGun");
            shotTargetTexture = Content.Load<Texture2D>("shot Target");
            waterTexture = Content.Load<Texture2D>("water");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prevMousestate = mouseState;
            mouseState = Mouse.GetState();
            seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;


            // Backrounds
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMousestate.LeftButton == ButtonState.Released)
                {

                    if (startButtonRect.Contains(mouseState.Position))
                        screen = Screen.mid;

                }



            }

            else if (screen == Screen.mid) 
            {
                shotTargetRect.X += (int)shotTargetSpeed.X;
                shotTargetRect.Y += (int)shotTargetSpeed.Y;
                if (shotTargetRect.Right > 800 || shotTargetRect.Left < 290)
                    shotTargetSpeed.X *= -1;




                if (shotTargetRect  window.Width && window.Height)
                {
                    if (seconds >= 10)
                    {
                        shotTargetRect(900, 1000);
                        seconds = 0f;
                    }
                    screen = Screen.Outro;
                    

                }
                
            }

            if (screen == Screen.Outro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMousestate.LeftButton == ButtonState.Released)
                {
                    if (exitButtonRect.Contains(mouseState.Position))
                        Exit();


                }
            }

            else if (screen == Screen.Outro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMousestate.LeftButton == ButtonState.Released)
                {
                    if (exitButtonRect.Contains(mouseState.Position))
                        Exit();

                }
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introBackround, new Vector2(0, 0), Color.White);

                _spriteBatch.Draw(startButtonTexture, startButtonRect, Color.White);
            }

            else if (screen == Screen.mid)
            {
                _spriteBatch.Draw(midBackround, window, Color.White);

                _spriteBatch.Draw(shotTargetTexture, shotTargetRect, Color.White);

                _spriteBatch.Draw(waterGunTexture, waterGunRect, Color.White);

                _spriteBatch.Draw(waterTexture,waterRect, null, Color.White, 1.2f, Vector2.Zero, SpriteEffects.None, 0f);

            }

            else if (screen == Screen.Outro)
            {
                _spriteBatch.Draw(outroBackround, window, Color.White);

                _spriteBatch.Draw(exitButtonTexture, exitButtonRect, Color.White);
            }


            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
