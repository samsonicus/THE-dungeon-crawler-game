using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Enemy:Entity
    {
        private int health = 100;
        private Vector2 direction;

        public int Health { get => health; }

        public Enemy(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) : 
            base(frameCount, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.direction = direction;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            


        }



    }
}
