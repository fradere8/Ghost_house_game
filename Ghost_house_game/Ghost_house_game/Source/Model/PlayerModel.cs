using System;
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
        public Vector2 Velocity { get; set; }
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
            if (!IsOnGround)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * deltaTime);
            }

            Position += Velocity * deltaTime;
            
            HandleHoizontalCollisions(room);
            HandleVerticalCollisions(room);
        }

        private void HandleHoizontalCollisions(RoomModel room)
        {
            foreach (var wall in room.Walls)
            {
                if (Bounds.Intersects(wall))
                {
                    if (Velocity.X > 0)
                    {
                        Position = new Vector2(wall.Left - Width, Position.Y);
                    }

                    else if (Velocity.X < 0)
                    {
                        Position = new Vector2(wall.Right, Position.Y);
                    }

                    Velocity = new Vector2(0, Velocity.Y);
                    break;
                }
            }

            foreach (var obj in room.Objects.Where(x => x.IsSolid))
            {
                if (Bounds.Intersects(obj.Bounds))
                {
                    if (Velocity.X > 0)
                    {
                        Position = new Vector2(obj.Bounds.Left - Width, Position.Y);
                    }
                    else if (Velocity.X < 0)
                    {
                        Position = new Vector2(obj.Bounds.Right, Position.Y);
                    }

                    Velocity = new Vector2(0, Velocity.Y);
                    break;
                }
            }
        }

        private void HandleVerticalCollisions(RoomModel room)
        {
            IsOnGround = false;
            foreach (var wall in room.Walls.Where(w => w.Height <= 250))
            {
                if (Bounds.Intersects(wall))
                {
                    if (Velocity.Y > 0)
                    {
                        Position = new Vector2(Position.X, wall.Top - Height);
                        Velocity = new Vector2(Velocity.X, 0);
                        IsOnGround = true;
                    }
                    else if (Velocity.Y < 0)
                    {
                        Position = new Vector2(Position.X, wall.Bottom);
                        Velocity = new Vector2(Velocity.X, 0); 
                    }

                    return;
                }
            }

            foreach (var obj in room.Objects.Where(o => o.IsSolid))
            {
                if (Bounds.Intersects(obj.Bounds))
                {
                    if (Velocity.Y > 0)
                    {
                        Position = new Vector2(Position.X, obj.Bounds.Top - Height);
                        Velocity = new Vector2(Velocity.X, 0);
                        IsOnGround = true;
                    }
                    else if (Velocity.Y < 0)
                    {
                        Position = new Vector2(Position.X, obj.Bounds.Bottom);
                        Velocity = new Vector2(Velocity.X, 0);
                    }

                    return;
                }
            }
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

        public void Land()
        {
            IsJumping = false;
        }
    }
}