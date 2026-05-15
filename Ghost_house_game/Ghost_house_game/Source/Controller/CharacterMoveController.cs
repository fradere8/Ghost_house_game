using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Level;
using Collisions;

namespace Character
{
    public static class CharacterMoveController
    {
        public static void ApplyMovingWithCollisionsPhysics(CharacterModel character, LevelModel level, float deltaTime)
        {
            var position = character.Position;
            var velocity = character.Velocity;
            velocity.Y += level.Gravity * deltaTime;

            var barriers = level.GetSolidBarriers();

            Collisions.Collisions.MoveHorisontal(position, velocity, character.Bounds, barriers, deltaTime);
            Collisions.Collisions.MoveVertical(position, velocity, character.Bounds,character.IsOnGround, barriers, deltaTime);

            character.Position = position;
            character.Velocity = new Vector2(0, velocity.Y);
        }
    }
}