using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Interface for collidable elements
    /// </summary>
    public interface ICollidable
    {
        Rectangle CollisionBox { get; }
        bool IsColliding(ICollidable otherCollidable);
        void DoCollision(ICollidable otherCollidable);
    }
}
