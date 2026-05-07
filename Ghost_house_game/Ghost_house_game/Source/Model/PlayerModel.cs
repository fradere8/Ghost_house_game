using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Room;

namespace Player
{
    public class PlayerModel
    {
        public Vector2 Position { get; set; }
        public int Width = 96;
        public int Height = 96;
        public Vector2 Velocity { get; private set; } = Vector2.Zero;
        public float Speed = 300f;
        public float Gravity = 1100f;
        public float JumpForce = -600f;

        public bool IsOnGround { get; set; } = false;
        public bool IsJumping { get; set; } = false;
        public bool IsAlive { get; set; } = true;

        public Rectangle Bounds => new Rectangle(
                (int)Position.X, 
                (int)Position.Y, 
                Width, 
                Height);
        
        public PlayerModel(Vector2 startPosition)
        {
            Position = startPosition;
            Velocity = Vector2.Zero;
        }

        public void Update(RoomModel room, float deltaTime)
        {
            IsOnGround = false;

            Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * deltaTime);
           
            MoveHorisontal(room, deltaTime);
            MoveVertical(room, deltaTime);
            Velocity = new Vector2(0, Velocity.Y);
            
        }

        private void MoveHorisontal(RoomModel room, float deltaTime)
        {
            Position += new Vector2(Velocity.X * deltaTime, 0);

            foreach (var barrier in GetAllBarriers(room))
            {
                if (!Bounds.Intersects(barrier)) 
                    continue;

                if (Velocity.X > 0 && IsTouchingLeft(barrier, deltaTime))
                {
                    Position = new Vector2(barrier.Left - Width, Position.Y);
                    Velocity = new Vector2(0, Velocity.Y);
                }

                else if (Velocity.X < 0 && IsTouchingRight(barrier, deltaTime))
                {
                    Position = new Vector2(barrier.Right, Position.Y);
                    Velocity = new Vector2(0, Velocity.Y);
                }
            }
        }

        private void MoveVertical(RoomModel room, float deltaTime)
        {
            Position += new Vector2(0, Velocity.Y * deltaTime);

            foreach (var barrier in GetAllBarriers(room))
            {
                if (!Bounds.Intersects(barrier)) 
                    continue;

                if (Velocity.Y > 0 && IsTouchingTop(barrier, deltaTime))
                {
                    Position = new Vector2(Position.X, barrier.Top - Height);
                    Velocity = new Vector2(Velocity.X, 0);
                    IsOnGround = true;
                    IsJumping = false;
                }

                else if (Velocity.Y < 0 && IsTouchingBottom(barrier, deltaTime))
                {
                    Position = new Vector2(Position.X, barrier.Bottom);
                    Velocity = new Vector2(Velocity.X, 0);
                }
            }
        }

        private List<Rectangle> GetAllBarriers(RoomModel room)
        {
            var barriers = new List<Rectangle>(room.Walls);

            foreach (var obj in room.Objects)
            {
                if (obj.IsSolid)
                {
                    barriers.Add(obj.Bounds);
                }
            }

            return barriers;
        }

        private bool IsTouchingLeft(Rectangle barrier, float deltaTime)
        {
            return Bounds.Right + Velocity.X * deltaTime > barrier.Left &&
                   Bounds.Left < barrier.Left &&
                   Bounds.Bottom > barrier.Top &&
                   Bounds.Top < barrier.Bottom;
        }

        private bool IsTouchingRight(Rectangle barrier, float deltaTime)
        {
            return Bounds.Left + Velocity.X * deltaTime < barrier.Right &&
                   Bounds.Right > barrier.Right &&
                   Bounds.Bottom > barrier.Top &&
                   Bounds.Top < barrier.Bottom;
        }

        private bool IsTouchingTop(Rectangle barrier, float deltaTime)
        {
            return Bounds.Bottom + Velocity.Y * deltaTime > barrier.Top &&
                   Bounds.Top < barrier.Top &&
                   Bounds.Right > barrier.Left &&
                   Bounds.Left < barrier.Right;
        }

        private bool IsTouchingBottom(Rectangle barrier, float deltaTime)
        {
            return Bounds.Top + Velocity.Y * deltaTime < barrier.Bottom &&
                   Bounds.Bottom > barrier.Bottom &&
                   Bounds.Right > barrier.Left &&
                   Bounds.Left < barrier.Right;
        }
            

        public void Jump()
        {
            if (IsOnGround)
            {
                Velocity = new Vector2(Velocity.X, JumpForce);
                IsOnGround = false;
                IsJumping = true;
            }
        }

        public void Move(float direction)
        {
            Velocity = new Vector2(direction * Speed, Velocity.Y);
        }
    }
}