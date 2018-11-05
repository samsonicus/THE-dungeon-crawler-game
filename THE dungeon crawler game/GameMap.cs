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
        /// <summary>
        /// Returns the 2d array of rooms in the map
        /// </summary>
        public Room[,] RoomsLayout
        {
            get
            {
                return roomsLayout;
            }
        }

        /// <summary>
        /// Constructer for the GameMap Object
        /// </summary>
        public GameMap()
        {
            mapWidth = 5;
            mapHeight = 5;
            roomsLayout = new Room[mapHeight, mapWidth];
            GenerateRooms();
        }

        /// <summary>
        /// Constructer for the GameMap Object
        /// </summary>
        /// <param name="mapWidth">The amount of rooms wide the map should be</param>
        /// <param name="mapHeight">The amount of rooms heigh the map should be</param>
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
                    roomsLayout[i, j] = Room.GenerateRoom(new Point(i, j));
                }
            }
        }
    }

}
