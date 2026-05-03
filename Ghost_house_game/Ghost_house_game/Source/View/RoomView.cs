using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DrawingExtensions;

namespace Room
{
    public class RoomView
    {
        public void Draw(SpriteBatch spriteBatch, RoomModel room)
        {
            foreach (var wall in room.Walls)
            {
                DrawingRectangles.DrawFilledRectangle(spriteBatch, wall, Color.DarkViolet);
            }

            foreach (var obj in room.Objects)
            {
                DrawingRectangles.DrawFilledRectangle(spriteBatch, obj.Bounds, obj.Color);
                DrawingRectangles.DrawNoFilledRectangle(spriteBatch, obj.Bounds, Color.Black, 1);
            }
        }
    }
}