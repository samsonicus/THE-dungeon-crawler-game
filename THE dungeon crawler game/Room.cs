using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Enum for room types
    /// </summary>
    public enum RoomType { StartRoom,NormalRoom,ExitRoom}
    /// <summary>
    /// Class for building and containing rooms
    /// </summary>
    public class Room
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
        public Tiles[,] RoomTiles
        {
            get { return roomTiles; }
        }
        

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
                    if(i == 0 || i == roomTiles.GetLength(0)-1 || j == 0 || j == roomTiles.GetLength(1)-1)
                    {
                        roomTiles[i, j] = new ObstacleTile(new Vector2(i * Tiles.tileSize, j * Tiles.tileSize),"Tiles/BlueWall1");
                        continue;
                    }
                    roomTiles[i, j] = new Tiles(new Vector2(i * Tiles.tileSize, j * Tiles.tileSize), "Tiles/MetalFloor1");
                    Debug.Print($"Added Tile{roomTiles[i,j].Position}");
                }
            }
            if (!ValidateRoom())
            {
                roomTiles = new Tiles[13, 17];
                Genrerate();
                return;
            }
            return;
        }

        public void AddDoor(Faceing faceing)
        {
            switch (faceing)
            {
                case Faceing.North:
                    roomTiles[8, 0] = new DoorTile(roomTiles[8, 0].Position, "Tiles/BlueDoor", new Point(roomMapPos.X, roomMapPos.Y-1));
                    break;
                case Faceing.East:
                    roomTiles[16, 6] = new DoorTile(roomTiles[16,6].Position, "Tiles/BlueDoor", new Point(roomMapPos.X+1, roomMapPos.Y));
                    break;
                case Faceing.South:
                    roomTiles[8, 12] = new DoorTile(roomTiles[8,12].Position, "Tiles/BlueDoor", new Point(roomMapPos.X, roomMapPos.Y+1));
                    break;
                case Faceing.West:
                    roomTiles[0, 6] = new DoorTile(roomTiles[0,6].Position, "Tiles/BlueDoor", new Point(roomMapPos.X-1, roomMapPos.Y));
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Add the roomTiles to the gameworld
        /// </summary>
        public void AddRoomToWorld()
        {
            foreach (Tiles tiles in roomTiles)
            {
                GameWorld.AddGameObject(tiles);
            }   
        }

        /// <summary>
        /// Removes the room from the game map
        /// </summary>
        public void RemoveRoomFromWorld()
        {
            foreach (GameObject tiles in roomTiles)
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
        /// <param name="roomMapPos">The position of the room in the 2d map array(y,x)</param>
        /// <returns>Returns a new room object</returns>
        public static Room GenerateRoom(Point roomMapPos)
        {
            return new Room(roomMapPos, RoomType.NormalRoom); 
        }
    }
}
