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
        protected float attackRange;
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

        /// <summary>
        /// Contructor for Enemy without animation
        /// </summary>
        /// <param name="health">Enemy start health</param>
        /// <param name="attackRange">The range at which the enemy can attack</param>
        /// <param name="spriteName">The name of the sprite</param>
        /// <param name="position">the position at which the enemy starts at</param>
        /// <param name="speed">The speed at which the enemy can move</param>
        /// <param name="direction">The direction the enemy starts pointing</param>
        public Enemy(int health,float attackRange,string spriteName, Vector2 position, float speed, Vector2 direction) : base(spriteName, position, speed, direction)
        {
            this.health = health;
            this.attackRange = attackRange;
        }

        /// <summary>
        /// Constructor for Enemy with animation
        /// </summary>
        /// <param name="health">Enemy start health</param>
        /// <param name="attackRange">The range at which the enemy can attack</param>
        /// <param name="frameCount">The amount of frames in the animation</param>
        /// <param name="animationFPS">The amount of frames to be shown in a second</param>
        /// <param name="starPosition">the position at which the enemy starts at</param>
        /// <param name="spriteName">The name of the sprite</param>
        /// <param name="speed">The speed at which the enemy can move</param>
        /// <param name="direction">The direction the enemy starts pointing</param>
        public Enemy(int health,float attackRange, int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) : base(frameCount, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.health = health;
            this.attackRange = attackRange;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Simpel AI that calcualtes and performs the actions of the enemy
        /// </summary>
        protected virtual void SimpleAI(GameTime gameTime)
        {

            Move(gameTime);
        }

        /// <summary>
        /// Sets the direction to point at player
        /// </summary>
        /// <param name="playerPos"></param>
        protected void LookAtPlayer(Vector2 playerPos)
        {
            direction = playerPos - position;
            direction.Normalize();
        }
        
        /// <summary>
        /// Calculates the distance between the enemy and the player
        /// </summary>
        /// <param name="playerPos">The position of the player</param>
        /// <returns>Returns the distance between the player and the enemy</returns>
        protected float DistToPlayer(Vector2 playerPos)
        {
            Vector2 temp = playerPos - position;
            return temp.Length();
        }


        protected void Move(GameTime gameTime)
        {
            position += direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Does the attack of the enemy - TODO
        /// </summary>
        public virtual void Attack()
        {
            //TODO
        }

        /// <summary>
        /// Gains the enemy life
        /// </summary>
        /// <param name="lifeGained">The amount of life the enemy gains</param>
        public virtual void GainHealth(int lifeGained)
        {
            Health += lifeGained;
        }

        /// <summary>
        /// Loses the enemy life
        /// </summary>
        /// <param name="lifeLost">The amount of life the enemy loses</param>
        public virtual void LoseHealth(int lifeLost)
        {
            Health -= lifeLost;
        }

        protected override void Die()
        {
            GameWorld.RemoveGameObject(this);
        }
    }
}
