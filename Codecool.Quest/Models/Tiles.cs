using System.Collections.Generic;
using System.Drawing;

namespace Codecool.Quest.Models {
    public static class Tiles {
        public const int TILE_WIDTH = 16;
        public const int DRAW_SCALE = 2;

        private static Bitmap tileSet;
        public static Dictionary<string, Tile> tileMap;

        static Tiles() {
            tileSet = new Bitmap("Resources/roguelikeDungeon_transparent.png");
            tileMap = new Dictionary<string, Tile>();

            tileMap.Add("empty", new Tile(0, 0));
            tileMap.Add("wall", new Tile(1, 3));
            tileMap.Add("floor", new Tile(2, 0));
            tileMap.Add("player", new Tile(25, 0));
            tileMap.Add("skeleton", new Tile(29, 6));
            tileMap.Add("sword", new Tile(3, 31));
            tileMap.Add("shield", new Tile(7, 26));
            tileMap.Add("armor", new Tile(3, 23));
            tileMap.Add("key", new Tile(16, 23));
            tileMap.Add("door", new Tile(3, 3));
            tileMap.Add("boss", new Tile(25, 8));
            tileMap.Add("hit", new Tiles.Tile(26, 11));
            tileMap.Add("level2", new Tiles.Tile(0, 3));
            tileMap.Add("stairs", new Tiles.Tile(3, 6));
            tileMap.Add("tree", new Tiles.Tile(4, 2));
            tileMap.Add("water", new Tiles.Tile(8, 4));
            tileMap.Add("bridge", new Tiles.Tile(17, 5));
            tileMap.Add("wood", new Tiles.Tile(6, 2));
            tileMap.Add("grave", new Tiles.Tile(1, 14));
            tileMap.Add("skull", new Tiles.Tile(1, 15));
            tileMap.Add("wolf", new Tiles.Tile(31, 7));
            tileMap.Add("snake", new Tiles.Tile(28, 8));
            tileMap.Add("bandit", new Tiles.Tile(26, 0));
            tileMap.Add("roof1", new Tiles.Tile(5, 12));
            tileMap.Add("roof2", new Tiles.Tile(6, 12));
            tileMap.Add("roof3", new Tiles.Tile(7, 12));
            tileMap.Add("castle1", new Tiles.Tile(5, 13));
            tileMap.Add("castle2", new Tiles.Tile(6, 13));
            tileMap.Add("castle3", new Tiles.Tile(7, 13));
            tileMap.Add("castleDoor", new Tiles.Tile(11, 16));
            tileMap.Add("potion", new Tiles.Tile(16, 25));
            tileMap.Add("axe", new Tiles.Tile(9, 29));
            tileMap.Add("superArmor", new Tiles.Tile(4, 23));
            tileMap.Add("castleFloor", new Tiles.Tile(19, 1));
            tileMap.Add("castle", new Tiles.Tile(19, 1));
            tileMap.Add("castleWall", new Tiles.Tile(10, 17));
            tileMap.Add("candelabr", new Tiles.Tile(4, 15));
            tileMap.Add("knight", new Tiles.Tile(29, 0));
            tileMap.Add("alien", new Tiles.Tile(27, 3));
            tileMap.Add("bazooka", new Tiles.Tile(11, 31));
            tileMap.Add("rocket", new Tiles.Tile(17, 31));
            tileMap.Add("helmet", new Tiles.Tile(6, 22));
            tileMap.Add("king", new Tiles.Tile(28, 3));
        }


        public class Tile {
            public int x, y, w, h;
            public Bitmap bitmap;
            public Tile(int i, int j) {
                x = i * (TILE_WIDTH + 1);
                y = j * (TILE_WIDTH + 1);
                w = TILE_WIDTH;
                h = TILE_WIDTH;
                bitmap = tileSet.Clone(new Rectangle(x, y, w, h), System.Drawing.Imaging.PixelFormat.Format32bppArgb);                
            }
        }
        
        
        public static void DrawTile(Graphics graphics, IDrawable d, int x, int y) {
            Tile tile = tileMap[d.TileName];

            graphics.DrawImage(tile.bitmap, x * TILE_WIDTH * DRAW_SCALE, y * TILE_WIDTH * DRAW_SCALE, tile.w * DRAW_SCALE, tile.h * DRAW_SCALE);
        }

        public static void DeleteActor(Cell neighborCell)
        {
            neighborCell.Actor.TileName = "floor";
            neighborCell.CellType = CellType.FLOOR;
            neighborCell.Actor.isAlive = false;
            neighborCell.Actor.canMove = false;
        }
    }
}
