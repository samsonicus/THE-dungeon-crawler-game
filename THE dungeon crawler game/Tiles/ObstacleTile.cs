﻿using System;
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

        public void DoCollision(ICollidable otherCollidable)
        {
            if(otherCollidable is Player || otherCollidable is Enemy)
            {
                Vector2 pushDirection = (otherCollidable as Entity).Position - position;
                pushDirection.Normalize();
                (otherCollidable as Entity).Position += pushDirection * collisionPushDistance;
            }
        }

        public bool IsColliding(ICollidable otherCollidable)
        {
            if (otherCollidable is Player || otherCollidable is Enemy)
            {
                return CollisionBox.Intersects(otherCollidable.CollisionBox);
            }
            else return false;
        }

        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);
            }
        }
    }
}
