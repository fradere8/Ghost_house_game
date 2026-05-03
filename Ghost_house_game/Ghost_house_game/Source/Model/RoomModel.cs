using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ghost_house_game.Source.Model
{
    public class RoomModel
    {
        public List<Rectangle> Walls { get; set; } = new();
        public List<RoomObject> Objects { get; set; } = new();

        public RoomModel()
        {
            Walls.Add(new Rectangle(0, 0, 1280, 0)); // потолок
            Walls.Add(new Rectangle(0, 0, 0, 720)); // левая стена
            Walls.Add(new Rectangle(1280, 0, 1280, 720)); // правая стена
            Walls.Add(new Rectangle(0, 720, 1280, 720)); // пол

            Objects.Add(new RoomObject("Пол", new Rectangle(0, 570, 1280, 720), Color.DarkViolet)); // пол
            Objects.Add(new RoomObject("Блок1", new Rectangle(0, 420, 300, 570), Color.DarkViolet)); // возвышенность 1
            Objects.Add(new RoomObject("Блок2", new Rectangle(600, 490, 750, 570), Color.DarkViolet)); // возвышенность 2
            Objects.Add(new RoomObject("Дверь", new Rectangle(950, 400, 1060, 570), Color.DarkCyan)); // дверь
            Objects.Add(new RoomObject("Платформа1", new Rectangle(375, 270, 430, 300), Color.DarkGray)); // платформа 1 
            Objects.Add(new RoomObject("Платформа2", new Rectangle(525, 150, 800, 180), Color.DarkGray)); // платформа 2
            Objects.Add(new RoomObject("Платформа3", new Rectangle(675, 150, 850, 300), Color.DarkGray)); // платформа 3
            Objects.Add(new RoomObject("Сундук", new Rectangle(740, 130, 790, 180), Color.Gold)); // сундук
        }

        public void AddWall(Rectangle wall) => Walls.Add(wall);
    }
}