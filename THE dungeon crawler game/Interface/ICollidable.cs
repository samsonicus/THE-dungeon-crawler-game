using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    interface ICollidable
    {
        Rectangle CollisionBox { get; }
        bool IsColliding(ICollidable collidable);
        void DoCollision();
    }
}
