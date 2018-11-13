using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    enum RoomType { StartRoom,NormalRoom,ExitRoom}
    class Room
    {
        private RoomType roomType = RoomType.NormalRoom;

        /// <summary>
        /// Returns the room type of the room.
        /// </summary>
        public RoomType RoomType
        {
            get
            {
                return roomType;
            }
        }
        private Point roomMapPos;
        private Tiles[,] roomTiles;

        /// <summary>
        /// Room constructor
        /// </summary>
        /// <param name="roomMapPos">The posistion of the room in the game map (x,y)</param>
        public Room(Point roomMapPos,RoomType roomType)
        {
            roomTiles = new Tiles[17, 13];
            this.roomMapPos = roomMapPos;
            this.roomType = roomType;
            Genrerate();
        }

        /// <summary>
        /// Generates a room from tiles
        /// </summary>
        private void Genrerate()
        {
            for (int i = 0; i < roomTiles.GetLength(0); i++)
            {
                for (int j = 0; j < roomTiles.GetLength(1); j++)
                {
                    roomTiles[i, j] = new Tiles(new Vector2((i * Tiles.tileSize)+(roomMapPos.X*2500), (j * Tiles.tileSize)+(roomMapPos.Y*2500)), "Tiles/MetalFloor1");
                    Debug.Print($"Added Tile{roomTiles[i,j].Position}");
                }
            }
            if (!ValidateRoom())
            {
                roomTiles = new Tiles[13, 17];
                Genrerate();
                return;
            }
            AddTilesToWorld();
            return;
        }

        /// <summary>
        /// Add the roomTiles to the gameworld
        /// </summary>
        private void AddTilesToWorld()
        {
            foreach (Tiles tiles in roomTiles)
            {
                GameWorld.AddGameObject(tiles);

            }   
        }

        /// <summary>
        /// Removes the room from the game map
        /// </summary>
        public void RemoveRoom()
        {
            foreach (Tiles tiles in roomTiles)
            {
                GameWorld.RemoveGameObject(tiles);
            }
        }

        /// <summary>
        /// Validates the room - !!! NOT Implemented !!!
        /// </summary>
        /// <returns>Returns if the room is valid</returns>
        private bool ValidateRoom()
        {
            //TODO
            return true;
        }

        /// <summary>
        /// Generate a new Room object
        /// </summary>
        /// <param name="roomMapPos">The position of the room in the 2d map array</param>
        /// <returns>Returns a new room object</returns>
        public static Room GenerateRoom(Point roomMapPos)
        {
            return new Room(roomMapPos, RoomType.NormalRoom); 
        }
    }
}
