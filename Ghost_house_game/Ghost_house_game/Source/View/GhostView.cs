using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ghost
{
    public class GhostView
    {
        private readonly Texture2D spriteSheet;
        private Rectangle idleSprite = new Rectangle(7, 7, 18, 19);

        public GhostView(Texture2D sprite)
        {
            spriteSheet = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle bounds)
        {
            spriteBatch.Draw(spriteSheet, bounds, idleSprite, Color.White);
        }
    }
}
