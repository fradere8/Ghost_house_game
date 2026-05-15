using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Level;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Player
{
    public class PlayerController
    {
        private PlayerModel player;

        public void Update(LevelModel level, float deltaTime)
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

            Move(direction);

            if ((keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)) && player.IsOnGround)
            {
                Jump();
            }

            Character.CharacterMoveController.ApplyMovingWithCollisionsPhysics(player, level, deltaTime);
            // interactions with objects, attack
        }

        public void Move(float direction)
        {
            player.Velocity = new Vector2(direction * player.Speed, player.Velocity.Y);
        }

        public void Jump()
        {
            player.Velocity = new Vector2(player.Velocity.X, player.JumpForce);
            player.IsOnGround = false;
        }
    }
}