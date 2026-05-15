using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Level
{
    public class LevelModel
    {
        public float Gravity { get; set; } = 1100f;
        public List<Rectangle> Walls { get; set; } = new();
        public List<LevelObject> Objects { get; set; } = new();

        private const int LevelWidth = 1280;
        private const int LevelHeight = 720;
        private const int LevelFloorY = 570;

        public List<Rectangle> GetSolidBarriers() => Walls
            .Concat(Objects
                        .Where(o => o.IsSolid)
                        .Select(o => o.Bounds))
                        .ToList();

        public LevelModel()
        {
            Walls.Add(new Rectangle(0, 0, LevelWidth, 1)); // потолок
            Walls.Add(new Rectangle(0, 0, 1, LevelHeight)); // левая стена
            Walls.Add(new Rectangle(LevelWidth - 1, 0, 1, LevelHeight)); // правая стена
            Walls.Add(new Rectangle(0, LevelFloorY, LevelWidth, LevelHeight - LevelFloorY)); // пол

            Objects.Add(new LevelObject(1, 420, 300, 150, ObjectType.Block)); // возвышенность 1
            Objects.Add(new LevelObject(800, 480, 110, 90, ObjectType.Block, false)); // возвышенность 2
            Objects.Add(new LevelObject(950, 400, 100, 170, ObjectType.Door, false)); // дверь
            Objects.Add(new LevelObject(375, 270, 80, 30, ObjectType.Platform)); // платформа 1
            Objects.Add(new LevelObject(525, 150, 80, 30, ObjectType.Platform)); // платформа 2
            Objects.Add(new LevelObject(775, 150, 125, 30, ObjectType.Platform)); // платформа 3
            Objects.Add(new LevelObject(840, 110, 50, 40, ObjectType.Chest, false)); // сундук
        }

        public void AddWall(Rectangle wall) => Walls.Add(wall);
    }
}