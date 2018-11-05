using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{

    class GameMap
    {
        private int mapWidth;
        private int mapHeight;
        private Room[,] roomsLayout;
        public Room[,] RoomsLayout
        {
            get
            {
                return roomsLayout;
            }
        }


        public GameMap()
        {
            mapWidth = 5;
            mapHeight = 5;
            roomsLayout = new Room[mapHeight, mapWidth];
            GenerateRooms();
        }

        public GameMap(int mapWidth,int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            roomsLayout = new Room[mapHeight, mapWidth];
            GenerateRooms();
        }
        public static GameMap GenerateMap()
        {
            return new GameMap();
        }

        private void GenerateRooms()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    roomsLayout[i, j] = Room.Generate(new Point(i, j));
                }
            }
        }
    }

}
