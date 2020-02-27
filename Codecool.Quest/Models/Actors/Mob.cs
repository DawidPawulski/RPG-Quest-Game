using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Actors
{
    public abstract class Mob : Actor
    {
        public virtual int Speed { get; set; }


        public Mob(Cell cell) : base(cell)
        {
        }

        public void MobMovement()
        {
            int waitTime = 10000 / Speed;
            int x;
            int y;
            List<int> direction = new List<int> { -1, 0, 1 };
            var random = new Random();
            int index1 = random.Next(direction.Count);
            int index2 = random.Next(direction.Count);
            x = direction[index1];
            y = direction[index2];
            System.Threading.Thread.Sleep(waitTime);
            checkIfNextToPlayer();
            if (this.canMove)
            {
                this.Cell.CellType = CellType.FLOOR;
                Move(x, y);
            }
            
        }

        public void checkIfNextToPlayer()
        {
            foreach(int[] direction in Directions.directions)
            {
                Cell neighborCell = this.Cell.GetNeighbor(direction[0], direction[1]);
                if(neighborCell.Actor != null)
                {
                    if(neighborCell.Actor.TileName == "player")
                    {
                        this.canMove = false;
                    }
                }

            }
        }

    }
}
