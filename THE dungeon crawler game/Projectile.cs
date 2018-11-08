using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Projectile : Entity, ICollidable
    {
        private const float movementSpeed = 100;
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
        public Projectile(int frameCount, float animationFPS, Vector2 startPosition, string spriteName, float speed, Vector2 direction, int damage, Entity owner) :
            base(frameCount, animationFPS, startPosition, spriteName, speed, direction)
        {
            this.damage = damage;
            this.owner = owner;
            speed = movementSpeed;
            this.direction.Normalize(); //normalizes the path of the projectile
        }

        private void DealDamage(ICombatEntity target)
        {
            if (target is ICombatEntity)
            {
                
            }
        }
                                                                                    
        public void DoCollision(ICollidable target)
        {
            if (target.Equals(owner))
            {
                return;
            }

            if (target is Enemy) 
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
        
       /// <summary>
       /// CollisionBox for the Gameobject. Height and Width are based on the height and width of the sprite used. X and Y coordinates are based on the height and width of the sprite aswell.
       /// </summary>
       public virtual Rectangle CollisionBox
       {
           get
           {
              return new Rectangle((int)(position.X - sprite.Width- animationRectangles[0].Width * 0.5), (int)(position.Y - sprite.Height-animationRectangles[0 ].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
           }
       }

       /// <summary>
       /// IsColliding checks wether a GameObject is colliding with another GameObject (here otherObject) 
       /// </summary>
       /// <param name="otherObject">The object that is tested agaisnt</param>
       /// <returns>If the objects are colliding, return true, else return felse.</returns>
       public bool IsColliding(ICollidable otherObject)
       {
           return CollisionBox.Intersects(otherObject.CollisionBox);
       }
       

    }

}
