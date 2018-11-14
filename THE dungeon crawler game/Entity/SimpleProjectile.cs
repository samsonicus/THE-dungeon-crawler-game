using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class SimpleProjectile : Projectile
    {
        /// <summary>
        /// Constructor for the SimpleProjectile
        /// </summary>
        /// <param name="frameCount">Frames in the sprite used</param>
        /// <param name="animationFPS">Frames in the animation</param>
        /// <param name="startPosition">Start position of the object</param>
        /// <param name="spriteName">Name of the sprite used</param>
        /// <param name="speed">The speed of the projectile</param>
        /// <param name="direction">The direction that the Projectile is moving</param>
        /// <param name="damage">How much damage the Projectile will do</param>
        /// <param name="owner">Who shot the Projectile</param>
        public SimpleProjectile(int frameCount, float animationFPS, Vector2 startPosition, string spriteName, int speed, Vector2 direction, int damage, Entity owner) : 
            base(frameCount, animationFPS, startPosition, spriteName, speed, direction, damage, owner)
        {

        }

        /// <summary>
        /// Updated Update Method for the SimpleProjectile
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position += (eDirection * Speed) * (float)(gameTime.ElapsedGameTime.TotalSeconds);

        }

    }
}
