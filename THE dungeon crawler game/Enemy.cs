using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Enemy:Entity, ICombatEntity
    {
        private int health = 100;
        private Vector2 direction;
        private Vector2 startPosition;

        public int Health { get => health; }
        public void Attack()
        {
            
        }
        public void LoseHealth()
        {
            health--;
        }
        public void GainHealth()
        {
            health++;
        }

        public Enemy(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) : 
            base(frameCount, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.position = startPosition;
            this.direction = direction;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            


        }

        

    }
}
