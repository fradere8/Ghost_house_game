using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Level;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Attack;
using Ghost;

namespace Player
{
    public class PlayerController
    {
        private PlayerModel player;
        
        public PlayerController(PlayerModel player)
        {
            this.player = player;
        }

        public void Update(LevelModel level, GhostModel ghost, float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            var direction = 0f;

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                direction -= 1f;
                player.IsFacingRight = false;
            }

            else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                direction += 1f;
                player.IsFacingRight = true;
            }

            Move(direction);

            if ((keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)) && player.IsOnGround)
            {
                Jump();
            }

            if (keyboardState.IsKeyDown(Keys.E) || mouseState.LeftButton == ButtonState.Pressed)
            {
                AttackController.TryAttack(player, ghost, player.IsFacingRight, deltaTime);
            }
            else
            {
                if (player.AttackTimer > 0)
                {
                    player.AttackTimer -= deltaTime;
                }
            }

            Character.CharacterMoveController.ApplyMovingWithCollisionsPhysics(player, level, deltaTime);
            // interactions with objects
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