using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    public class Item : Actor
    {
        public override string TileName { get; set; } = "";


        public Item(Cell cell, string name) : base(cell)
        {

            TileName = name;
        }

    }

    
}

