using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models
{
    public static class Directions
    {
        public static readonly int[] North = new int[] {1, 0 };
        public static readonly int[] South = new int[] { -1, 0 };
        public static readonly int[] West = new int[] { 0, -1 };
        public static readonly int[] East = new int[] { 0, 1 };
        public static readonly int[] NorthEast = new int[] { 1, 1 };
        public static readonly int[] NorthWest = new int[] { 1, -1 };
        public static readonly int[] SouthEast = new int[] { -1, 1 };
        public static readonly int[] SouthWest = new int[] { -1, -1 };
        public static readonly List<int[]> directions = new List<int[]> { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest };
        

    }
}
