using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class CosProjectile : Projectile
    {
        float elapsed = 0;

        public CosProjectile(int frameCount, float animationFPS, Vector2 startPosition, string spriteName, int speed, Vector2 direction, int damage, Entity owner) : base(frameCount, animationFPS, startPosition, spriteName, speed, direction, damage, owner)
        {


        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            double t = gameTime.ElapsedGameTime.TotalSeconds;
            elapsed += (float)t;
            float angle = eDirection.Y / eDirection.X;
            Vector2 john = new Vector2(0, (float)Math.Cos(elapsed * 10) * 4) * 50;
            position += (john + (Speed * eDirection)) * (float)t;

        }
    }
}
