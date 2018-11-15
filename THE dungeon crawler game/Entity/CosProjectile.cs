using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Projectile following a cosinus wave
    /// </summary>
    class CosProjectile : Projectile
    {
        float elapsed = 0;

        /// <summary>
        /// Constructor for the CosProjectile
        /// </summary>
        /// <param name="frameCount">Frames in the sprite used</param>
        /// <param name="animationFPS">Frames in the animation</param>
        /// <param name="startPosition">Start position of the object</param>
        /// <param name="spriteName">Name of the sprite used</param>
        /// <param name="speed">The speed of the projectile</param>
        /// <param name="direction">The direction that the Projectile is moving</param>
        /// <param name="damage">How much damage the Projectile will do</param>
        /// <param name="owner">Who shot the Projectile</param>
        public CosProjectile(int frameCount, float animationFPS, Vector2 startPosition, string spriteName, int speed, Vector2 direction, int damage, Entity owner) : base(frameCount, animationFPS, startPosition, spriteName, speed, direction, damage, owner)
        {

        }


        /// <summary>
        /// Updated Update method for the CosProjectile
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            double t = gameTime.ElapsedGameTime.TotalSeconds;
            elapsed += (float)t;
            float angle = (float)Math.Atan2((double)eDirection.Y, (double)eDirection.X);
            Vector2 john = new Vector2(0, (float)Math.Cos(elapsed * 10) * 4) * 50;
            john = Vector2.Transform(john, Matrix.CreateRotationZ(angle));
            position += (john + (Speed * eDirection)) * (float)t;
            
        }
    }
}
