using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class ObstacleTile : Tiles, ICollidable
    {
        public ObstacleTile (Vector2 starPosition, string spriteName) : base(starPosition, spriteName)
        {

        }

        public void DoCollision()
        {
            throw new NotImplementedException();
        }

        public bool IsColliding()
        {
            throw new NotImplementedException();
        }

        Rectangle ICollidable.CollisionBox()
        {
            throw new NotImplementedException();
        }
    }
}
