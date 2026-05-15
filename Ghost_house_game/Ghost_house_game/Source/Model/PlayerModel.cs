using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Room;
using Character;

namespace Player
{
    public class PlayerModel : CharacterModel
    {
        public float Speed = 300f;
        public float JumpForce = -600f;
        
        public PlayerModel(Vector2 startPosition) 
            : base(startPosition, 96, 96, 50f, 200f) {}

        /* public void Update(RoomModel room, float deltaTime)
        {
            IsOnGround = false;

            Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * deltaTime);
           
            MoveHorisontal(room, deltaTime);
            MoveVertical(room, deltaTime);
            Velocity = new Vector2(0, Velocity.Y);
        }*/
             
    }
}
