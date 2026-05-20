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

        public void Draw(SpriteBatch spriteBatch, Rectangle bounds, bool isFacingRight)
        {
            var effect = isFacingRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(spriteSheet, bounds, idleSprite, Color.White, 0f, Vector2.Zero, effect, 0f);
        }
    }
}
