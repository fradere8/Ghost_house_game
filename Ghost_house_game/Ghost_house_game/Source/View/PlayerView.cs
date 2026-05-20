using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Player
{
    public class PlayerView
    {
        private Texture2D spriteSheet;
        private Rectangle idleSprite = new Rectangle(5, 8, 18, 19);

        public PlayerView(Texture2D sprite)
        {
            spriteSheet = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle bounds, bool isFacingRight)
        {
            var effect = isFacingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(spriteSheet, bounds, idleSprite, Color.White, 0f, Vector2.Zero, effect, 0f);
        }
    }
}