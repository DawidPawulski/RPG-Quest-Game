using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    class Boss : Mob
    {
        public override int Attack { get; set; } = 15;

        public override int Health { get; set; } = 40;

        public override int Defense { get; set; } = 5;

        public override string TileName { get; set; } = "boss";

        public override bool isAlive { get; set; } = false;
        public override bool canMove { get; set; } = false;

        public override int Speed { get; set; } = 5;
        public Boss(Cell cell) : base(cell)
        {

        }

    }
}
