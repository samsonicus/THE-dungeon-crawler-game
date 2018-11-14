using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class DoorTile : ObstacleTile
    {
        private Point targetRoomPos;
        public DoorTile(Vector2 starPosition, string spriteName, Point targetRoomPos) : base(starPosition, spriteName)
        {
            this.targetRoomPos = targetRoomPos;
        }

        public override void DoCollision(ICollidable otherCollidable)
        {
            if(otherCollidable is Player)
            {
                GameWorld.ActiveGameMap.SwapRoom(targetRoomPos.X, targetRoomPos.Y);
            }
            else
            {
                base.DoCollision(otherCollidable);
            }
        }
    }
}
