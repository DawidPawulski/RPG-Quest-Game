namespace Codecool.Quest.Models.Actors {
    public class Player : Actor {
        public override string TileName { get; set; } = "player";

        public override int Attack { get; set; } = 5;

        public override int Health { get; set; } = 100;

        public readonly int maxHealth = 100;

        public override int Defense { get; set; } = 0;
        public override bool canMove { get; set; } = true;
        public override bool isAlive { get; set; } = true;

        public bool gameWin = false;

        public Player(Cell cell) : base(cell) {
        }

        public void checkPlayerDead()
        {
            if( this.Health <= 0)
            {
                isAlive = false;
            }
        }

        public bool CheckName(string name)
        {
            if (name == "GOD")
            {
                this.Defense = 10000000;
                return true;
            }
            return false;
        }
    }
}
