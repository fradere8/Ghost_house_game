using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Collisions
{
    public static class Collisions
    {
        
        /* public void Update(RoomModel room, float deltaTime)
        {
            IsOnGround = false;

            Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * deltaTime);
           
            MoveHorisontal(room, deltaTime);
            MoveVertical(room, deltaTime);
            Velocity = new Vector2(0, Velocity.Y);
            
        } */

         public static void MoveHorisontal(Vector2 position, Vector2 velocity, Rectangle bounds, List<Rectangle> barriers, float deltaTime)
        {
            position += new Vector2(velocity.X * deltaTime, 0);

            foreach (var barrier in barriers)
            {
                if (!bounds.Intersects(barrier)) 
                    continue;

                if (velocity.X > 0 && IsTouchingHorizontally(velocity, bounds, barrier, deltaTime, "left"))
                {
                    position = new Vector2(barrier.Left - bounds.Width, position.Y);
                    velocity = new Vector2(0, velocity.Y);
                }

                else if (velocity.X < 0 && IsTouchingHorizontally(velocity, bounds, barrier, deltaTime, "right"))
                {
                    position = new Vector2(barrier.Right, position.Y);
                    velocity = new Vector2(0, velocity.Y);
                }
            }
        }

        public static void MoveVertical(Vector2 position, Vector2 velocity, Rectangle bounds, bool isOnGround, List<Rectangle> barriers, float deltaTime)
        {
            position += new Vector2(0, velocity.Y * deltaTime);

            foreach (var barrier in barriers)
            {
                if (!bounds.Intersects(barrier)) 
                    continue;

                if (velocity.Y > 0 && IsTouchingVertically(velocity, bounds, barrier, deltaTime, "top"))
                {
                    position = new Vector2(position.X, barrier.Top - bounds.Height);
                    velocity = new Vector2(velocity.X, 0);
                    isOnGround = true;
                }

                else if (velocity.Y < 0 && IsTouchingVertically(velocity, bounds, barrier, deltaTime, "bottom"))
                {
                    position = new Vector2(position.X, barrier.Bottom);
                    velocity = new Vector2(velocity.X, 0);
                }
            }
        }

        private static bool IsTouchingHorizontally(Vector2 velocity, Rectangle bounds, Rectangle barrier, float deltaTime, string direction)
        {
            switch (direction)
            {
                case "left":
                    return bounds.Right + velocity.X * deltaTime > barrier.Left &&
                           bounds.Left < barrier.Left &&
                           bounds.Bottom > barrier.Top &&
                           bounds.Top < barrier.Bottom;
                case "right":
                    return bounds.Left + velocity.X * deltaTime < barrier.Right &&
                           bounds.Right > barrier.Right &&
                           bounds.Bottom > barrier.Top &&
                           bounds.Top < barrier.Bottom;
                default:
                    throw new ArgumentException("Направление должно быть left/right.");
            }
        }

        private static bool IsTouchingVertically(Vector2 velocity, Rectangle bounds, Rectangle barrier, float deltaTime, string direction)
        {
            switch (direction)
            {
                case "top":
                    return bounds.Bottom + velocity.Y * deltaTime > barrier.Top &&
                           bounds.Top < barrier.Top &&
                           bounds.Right > barrier.Left &&
                           bounds.Left < barrier.Right;
                case "bottom":
                    return bounds.Top + velocity.Y * deltaTime < barrier.Bottom &&
                           bounds.Bottom > barrier.Bottom &&
                           bounds.Right > barrier.Left &&
                           bounds.Left < barrier.Right;
                default:
                    throw new ArgumentException("Направление должно быть top/bottom.");
            }
        }
    }
}