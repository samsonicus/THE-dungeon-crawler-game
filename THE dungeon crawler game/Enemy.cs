using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Enemy : Entity, ICombatEntity
    {
        protected int health;        
        public int Health
        {
            get
            {
                return health;
            }
            protected set
            {
                if(value < 0)
                {
                    health = 0;
                    Die();
                    return;
                }
                health = value;
            }
        }

        public Enemy(int health,string spriteName, Vector2 position, float speed, Vector2 direction) : base(spriteName, position, speed, direction)
        {
            this.health = health;
        }

        public Enemy(int health, int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) : base(frameCount, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.health = health;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Sets the direction to point at player
        /// </summary>
        /// <param name="playerPos"></param>
        private void LookAtPlayer(Vector2 playerPos)
        {
            direction = playerPos - position;
            direction.Normalize();
        }

        /// <summary>
        /// Does the attack of the enemy
        /// </summary>
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gains the enemy life
        /// </summary>
        /// <param name="lifeGained">The amount of life the enemy gains</param>
        public void GainHealth(int lifeGained)
        {
            Health += lifeGained;
        }

        /// <summary>
        /// Loses the enemy life
        /// </summary>
        /// <param name="lifeLost">The amount of life the enemy loses</param>
        public void LoseHealth(int lifeLost)
        {
            Health -= lifeLost;
        }
    }
}
