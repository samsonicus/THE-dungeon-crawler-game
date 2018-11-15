using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Class for containing and building the game map
    /// </summary>
     public class GameMap
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
        /// Change the active room
        /// </summary>
        /// <param name="x">collom to select</param>
        /// <param name="y">row to select</param>
        /// <exception cref="IndexOutOfRangeException">Throws out of index is you use negative numbers</exception>
        public void SwapRoom(int x, int y)
        {
            Debug.Print($"x:{x},y:{y}");
            if(x >= mapWidth || y >= mapHeight)
            {
                return;
            }
            roomsLayout[activeRoom.Y, activeRoom.X].RemoveRoomFromWorld();
            roomsLayout[y, x].AddRoomToWorld();
            if(y > activeRoom.Y && x == activeRoom.X)
            {
                GameWorld.Player.Position = new Vector2(8 * Tiles.tileSize, Tiles.tileSize+10);
            }
            else if(y < activeRoom.Y && x == activeRoom.X)
            {
                GameWorld.Player.Position = new Vector2(8 * Tiles.tileSize, 12*Tiles.tileSize);
            }
            else if(x > activeRoom.X && y == activeRoom.Y)
            {
                GameWorld.Player.Position = new Vector2(Tiles.tileSize+10, 6 * Tiles.tileSize);
            }
            else if(y == activeRoom.Y)
            {
                GameWorld.Player.Position = new Vector2(15 * Tiles.tileSize, 6 * Tiles.tileSize);
            }
            activeRoom = new Point(x, y);
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
                    roomsLayout[i, j] = Room.GenerateRoom(new Point(j, i));
                    if(i > 0)
                    {
                        roomsLayout[i, j].AddDoor(Faceing.North);
                    }
                    if(i < mapHeight - 1)
                    {
                        roomsLayout[i, j].AddDoor(Faceing.South);
                    }
                    if (j > 0)
                    {
                        roomsLayout[i, j].AddDoor(Faceing.West);
                    }
                    if (j < mapWidth -1)
                    {
                        roomsLayout[i, j].AddDoor(Faceing.East);
                    }
                }
            }

        }
    }

}
