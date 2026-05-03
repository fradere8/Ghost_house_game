using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Room
{
    public class RoomView
    {
        private static GraphicsDevice graphicsDevice;
        private static Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
        private static Texture2D whitePixel = texture.SetData(new Color[] { Color.White });
        
        
        public void Draw(SpriteBatch spriteBatch, RoomModel room)
        {
            
            foreach (var wall in room.Walls)
            {
                spriteBatch.Draw()
            }
        }
    }
}