using Codecool.Quest.Models.Actors;
using System.Collections.Generic;

namespace Codecool.Quest.Models {
    public class GameMap {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public int num { get; set; } = 1;
        public bool mapChanging = false;

        public Inventory inventory = new Inventory();

        private readonly Cell[,] cells;
        public Player Player { get; set; }
        public List<Actor> mobs = new List<Actor>();
        public List<string> mobTypes = new List<string>();
       


        public GameMap(int width, int height, CellType defaultCellType) {
            this.Width = width;
            this.Height = height;
            cells = new Cell[width, height];
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    cells[x, y] = new Cell(this, x, y, defaultCellType);
                }
            }
        }

        public Cell GetCell(int x, int y) {
            try
            {
                return cells[x, y];
            }
            catch (System.IndexOutOfRangeException)
            {
                return cells[x-1, y-1];
            }
            
        }
        public void StartMobs()
        {
            foreach(Mob mob in mobs)
            {
                mob.isAlive = true;
                mob.canMove = true;
            }
        }
        public void MoveMobs()
        {
            foreach(Mob mob in mobs)
            {
                
                if (mob.isAlive)
                {
                    mob.MobMovement();
                }
                if (mob.isHit)
                {
                    mob.GotHit();
                }                
            }
        }

        public void AddMobTypeToList(string mobType)
        {
            if (!mobTypes.Contains(mobType))
            {
                mobTypes.Add(mobType);
            }
        }
        public void RemoveMobs(Cell cell)
        {
            if(cell.Actor.isAlive == false)
            {
                mobs.Remove(cell.Actor);
            }            
        }

        public string changeMapLevel(int num)
        {
            if (num == 1)
            {
                return @"\Resources\map.txt";
            }
            else if (num == 2)
            {
                return @"\Resources\forest.txt";
            }
            else if (num == 3)
            {
                return @"\Resources\castle.txt";
            }
            else
            {
                return @"\Resources\map.txt";
            }
        }
    }
}
