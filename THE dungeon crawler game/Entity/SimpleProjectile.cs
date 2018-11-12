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
        public SimpleProjectile(int frameCount, float animationFPS, Vector2 startPosition, string spriteName, int speed, Vector2 direction, int damage, Entity owner) : 
            base(frameCount, animationFPS, startPosition, spriteName, speed, direction, damage, owner)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position += (eDirection * Speed) * (float)(gameTime.ElapsedGameTime.TotalSeconds);

        }

    }
}
