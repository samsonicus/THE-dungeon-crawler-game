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
        /// <summary>
        /// Constructor for ObstacleTile
        /// </summary>
        /// <param name="starPosition">The start position of the ObstacleTile</param>
        /// <param name="spriteName">Name of the sprite for drawing the tile</param>
        public ObstacleTile (Vector2 starPosition, string spriteName) : base(starPosition, spriteName)
        {

        }

        /// <summary>
        /// Collision for the Tile
        /// </summary>
        /// <param name="otherCollidable">The other ICollidable object</param>
        public void DoCollision(ICollidable otherCollidable)
        {
            //TODO - Finalize collision handling
        }

        /// <summary>
        /// Checks if the ObstecleTile is colliding with another ICollidable object
        /// </summary>
        /// <param name="otherCollidable">The other ICollidable object</param>
        /// <returns></returns>
        public bool IsColliding(ICollidable otherCollidable)
        {
            return CollisionBox.Intersects(otherCollidable.CollisionBox);
        }

        /// <summary>
        /// The collision box of the ObstacleTile
        /// </summary>
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 32, 32);
            }
        }
    }
}
