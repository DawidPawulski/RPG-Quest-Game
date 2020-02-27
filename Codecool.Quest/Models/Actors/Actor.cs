namespace Codecool.Quest.Models.Actors {
    public abstract class Actor : IDrawable {
        public Cell Cell { get; private set; }
        public virtual int Health { get; set; }

        public virtual int Attack { get; set; }

        public virtual int Defense { get; set; }
        public virtual bool isAlive { get; set; }
        public virtual bool canMove { get; set; }
        public virtual bool isHit { get; set; }

        public int X { get =>   this.Cell.X; }
        public int Y { get =>   this.Cell.Y; }
        public abstract string TileName { get; set; }

        public Actor(Cell cell) {
            this.Cell = cell;
            this.Cell.Actor = this;
        }
        
        public void Move(int dx, int dy) {
            if (this.canMove)
            {
                Cell nextCell = this.Cell.GetNeighbor(dx, dy);
                this.Cell.Actor = null;
                nextCell.Actor = this;
                this.Cell = nextCell;
            }

        }

        public void AttackNeighborCell(Cell neighborCell)
        {
            
            neighborCell.Actor.Health -= (Attack - neighborCell.Actor.Defense);

            if (neighborCell.Actor.Health <= 0)
            {
                Tiles.DeleteActor(neighborCell);                
                neighborCell.Actor.isAlive = false;
                
            }
            else
            {
                neighborCell.Actor.isHit = true;
                if ((neighborCell.Actor.Attack - Defense) >= 0)
                {
                    Health -= (neighborCell.Actor.Attack - Defense);
                    this.isHit = true;
                }
                
            }
        }

        public void GotHit()
        {            
            canMove = false;
            string temp = this.TileName;
            this.TileName = "hit";
            System.Threading.Thread.Sleep(300);
            this.TileName = temp;
            canMove = true;
            isHit = false;
        }
    }
}
