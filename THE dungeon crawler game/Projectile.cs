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

        public Projectile(int speed, Vector2 direction, int frameCount, int animationFPS, Vector2 startPosition, string spriteName) : base(speed, direction, frameCount, animationFPS, startPosition, spriteName)
        {
        }


        /// <summary>
        /// Constructor for a projectile
        /// </summary>
        /// <param name="direction">Direction gets normalized so it follows a one direction vector</param>
        /// <param name="startPosition">Start position will be set to be from the player or enemys position</param>


        /// <summary>
        /// Update function that removes the bullet if it hits a wall. 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position += Direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            if (!GameWorld.ScreenSize.Intersects(CollisionBox))
            {
                GameWorld.RemoveGameObject(this);
            }
        }


    }

}
