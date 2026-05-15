using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Character;

namespace Ghost
{
    public class GhostModel : CharacterModel
    {
        public float Speed { get; set; } = 200f;

        public GhostModel(Vector2 startPosition) 
            : base(startPosition, 90, 90, 40f, 120f) {}
    }
}