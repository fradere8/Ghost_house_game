using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ghost
{
    public class GhostView
    {
        private readonly Texture2D _spriteSheet;
        private readonly Rectangle _idleSprite;

        public GhostView(Texture2D sprite)
        {
            _spriteSheet = sprite;
            _idleSprite = new Rectangle(0, 0, sprite.Width, sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle bounds)
        {
            spriteBatch.Draw(_spriteSheet, bounds, _idleSprite, Color.White);
        }
    }
}
