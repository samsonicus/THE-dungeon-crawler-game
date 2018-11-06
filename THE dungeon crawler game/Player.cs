using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Player : Entity
    {

        private const float moveSpeed = 100;
        private int health;

        public Player(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) : 
            base(frameCount, animationFPS, starPosition, spriteName, speed, direction)

        {
        }

        public int Health
        {
            get { return health; }
        }

        
      
        public override void DoCollision(GameObject otherObject)
        {
            
            if (otherObject is Projectile || otherObject is Enemy)
            {
                health--;
            }
        }

    }
}
