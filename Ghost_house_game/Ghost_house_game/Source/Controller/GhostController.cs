using System;
using Microsoft.Xna.Framework;
using Ghost;
using Player;
using Level;
using Character;

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
            CharacterMoveController.ApplyMovingWithCollisionsPhysics(ghost, level, deltaTime);
/*             if (ghost.Velocity.X > 0)
                ghost.IsFacingRight = true;
            else if (ghost.Velocity.X < 0)
                ghost.IsFacingRight = false; */
        }
        
        private void ChasePlayer()
        {
            var direction = player.Position.X - ghost.Position.X;

            if (Math.Abs(direction) > 5f)
            {
                ghost.Velocity = new Vector2(Math.Sign(direction) * ghost.Speed, ghost.Velocity.Y);
            }
            
            else
            {
                ghost.Velocity = new Vector2(0, ghost.Velocity.Y);
            }
        }
    }
}