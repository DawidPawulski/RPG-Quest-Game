using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    class Bandit : Mob
    {
        public override string TileName { get; set; } = "bandit";

        public override int Health { get; set; } = 35;

        public override int Attack { get; set; } = 15;

        public override int Defense { get; set; } = 5;

        public override bool isAlive { get; set; } = false;

        public override int Speed { get; set; } = 25;
        public Bandit(Cell cell) : base(cell)
        {

        }
    }
}
