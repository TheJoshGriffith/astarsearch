using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarSearch
{
    class PathFinder
    {
        public Structs.Tile[] map;

        public Structs.Tile[] Map
        {
            set{ map = value; }
            get{ return map; }
        }

        public int getTile(int x, int y, Structs.Tile[] map)
        {
            int i = 0;
            foreach (Structs.Tile til in map)
            {
                if (til.x == x && til.y == y)
                {
                    return i;
                }
                i++;
            }
            return 0;
        }

        public List<Structs.Tile> getSurroundingTiles(Structs.Tile baseTile)
        {
            List<Structs.Tile> tiles = new List<Structs.Tile>();
            foreach (Structs.Tile tile in map)
            {
                if (Math.Abs(tile.x - baseTile.x) <= 1 && Math.Abs(tile.y - baseTile.y) <= 1)
                {
                   tiles.Add(tile);
                }
            }
            return tiles;
        }

        public List<Structs.Tile> findPath(int startx, int starty, int goalx, int goaly, Structs.Tile[] map)
        {
            List<Structs.Tile> closedList = new List<Structs.Tile>();
            List<Structs.Tile> openList = new List<Structs.Tile>();
            List<Structs.Tile> pathList = new List<Structs.Tile>();

            Structs.Tile Current = new Structs.Tile();
            int i = 0; // This is for the if loop
            int index = 0; // This is for storing which tile we are currently stood on.
            Current.x = startx;
            Current.y = starty;
            foreach (Structs.Tile tile in map)
            {
                if (tile.x == Current.x && tile.y == Current.y)
                {
                    index = i;
                }
                i++;
            }

            foreach (Structs.Tile tile in map)
            {
                foreach (Structs.Tile tile1 in getSurroundingTiles(Current))
                {
                    if (tile1.x == tile.x && tile1.y == tile.y)
                    {
                        Structs.Tile curTile = tile1;
                        curTile.parentid = Current.id;
                        curTile.distanceLeft = (Math.Abs(tile.x - goalx) + Math.Abs(tile.y - goaly));
                        openList.Add(curTile);
                    }
                }
            }
            return pathList;
        }
    }
}
