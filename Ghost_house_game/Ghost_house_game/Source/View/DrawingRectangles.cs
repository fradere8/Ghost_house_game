using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ghost_house_game.Source.View
{
    public class DrawingRectangles
    {

        public static void DrawNoFilledRectangle(SpriteBatch spriteBatch, Rectangle rect, Color color, int depth)
        {
            var pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            spriteBatch.Draw(pixel, new Rectangle(rect.Left, rect.Top, rect.Width, depth), color);
            spriteBatch.Draw(pixel, new Rectangle(rect.Left, rect.Bottom - depth, rect.Width, depth), color);
            spriteBatch.Draw(pixel, new Rectangle(rect.Left, rect.Top, depth, rect.Height), color);
            spriteBatch.Draw(pixel, new Rectangle(rect.Right - depth, rect.Top, depth, rect.Height), color);
        }

        public static void DrawFilledRectangle(SpriteBatch spriteBatch, Rectangle rect, Color color)
        {
            var pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            spriteBatch.Draw(pixel, rect, color);
        }
    }
}
