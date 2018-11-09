using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Projectile : Entity
    {
        private const int movementSpeed = 100;
        private Entity owner;
        private int damage;
        /// <summary>
        /// Default constructor for projectile.
        /// </summary>
        /// <param name="frameCount">Sets the framecount</param>
        /// <param name="animationFPS">How often should the animation be played</param>
        /// <param name="startPosition">Starting position of the projectile</param>
        /// <param name="spriteName">Name of sprite</param>
        /// <param name="speed">Speed is set to movementSpeed, which is a constant.</param>
        /// <param name="direction">Direction of projectile</param>
        /// <param name="damage">Sets the damage of the projectile</param>
        public Projectile(int frameCountWidth, int framecountHeight, float animationFPS, Vector2 startPosition, string spriteName, int speed, Vector2 direction, int damage, Entity owner) :
            base(frameCountWidth, framecountHeight, animationFPS, startPosition, spriteName, speed, direction)
        {
            this.damage = damage;
            this.owner = owner;
            speed = movementSpeed;
            this.direction.Normalize(); //normalizes the path of the projectile
        }

        private void DealDamage(GameObject target)
        {
            if (target is ICombatEntity)
            {
                
            }
        }
                                                                                    
        public override void DoCollision(GameObject target)
        {
            if (target.Equals(owner))
            {
                return;
            }

            if (target is ICombatEntity) 
            {
                DealDamage(target);
            }
           

            if (!GameWorld.ScreenSize.Intersects(CollisionBox))
            {
                GameWorld.RemoveGameObject(this);
            }
        }

        /// <summary>
        /// Update function that removes the bullet if it hits a wall. 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position += direction * (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            if (!GameWorld.ScreenSize.Intersects(CollisionBox))
            {
                GameWorld.RemoveGameObject(this);
            }

            
        }

    }

}
