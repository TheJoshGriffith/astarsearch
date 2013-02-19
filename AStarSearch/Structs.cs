using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarSearch
{
    class Structs
    {
        public struct Tile
        {
            public int id;
            public int x;
            public int y;
            public int cost;
            public bool walkable;
            public int distanceLeft;
            public int parentid;
        }
    }
}
