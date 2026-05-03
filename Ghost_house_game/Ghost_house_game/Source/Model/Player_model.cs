using System;
using System.Drawing;
using System.Numerics;

namespace Player
{
    public class PlayerModel
    {
        public Vector2 Position { get; set; }
        public int Width = 16;
        public int Height = 16;
        public Vector2 Velocity { get; set; }
        public float Speed = 200f;
        public float Gravity = 900f;
        public float JumpForce = -500f;

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

        public void Update(float deltaTime)
        {
            if (!IsOnGround)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * deltaTime);
            }

            Position += Velocity * deltaTime;
            
            var groundY = 720 - Height;
            if (Position.Y >= groundY)
            {
                Position = new Vector2(Position.X, groundY);
                Velocity = new Vector2(Velocity.X, 0);
                IsOnGround = true;
            }
        }

        public void Jump()
        {
            if (IsOnGround)
            {
                Velocity = new Vector2(Velocity.X, JumpForce);
                IsOnGround = false;
            }
        }

        public void Move(float direction)
        {
            Velocity = new Vector2(direction * Speed, Velocity.Y);
        }
    }
}