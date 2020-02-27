namespace Codecool.Quest.Models.Actors {
    public class Skeleton :  Mob {
        public override string TileName { get; set; } = "skeleton";

        public override int Health { get; set; } = 10;

        public override int Attack { get; set; } = 5;

        public override int Defense { get; set; } = 0;

        public override bool isAlive { get; set; } = false;
        public override bool canMove { get; set; } = false;

        public override int Speed { get; set; } = 15;
        public Skeleton(Cell cell) : base(cell) {

        }

        
    }
}
