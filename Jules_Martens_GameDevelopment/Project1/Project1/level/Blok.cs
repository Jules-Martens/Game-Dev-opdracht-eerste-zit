using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Block
    {
        public Vector2 currentblock { get; set; }

        public List<Vector2> blocks;
        public List<Vector2> lvlEnemy;

        public Block()
        {
            blocks = new List<Vector2>();
            lvlEnemy = new List<Vector2>();
        }

        public void AddBlock(Vector2 Addblock)
        {
            blocks.Add(Addblock);
        }

        public void AddEnemy(Vector2 Addblock)
        {
            lvlEnemy.Add(Addblock);
        }
    }
}
