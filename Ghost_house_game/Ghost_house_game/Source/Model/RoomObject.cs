using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ghost_house_game.Source.Model
{
    public class RoomObject
    {
        public Rectangle Bounds { get; set; }
        public string Name { get; }
        public bool IsSolid { get; set; } = false;
        public Color Color { get; } 

        public RoomObject(string name, Rectangle bounds, Color color)
        {
            Name = name;
            Bounds = bounds;
            Color = color;
        }
    }
}
