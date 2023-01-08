using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private Texture2D _texturehero;
        SkeletonHero skeletonHero;

        private Texture2D _block;
        level level1;

        private Texture2D _orb;

        public static int screenHeight = 440;
        public static int screenWidth = 790;


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.ApplyChanges();
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
            base.Initialize();
            InitializeGameObjects();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _texturehero = Content.Load<Texture2D>("skeleton");
            _block = Content.Load<Texture2D>("wall");
            _orb = Content.Load<Texture2D>("rotating_orbs");
        }

        private void InitializeGameObjects()
        {
            skeletonHero = new SkeletonHero(_texturehero);
            level1 = new level();
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            skeletonHero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // Teken hier alles uit de spritebatch
            skeletonHero.Draw(_spriteBatch);
            level1.CreateBlockslevel1(_block, _spriteBatch, _orb);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}