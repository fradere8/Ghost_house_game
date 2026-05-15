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

        public List<Rectangle> GetSolidBarriers() => Walls
            .Concat(Objects
                        .Where(o => o.IsSolid)
                        .Select(o => o.Bounds))
                        .ToList();

        /* public LevelModel()
        {
            Walls.Add(new Rectangle(0, 0, 1280, 1)); // потолок
            Walls.Add(new Rectangle(0, 0, 1, 720)); // левая стена
            Walls.Add(new Rectangle(1279, 0, 1, 720)); // правая стена
            Walls.Add(new Rectangle(0, 570, 1280, 150)); // пол

            Objects.Add(new LevelObject("Блок1", new Rectangle(1, 420, 300, 150), Color.DarkViolet)); // возвышенность 1
            Objects.Add(new LevelObject("Блок2", new Rectangle(600, 480, 110, 90), Color.DarkViolet)); // возвышенность 2
            Objects.Add(new LevelObject("Дверь", new Rectangle(950, 400, 100, 170), Color.DarkCyan, false)); // дверь
            Objects.Add(new LevelObject("Платформа1", new Rectangle(375, 270, 80, 30), Color.DarkGray)); // платформа 1 
            Objects.Add(new LevelObject("Платформа2", new Rectangle(525, 150, 80, 30), Color.DarkGray)); // платформа 2
            Objects.Add(new LevelObject("Платформа3", new Rectangle(775, 150, 125, 30), Color.DarkGray)); // платформа 3
            Objects.Add(new LevelObject("Сундук", new Rectangle(840, 110, 50, 40), Color.Gold, false)); // сундук
        } */

        public void AddWall(Rectangle wall) => Walls.Add(wall);
    }
}