using Codecool.Quest.Models.Actors;
using System.IO;
using System.Threading;


namespace Codecool.Quest.Models {
    public class MapLoader {

        //public static string level { get; set; } = @"\Resources\map.txt";

        public static GameMap LoadMap(string level) {
            string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string level = @"\Resources\map.txt";
            StreamReader stream = new StreamReader(dir + level);
            string firstline = stream.ReadLine();
            string[] firstline_split = firstline.Split(' ');

            int width = int.Parse(firstline_split[0]);
            int height = int.Parse(firstline_split[1]);



            GameMap map = new GameMap(width, height, CellType.EMPTY);

            for (int y = 0; y < height; y++) {
                string line = stream.ReadLine();

                for (int x = 0; x < width; x++) {
                    if (x < line.Length) {
                        Cell cell = map.GetCell(x, y);

                        switch (line[x]) {
                            case ' ': {
                                    cell.CellType = CellType.EMPTY;
                                    break;
                                }
                            case '#': {
                                    cell.CellType = CellType.WALL;
                                    break;
                                }
                            case '.': {
                                    cell.CellType = CellType.FLOOR;
                                    break;
                                }
                            case 's': {
                                    cell.CellType = CellType.MOB;
                                    new Skeleton(cell);
                                    map.mobs.Add(cell.Actor);
                                    map.AddMobTypeToList(cell.Actor.TileName);
                                    break;
                                }
                            case '@': {
                                    cell.CellType = CellType.FLOOR;
                                    map.Player = new Player(cell);
                                    break;
                                }
                            case 'w':
                                {
                                    cell.CellType = CellType.ITEM;
                                    new Item(cell, "sword");
                                    break;
                                }
                            case 'h':
                                {
                                    cell.CellType = CellType.ITEM;
                                    new Item(cell, "shield");
                                    break;
                                }
                            case 'r':
                                {
                                    cell.CellType = CellType.ITEM;
                                    new Item(cell, "armor");
                                    break;
                                }
                            case 'k':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "key");
                                break;
                            case 'd':
                                cell.CellType = CellType.DOOR;
                                new Item(cell, "door");
                                break;
                            case 'b':
                                cell.CellType = CellType.MOB;
                                new Boss(cell);
                                map.mobs.Add(cell.Actor);
                                map.AddMobTypeToList(cell.Actor.TileName);
                                break;
                            case 'e':
                                cell.CellType = CellType.LEVEL2;
                                break;
                            case 't':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "tree");
                                break;
                            case '[':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "water");
                                break;
                            case 'o':
                                cell.CellType = CellType.DOOR;
                                new Item(cell, "bridge");
                                break;
                            case ';':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "wood");
                                break;
                            case 'g':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "grave");
                                break;
                            case 'j':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "skull");
                                break;
                            case 'i':
                                cell.CellType = CellType.MOB;
                                new Wolf(cell);
                                map.mobs.Add(cell.Actor);
                                map.AddMobTypeToList(cell.Actor.TileName);
                                break;
                            case 'y':
                                cell.CellType = CellType.MOB;
                                new Snake(cell);
                                map.mobs.Add(cell.Actor);
                                map.AddMobTypeToList(cell.Actor.TileName);
                                break;
                            case 'f':
                                cell.CellType = CellType.MOB;
                                new Bandit(cell);
                                map.mobs.Add(cell.Actor);
                                map.AddMobTypeToList(cell.Actor.TileName);
                                break;
                            case '8':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "roof1");
                                break;
                            case '9':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "roof2");
                                break;
                            case '0':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "roof3");
                                break;
                            case '*':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castle1");
                                break;
                            case '(':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castle2");
                                break;
                            case ')':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castle3");
                                break;
                            case '-':
                                cell.CellType = CellType.LEVEL3;
                                new Environment(cell, "castleDoor");
                                break;
                            case 'p':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "potion");
                                break;
                            case 'a':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "axe");
                                break;
                            case 'z':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "superArmor");
                                break;
                            case ',':
                                cell.CellType = CellType.CASTLE;
                                //new Environment(cell, "castleFloor");
                                break;
                            case 'c':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castleWall");
                                break;
                            case 'q':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "candelabr");
                                break;
                            case '1':
                                cell.CellType = CellType.MOB;
                                new Knight(cell);
                                map.mobs.Add(cell.Actor);
                                map.AddMobTypeToList(cell.Actor.TileName);
                                break;
                            case '2':
                                cell.CellType = CellType.MOB;
                                new Alien(cell);
                                map.mobs.Add(cell.Actor);
                                map.AddMobTypeToList(cell.Actor.TileName);
                                break;
                            case '/':
                                cell.CellType = CellType.WIN;
                                new Environment(cell, "stairs");
                                break;
                            case '3':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "helmet");
                                break;
                            case '4':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "bazooka");
                                break;
                            case '5':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "rocket");
                                break;
                            case '`':
                                cell.CellType = CellType.FLOOR;
                                new Environment(cell, "king");
                                break;
                        }
                    }
                }
            }
    
            return map;
        }
    }
}