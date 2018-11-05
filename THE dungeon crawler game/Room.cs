using Microsoft.Xna.Framework;
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
        /// <param name="roomMapPos">The posistion of the room in the game map</param>
        public Room(Point roomMapPos,RoomType roomType)
        {
            roomTiles = new Tiles[16, 12];
            this.roomMapPos = roomMapPos;
            this.roomType = roomType; 
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
