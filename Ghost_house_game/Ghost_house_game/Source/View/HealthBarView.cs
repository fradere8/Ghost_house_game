using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Health
{
    public static class HealthBarView
    {
        private const int BarWidth = 70;
        private const int BarHeight = 6;
        private const int BarOffsetY = 10;

        public static void Draw(
            SpriteBatch spriteBatch,
            Texture2D pixel,
            Vector2 charPosition,
            int charWidth,
            float currentHealth,
            float maxHealth)
        {
            var healthPercent = currentHealth / maxHealth;
            var barX = charPosition.X + (charWidth - BarWidth) / 2;
            var barY = charPosition.Y - BarOffsetY - BarHeight;

            var backGround = new Rectangle((int)barX, (int)barY, BarWidth, BarHeight);
            spriteBatch.Draw(pixel, backGround, Color.Gray);

            var colorHp = healthPercent > 0.5f ? Color.Green : 
            (healthPercent > 0.25f ? Color.Yellow : Color.Red);

            var hpRect = new Rectangle((int)barX, (int)barY, (int)(BarWidth * healthPercent), BarHeight);
            spriteBatch.Draw(pixel, hpRect, colorHp);

            DrawBorder(spriteBatch, pixel, backGround, Color.Black);
        }

        private static void DrawBorder(SpriteBatch spriteBatch, Texture2D pixel, Rectangle rect, Color color)
        {
            spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y, rect.Width, 1), color);
            spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Bottom - 1, rect.Width, 1), color);
            spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y, 1, rect.Height), color);
            spriteBatch.Draw(pixel, new Rectangle(rect.Right - 1, rect.Y, 1, rect.Height), color);
        }
    }
}