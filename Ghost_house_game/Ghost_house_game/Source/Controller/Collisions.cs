using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Collisions
{
    public static class Collisions
    {
        public static void MoveHorisontal(
            ref Vector2 position,
            ref Vector2 velocity,
            int width,
            int height,
            List<Rectangle> barriers,
            float deltaTime)
        {
            position += new Vector2(velocity.X * deltaTime, 0);
            var bounds = MakeNewBounds(position, width, height);

            foreach (var barrier in barriers)
            {
                if (!bounds.Intersects(barrier)) 
                    continue;

                if (velocity.X > 0 && IsTouchingHorizontally(velocity, bounds, barrier, deltaTime, "left"))
                {
                    position = new Vector2(barrier.Left - width, position.Y);
                    velocity = new Vector2(0, velocity.Y);
                    bounds = MakeNewBounds(position, width, height);
                }

                else if (velocity.X < 0 && IsTouchingHorizontally(velocity, bounds, barrier, deltaTime, "right"))
                {
                    position = new Vector2(barrier.Right, position.Y);
                    velocity = new Vector2(0, velocity.Y);
                    bounds = MakeNewBounds(position, width, height);
                }
            }
        }

        public static void MoveVertical(
            ref Vector2 position,
            ref Vector2 velocity,
            int width,
            int height,
            ref bool isOnGround,
            List<Rectangle> barriers,
            float deltaTime)
        {
            position += new Vector2(0, velocity.Y * deltaTime);
            var bounds = MakeNewBounds(position, width, height);

            foreach (var barrier in barriers)
            {
                if (!bounds.Intersects(barrier))
                    continue;

                if (velocity.Y > 0 && IsTouchingVertically(velocity, bounds, barrier, deltaTime, "top"))
                {
                    position = new Vector2(position.X, barrier.Top - height);
                    velocity = new Vector2(velocity.X, 0);
                    isOnGround = true;
                    bounds = MakeNewBounds(position, width, height);
                }

                else if (velocity.Y < 0 && IsTouchingVertically(velocity, bounds, barrier, deltaTime, "bottom"))
                {
                    position = new Vector2(position.X, barrier.Bottom);
                    velocity = new Vector2(velocity.X, 0);
                    bounds = MakeNewBounds(position, width, height);
                }
            }
        }

        private static Rectangle MakeNewBounds(Vector2 position, int width, int height)
        {
            return new Rectangle(
                (int)position.X,
                (int)position.Y,
                width,
                height
            );
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