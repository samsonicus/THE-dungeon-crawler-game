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
        protected int collisionPushDistance = 5;
        public ObstacleTile (Vector2 starPosition, string spriteName) : base(starPosition, spriteName)
        {

        }

        public virtual void DoCollision(ICollidable otherCollidable)
        {
            if(otherCollidable is Player || otherCollidable is Enemy)
            {
                Vector2 pushDirection = (otherCollidable as Entity).Position - position;
                pushDirection.Normalize();
                if(pushDirection.Y < -0.5f)
                {
                    (otherCollidable as Entity).Position += -Vector2.UnitY * collisionPushDistance;
                }
                else if (pushDirection.Y > 0.5f)
                {
                    (otherCollidable as Entity).Position += Vector2.UnitY * collisionPushDistance;
                }
                else if (pushDirection.X < -0.5f)
                {
                    (otherCollidable as Entity).Position += -Vector2.UnitX * collisionPushDistance;
                }
                else if (pushDirection.X > 0.5f)
                {
                    (otherCollidable as Entity).Position += Vector2.UnitX * collisionPushDistance;
                }
                (otherCollidable as Entity).Position += pushDirection * collisionPushDistance;
            }
        }

        /// <summary>
        /// Checks if the tile is colliding
        /// </summary>
        /// <param name="otherCollidable">The collidable to check collision on</param>
        /// <returns>Returns is the object is colliding</returns>
        public virtual bool IsColliding(ICollidable otherCollidable)
        {
            if (otherCollidable is Player || otherCollidable is Enemy)
            {
                return CollisionBox.Intersects(otherCollidable.CollisionBox);
            }
            else return false;
        }


        /// <summary>
        /// Returns the collision box for an obstacleTile
        /// </summary>
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);
            }
        }
    }
}
