using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    class Wolf : Mob
    {
        public override string TileName { get; set; } = "wolf";

        public override int Health { get; set; } = 20;

        public override int Attack { get; set; } = 13;

        public override int Defense { get; set; } = 0;

        public override bool isAlive { get; set; } = false;

        public override int Speed { get; set; } = 75;
        public Wolf(Cell cell) : base(cell)
        {

        }
    }
}
