using Microsoft.Xna.Framework;
using Level;

namespace Character
{
    public static class CharacterMoveController
    {
        public static void ApplyMovingWithCollisionsPhysics(CharacterModel character, LevelModel level, float deltaTime)
        {
            var position = character.Position;
            var velocity = character.Velocity;
            var isOnGround = false;

            velocity.Y += level.Gravity * deltaTime;

            var barriers = level.GetSolidBarriers();

            var horizontal = Collisions.Collisions.HandleHorizontalCollisions(
                position, velocity,
                character.Width, character.Height,
                barriers, deltaTime);

            position = horizontal.position;
            velocity = horizontal.velocity;

            var vertical = Collisions.Collisions.HandleVerticalCollisions(
                position, velocity,
                character.Width, character.Height,
                isOnGround,
                barriers, deltaTime);

            position = vertical.position;
            velocity = vertical.velocity;
            isOnGround = vertical.isOnGround;

            character.Position = position;
            character.Velocity = new Vector2(0, velocity.Y);
            character.IsOnGround = isOnGround;
        }
    }
}
