using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Ghost;
using Player;
using Level;

namespace Ghost_house_game.Source.Controller
{
    public class GhostController
    {
        private GhostModel ghost;
        private PlayerModel player;

        public void Update(LevelModel level, float deltaTime)
        {
            ChasePlayer();
            Character.CharacterMoveController.ApplyMovingWithCollisionsPhysics(ghost, level, deltaTime);
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