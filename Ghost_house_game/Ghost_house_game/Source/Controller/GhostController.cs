using System;
using Microsoft.Xna.Framework;
using Player;
using Level;
using Character;
using Attack;

namespace Ghost
{
    public class GhostController
    {
        private readonly GhostModel ghost;
        private readonly PlayerModel player;

        public GhostController(GhostModel ghost, PlayerModel player)
        {
            this.ghost = ghost;
            this.player = player;
        }

        public void Update(LevelModel level, float deltaTime)
        {
            ChasePlayer();
            TryAttack(deltaTime);
            CharacterMoveController.ApplyMovingWithCollisionsPhysics(ghost, level, deltaTime);
        }
        
        private void ChasePlayer()
        {
            var direction = player.Position.X - ghost.Position.X;

            if (Math.Abs(direction) > 5f)
            {
                ghost.Velocity = new Vector2(Math.Sign(direction) * ghost.Speed, ghost.Velocity.Y);
                ghost.IsFacingRight = direction > 0;
            }
            
            else
            {
                ghost.Velocity = new Vector2(0, ghost.Velocity.Y);
            }
        }

        private void TryAttack(float deltaTime)
        {
            if (ghost.AttackTimer > 0)
            {
                ghost.AttackTimer -= deltaTime;
                return;
            }

            AttackController.TryAttack(ghost, player, ghost.IsFacingRight, deltaTime);
        }
    }
}
