using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    class Alien : Mob
    {
        public override string TileName { get; set; } = "alien";

        public override int Health { get; set; } = 50;

        public override int Attack { get; set; } = 30;

        public override int Defense { get; set; } = 10;

        public override bool isAlive { get; set; } = false;

        public override int Speed { get; set; } = 5;
        public Alien(Cell cell) : base(cell)
        {

        }
    }
}
