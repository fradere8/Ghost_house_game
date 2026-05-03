using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Room
{
    public class RoomObject
    {
        public Rectangle Bounds { get; set; }
        public string Name { get; }
        public bool IsSolid { get; set; } = true;
        public Color Color { get; } 

        public RoomObject(string name, Rectangle bounds, Color color, bool isSolid = true)
        {
            Name = name;
            Bounds = bounds;
            Color = color;
            IsSolid = isSolid;
        }
    }
}
