using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Class for a simple projectile
    /// </summary>
    class SimpleProjectile : Projectile
    {
        /// <summary>
        /// Constructor for the SimpleProjectile
        /// </summary>
        /// <param name="startPosition">Start position of the object</param>
        /// <param name="direction">The direction that the Projectile is moving</param>
        /// <param name="damage">How much damage the Projectile will do</param>
        /// <param name="owner">Who shot the Projectile</param>
        public SimpleProjectile(Vector2 startPosition, Vector2 direction, Entity owner, int damage) :
     base(3, 3, startPosition, "bullet1", 200, direction, damage, owner)

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
