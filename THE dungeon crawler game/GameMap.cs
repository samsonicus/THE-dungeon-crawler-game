using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{

    class GameMap
    {
        private int mapWidth;
        private int mapHeight;
        private Room[,] gameMap;

        public GameMap()
        {
            mapWidth = 5;
            mapHeight = 5;
            gameMap = new Room[mapHeight, mapWidth];
        }

        public GameMap(int mapWidth,int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            gameMap = new Room[mapHeight, mapWidth];
        }
        public static GameMap GenerateMap()
        {
            return new GameMap();
        }
    }

}
