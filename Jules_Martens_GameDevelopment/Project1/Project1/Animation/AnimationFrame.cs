﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class AnimationFrame
    {
        public Rectangle sourceRectangle{ get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            sourceRectangle = rectangle;
        }
    }
}
