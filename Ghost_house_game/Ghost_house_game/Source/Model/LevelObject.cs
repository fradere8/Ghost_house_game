using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Level
{
    public enum ObjectType
    {
        Block,
        Platform,
        Door,
        Chest
    }

    public class LevelObject
    {
        public Rectangle Bounds { get; set; }
        public bool IsSolid { get; set; }
        public ObjectType Type { get; } 

        public LevelObject(int x, int y, int width, int height, ObjectType type, bool isSolid = true)
        {
            Bounds = new Rectangle(x, y, width, height);
            Type = type;
            IsSolid = isSolid;
        }
    }
}
