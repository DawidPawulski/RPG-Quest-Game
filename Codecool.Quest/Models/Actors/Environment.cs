using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    class Environment : Actor
    {
        public override string TileName { get; set; } = "";


        public Environment(Cell cell, string name) : base(cell)
        {

            TileName = name;
        }
    }
}
