using System;
using System.ComponentModel.Design;
using System.Threading;
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
        Vector2 player1position = new Vector2(0, 880);
        Vector2 player1volacity = new Vector2(0, 0);


        Texture2D backrund1;
        Vector2 backrund1position = new Vector2(0, 0);

        //player or game states in bool

        bool PlayerIdle = true;

        bool InAir = false;


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
            player1 = Content.Load<Texture2D>("rat-trick-idle-gif-sheet_kopiera");
            // TODO: use this.Content to load your game content here
        }

      





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

            //player source updates for idle

            if (player1volacity.X > 0 || player1volacity.X < 0)
            {
                PlayerIdle = false;
            }
            else
            {
                PlayerIdle = true;
            }



            base.Update(gameTime);
        }

        //source rectangles

        int SourceXplayer = 200;

        Rectangle BackgroundSource = new Rectangle(0, 0, 3840, 2160);

        Rectangle PlayerSource = new Rectangle(200, 100, 670, 690);

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backrund1, backrund1position, BackgroundSource, Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0);

            if (PlayerIdle == true)
            {
                _spriteBatch.Draw(player1, player1position, new Rectangle(SourceXplayer, 100, 670, 690), Color.White, 0f, new Vector2(0, 0), 0.3f, SpriteEffects.None, 0);
                Thread.Sleep(100);
                if (SourceXplayer < 3000)
                {
                    SourceXplayer += 1000;
                }
                else if (SourceXplayer >= 3000)
                {
                    SourceXplayer = 200;
                }
                
            }
            else if (PlayerIdle == false)
            {
                _spriteBatch.Draw(player1, player1position, PlayerSource, Color.White, 0, new Vector2(0, 0), 0.3f, SpriteEffects.None, 0);
            }
            

            _spriteBatch.End();
 
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
