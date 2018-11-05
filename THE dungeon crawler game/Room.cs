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
        public RoomType RoomType
        {
            get
            {
                return roomType;
            }
        }
        private Point roomMapPos;
        private GameObject[,] roomTiles;

        /// <summary>
        /// Room constructor
        /// </summary>
        /// <param name="roomMapPos">The posistion of the room in the game map</param>
        public Room(Point roomMapPos,RoomType roomType)
        {
            roomTiles = new GameObject[16, 12];
            this.roomMapPos = roomMapPos;
            this.roomType = roomType; 
        }

        public static Room GenerateRoom(Point roomMapPos)
        {
            return new Room(roomMapPos, RoomType.NormalRoom); 
        }
    }
}
