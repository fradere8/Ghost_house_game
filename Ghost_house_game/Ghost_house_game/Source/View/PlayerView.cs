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
        private Rectangle idleSprite = new Rectangle(0, 0, 16, 16);

        public PlayerView(Texture2D sprite)
        {
            spriteSheet = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, PlayerModel model)
        {
            spriteBatch.Draw(spriteSheet, model.Bounds, idleSprite, Color.White);
        }
    }
}