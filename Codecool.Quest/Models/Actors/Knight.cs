using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    class Knight : Mob
    {
        public override string TileName { get; set; } = "knight";

        public override int Health { get; set; } = 35;

        public override int Attack { get; set; } = 25;

        public override int Defense { get; set; } = 10;

        public override bool isAlive { get; set; } = false;

        public override int Speed { get; set; } = 25;
        public Knight(Cell cell) : base(cell)
        {

        }
    }
}
