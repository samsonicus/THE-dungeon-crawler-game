using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Projectile : Entity
    {
        private const float movementSpeed = 200;


        /// <summary>
        /// Constructor for a projectile
        /// </summary>
        /// <param name="direction">Direction gets normalized so it follows a one direction vector</param>
        /// <param name="startPosition">Start position will be set to be from the player or enemys position</param>
        public Projectile(Vector2 direction, Vector2 startPosition) : base("projectile", direction)
        {
            this.direction = direction;
            this.direction.Normalize();
        }

        /// <summary>
        /// Update function that removes the bullet if it hits a wall. 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            if (!GameWorld.ScreenSize.Intersects(CollisionBox))
            {
                GameWorld.RemoveGameObject(this);
            }
        }


    }

}
