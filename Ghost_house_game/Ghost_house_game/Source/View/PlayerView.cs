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
        private Texture2D playerSprite;

        public PlayerView(Texture2D sprite)
        {
            playerSprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, PlayerModel model)
        {
            spriteBatch.Draw(playerSprite, model.Bounds, Color.White);
        }
    }
}