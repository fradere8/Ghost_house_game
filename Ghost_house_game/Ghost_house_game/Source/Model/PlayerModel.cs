using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Character;

namespace Player
{
    public class PlayerModel : CharacterModel
    {
        public float Speed = 300f;
        public float JumpForce = -600f;
        
        public PlayerModel(Vector2 startPosition) 
            : base(startPosition, 96, 96, 50f, 200f) {}             
    }
}
