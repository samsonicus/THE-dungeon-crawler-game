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
        public SimpleProjectile(Vector2 startPosition, Vector2 direction, Entity owner, int damage) : 
            base(3, 3, startPosition, "bullet1", 200, direction, damage, owner)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position += (eDirection * Speed) * (float)(gameTime.ElapsedGameTime.TotalSeconds);

        }

    }
}
