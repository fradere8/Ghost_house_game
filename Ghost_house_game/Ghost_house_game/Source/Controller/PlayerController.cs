using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Room;

namespace Player
{
    public class PlayerController
    {
        private PlayerModel playerModel;

        public PlayerController(PlayerModel model)
        {
            playerModel = model;
        }

        public void Update(RoomModel roomModel, float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            var direction = 0f;

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                direction -= 1f;
            }

            else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                direction += 1f;
            }

            playerModel.Move(direction);

            if (keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {
                playerModel.Jump();
            }

            playerModel.Update(roomModel, deltaTime);
            
            if (playerModel.IsOnGround)
            {
                playerModel.Land();
            }
        }
    }
}