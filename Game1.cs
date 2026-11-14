using System.ComponentModel.Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace odo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D player1;
        Vector2 player1position = new Vector2(0, 800);
        Vector2 player1volacity = new Vector2(0, 0);


        Texture2D backrund1;
        Vector2 backrund1position = new Vector2(0, 0);


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Window.IsBorderless = true;
            Window.Position = new Point(0, 0);

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        KeyboardState keyboard;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backrund1 = Content.Load<Texture2D>("rat_shit_bg_kopiera");
            player1 = Content.Load<Texture2D>("Pong ITEMS kopiera");
            // TODO: use this.Content to load your game content here
        }

        // player states

        bool idle = true;

        int JumpValue = 0;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.D) & player1volacity.X <= 20)
            {
                player1volacity.X += 0.2f;

            }
            else if (player1volacity.X > 10)
            {
                player1volacity.X -= 0.4f;
            }
            else if (player1volacity.X > 0)
            {
                player1volacity.X -= 0.4f;
            }


            if (keyboard.IsKeyDown(Keys.A) & player1volacity.X >= -20)
            {
                player1volacity.X -= 0.2f;
            }
            else if (player1volacity.X < -10)
            {
                player1volacity.X += 0.4f;
            }
            else if (player1volacity.X < 0)
            {
                player1volacity.X += 0.4f;
            }

            if (keyboard.IsKeyUp(Keys.A) & player1volacity.X > -1 & player1volacity.X < 0 || keyboard.IsKeyUp(Keys.D) & player1volacity.X > 0 & player1volacity.X < 1)
            {
                player1volacity.X = 0f;
            }


            if (keyboard.IsKeyDown(Keys.Space))
            {

            }



            player1position += player1volacity;
            base.Update(gameTime);
        }

        //source rectangles

        Rectangle BackgroundSource = new Rectangle(0, 0, 3840, 2160);

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backrund1, backrund1position, BackgroundSource, Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0);
            _spriteBatch.Draw(player1, player1position, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
