using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Level;

namespace Character
{
    public class CharacterModel
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float AttackForce { get; set; }
        public float Health { get; set; }
        public bool IsOnGround { get; set; } = false;
        public bool IsAlive { get; set; } = true;
        public bool IsAttacking { get; set; } = false;
        public Rectangle Bounds => new Rectangle(
            (int)Position.X,
            (int)Position.Y,
            Width,
            Height
        );

        public CharacterModel(Vector2 startPosition, int width, int height, float attackForce, float health)  
        {
            Position = startPosition;
            Velocity = Vector2.Zero;
            Width = width;
            Height = height;
            AttackForce = attackForce;
            Health = health;
        }

        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
        }
    }
}