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
        private Vector2 eDirection;

        public int Health { get => health; }

        public Enemy(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, int speed, Vector2 direction) : 
            base(frameCount, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.eDirection = direction;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            


        }



    }
}
