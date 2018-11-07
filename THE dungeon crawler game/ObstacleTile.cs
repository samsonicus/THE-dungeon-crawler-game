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

        public void DoCollision(ICollidable otherCollidable)
        {
            
        }

        public bool IsColliding(ICollidable otherCollidable)
        {
            return CollisionBox.Intersects(otherCollidable.CollisionBox);
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 32, 32);
            }
        }
    }
}
