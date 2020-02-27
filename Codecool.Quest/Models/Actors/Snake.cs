using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    class Snake : Mob
    {
        public override string TileName { get; set; } = "snake";

        public override int Health { get; set; } = 10;

        public override int Attack { get; set; } = 200;

        public override int Defense { get; set; } = 0;

        public override bool isAlive { get; set; } = false;

        public override int Speed { get; set; } = 15;
        public Snake(Cell cell) : base(cell)
        {

        }
    }
}
