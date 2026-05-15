using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DrawingExtensions;

namespace Level
{
    public class LevelView
    {
        public void Draw(SpriteBatch spriteBatch, List<Rectangle> walls, List<LevelObject> objects)
        {
            foreach (var wall in walls)
            {
                DrawingRectangles.DrawFilledRectangle(spriteBatch, wall, Color.DarkViolet);
            }

            foreach (var obj in objects)
            {
                DrawingRectangles.DrawFilledRectangle(spriteBatch, obj.Bounds, GetColor(obj.Type));
                DrawingRectangles.DrawNoFilledRectangle(spriteBatch, obj.Bounds, Color.Black, 1);
            }
        }

        private static Color GetColor(ObjectType type)
        {
            switch (type)
            {
                case ObjectType.Block:
                    return Color.DarkViolet;
                case ObjectType.Platform:
                    return Color.DarkGray;
                case ObjectType.Door:
                    return Color.DarkCyan;
                case ObjectType.Chest:
                    return Color.Gold;
                default:
                    return Color.White;
            }
        }
    }
}