using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Project1
{
    internal class SkeletonHero : IGameObject
    {
        Texture2D skeletonTexture;
        Animation animation;

        public SkeletonHero(Texture2D texture)
        {
            skeletonTexture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(47, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(95, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(146, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(191, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(240, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(288, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(336, 0, 48, 76)));
            animation.AddFrame(new AnimationFrame(new Rectangle(384, 0, 48, 76)));
        }

        public void Update(GameTime gameTime)
        {
            positie.X += speed_X;

            positie.Y -= speed_Y;
            collisionCheckEnemy(level.blok.lvlEnemy);
            Jump();
            Move();
            animation.Update(gameTime);
        }



        public static Vector2  positie = new Vector2(0 + 80, Game1.screenHeight - 200);


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skeletonTexture, positie, animation.CurrentFrame.sourceRectangle, Color.White);

        }

        private float speed_X;

        public float Speed_X
        {
            get { return speed_X; }
            set {if(value < 1) 
                speed_X = value; }
        }

        public float movementSpeed = 0.2F;
        public void Move()
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.D))
            {
                speed_X += movementSpeed;
                collisionCheckXR(level.blok.blocks);
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                speed_X -= movementSpeed;
                collisionCheckXL(level.blok.blocks);
            }
            if (keyboardState.IsKeyUp(Keys.D) && keyboardState.IsKeyUp(Keys.A))
                speed_X = 0;
            if (keyboardState.IsKeyDown(Keys.D) && keyboardState.IsKeyDown(Keys.A))
                speed_X = 0;
        }

        private float speed_Y;

        public float Speed_Y
        {
            get { return speed_Y; }
            set
            {
                if (value < 1)
                    speed_Y = value;
            }
        }

        public float jumpSpeed = 10F;

        public bool isFalling = false;


        public void Jump()
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space) && isFalling == false)
            {
                speed_Y += jumpSpeed;
                isFalling = true;
                collisionCheckYUP(level.blok.blocks);
            }
            if (keyboardState.IsKeyUp(Keys.Space))
            {
                speed_Y = 0;
            }
            if (!((positie.Y + 80) > Game1.screenHeight))
            {
                collisionCheckYDOWN(level.blok.blocks);
                positie.Y += 1;
            }



        }

        public void collisionCheckXR(List<Vector2> lijst)
        {
            for (int i = 0; i < lijst.Count; i++)
            {
                if (new Rectangle((int)positie.X, (int)positie.Y, 48, 68).Intersects(new Rectangle((int)lijst[i].X, (int)lijst[i].Y, 50, 50)))
                {
                    speed_X = -1;
                }
            }

        }

        public void collisionCheckXL(List<Vector2> lijst)
        {
            for (int i = 0; i < lijst.Count; i++)
            {
                if (new Rectangle((int)positie.X, (int)positie.Y, 48, 68).Intersects(new Rectangle((int)lijst[i].X, (int)lijst[i].Y, 50, 50)))
                {
                    speed_X = 1;
                }
            }

        }

        public void collisionCheckYUP(List<Vector2> lijst)
        {
            for (int i = 0; i < lijst.Count; i++)
            {
                if (new Rectangle((int)positie.X, (int)positie.Y, 40, 76).Intersects(new Rectangle((int)lijst[i].X, (int)lijst[i].Y, 50, 50)))
                {
                    speed_Y = -5;
                    isFalling = false;
                }
            }

        }

        public void collisionCheckYDOWN(List<Vector2> lijst)
        {
            for (int i = 0; i < lijst.Count; i++)
            {
                if (new Rectangle((int)positie.X, (int)positie.Y, 48, 76).Intersects(new Rectangle((int)lijst[i].X, (int)lijst[i].Y, 50, 50)))
                {
                    speed_Y = 2;
                }
            }

        }

        public void collisionCheckEnemy(List<Vector2> lijst)
        {
            for (int i = 0; i < lijst.Count; i++)
            {
                if (new Rectangle((int)positie.X, (int)positie.Y, 48, 76).Intersects(new Rectangle((int)lijst[i].X, (int)lijst[i].Y, 50, 50)))
                {
                    positie.X = 50;
                    positie.Y = 50;
                }
            }

        }

    }
}
