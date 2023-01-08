using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Project1
{
    internal class level
    {

        public int[,] gameboard1 = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,1,1,1,0,0,0,0,2,0,1},
            {1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };

        public static Block blok = new Block();

        new Vector2 place = new Vector2(0,0);
        public void CreateBlockslevel1(Texture2D blokTexture, SpriteBatch spriteBatch, Texture2D Enemy_orb)
        {
            for (int l = 0; l < gameboard1.GetLength(0); l++)
            {
                for (int c = 0; c < gameboard1.GetLength(1); c++)
                {
                    if (gameboard1[l, c] == 1)
                    {
                        place.X = c * 50;
                        place.Y = l * 50;
                        spriteBatch.Draw(blokTexture, new Vector2 (place.X,  place.Y), new Rectangle(20,29, 50,50) , Color.White);
                        blok.AddBlock(place);
                    }
                    if(gameboard1[l, c] == 2)
                    {
                        place.X = c * 50;
                        place.Y = l * 50;
                        spriteBatch.Draw(Enemy_orb, new Vector2(place.X, place.Y), new Rectangle(0, 0, 31, 31), Color.White);
                        blok.AddEnemy(place);
                    }

                }
            }
        }

    }
}
