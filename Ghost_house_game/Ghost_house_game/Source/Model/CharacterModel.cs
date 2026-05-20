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
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public bool IsOnGround { get; set; } = false;
        public bool IsDead => CurrentHealth <= 0;
        public float AttackRadius { get; set; }
        public float AttackCooldown { get; set; }
        public float AttackTimer { get; set; }
        public bool IsAttacking { get; set; } = false;
        public Rectangle Bounds => new Rectangle(
            (int)Position.X,
            (int)Position.Y,
            Width,
            Height
        );

        public CharacterModel(Vector2 startPosition, int width, int height, float attackForce, float health, float attackRadius, float attackCooldown)  
        {
            Position = startPosition;
            Velocity = Vector2.Zero;
            Width = width;
            Height = height;
            AttackForce = attackForce;
            MaxHealth = health;
            CurrentHealth = health;
            AttackRadius = attackRadius;
            AttackCooldown = attackCooldown;
            AttackTimer = 0f;
        }

         public Rectangle GetAttackBounds(bool isFacingRight)
        {
            var attackX = isFacingRight
                ? (int)Position.X + Width
                : (int)Position.X - (int)AttackRadius;

            return new Rectangle(
                attackX,
                (int)Position.Y,
                (int)AttackRadius,
                Height
            );
        }

        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
        }
    }
}