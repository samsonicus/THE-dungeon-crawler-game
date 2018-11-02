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
        private RoomType
        private Point roomMapPos;
        private GameObject[,] roomTiles;
        public Room(Point roomMapPos)
        {
            roomTiles = new GameObject[16, 12];
            this.roomMapPos = roomMapPos;

        }
    }
}
