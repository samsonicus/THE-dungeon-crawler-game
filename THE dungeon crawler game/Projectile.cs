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

        public Projectile(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) :
            base(frameCount, animationFPS, starPosition, spriteName, speed, direction)
        {

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
