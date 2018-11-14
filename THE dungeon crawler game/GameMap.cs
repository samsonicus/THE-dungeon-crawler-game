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
        private Point activeRoom = new Point(0,0);
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
            roomsLayout[activeRoom.X, activeRoom.Y].AddRoomToWorld();
            GameWorld.SetCameraPosition((int)(17 * Tiles.tileSize * 0.5f), (int)(13 * Tiles.tileSize * 0.5f));
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
            roomsLayout[activeRoom.X, activeRoom.Y].AddRoomToWorld();
        }
        /// <summary>
        /// Generates a new 5x5 map
        /// </summary>
        /// <returns>returns the new map</returns>
        public static GameMap GenerateMap()
        {
            return new GameMap();
        }

        /// <summary>
        /// Generates the rooms in the map
        /// </summary>
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
