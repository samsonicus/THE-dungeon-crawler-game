using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THE_dungeon_crawler_game
{
    class Projectile : Entity, ICollidable
    {

        private Entity owner;
        private int damage;

        /// <summary>
        /// Default constructor for projectile.
        /// </summary>
        /// <param name="frameCount">Sets the framecount</param>
        /// <param name="animationFPS">How often should the animation be played</param>
        /// <param name="startPosition">Starting position of the projectile</param>
        /// <param name="spriteName">Name of sprite</param>
        /// <param name="speed">Speed is....speed ;D </param>
        /// <param name="direction">Direction of projectile</param>
        /// <param name="damage">Sets the damage of the projectile</param>
        public Projectile(int frameCountWidth, float animationFPS, Vector2 startPosition, string spriteName, int speed, Vector2 direction, int damage, Entity owner) :
            base(frameCountWidth, animationFPS, startPosition, spriteName, speed, direction)
        {
            this.damage = damage;
            this.owner = owner;
            this.speed = speed;
            this.eDirection.Normalize(); //normalizes the path of the projectile
        }

        /// <summary>
        /// Projectile constructor with a spritesheet.
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
            this.eDirection.Normalize(); //normalizes the path of the projectile
        }

        private void DealDamage(GameObject target)
        {
            if (target is ICombatEntity)
            {

            }
        }


        public Vector2 AdjustedPosition
        {
            get {
                var pos = position;
                var rect = animationRectanglesSheet[0, currentAnimationIndex];
                pos -= new Vector2(rect.Width / 2, rect.Height / 2);
                return pos;
            }
        }

        /// <summary>
        /// Update function that removes the bullet if it hits a wall. 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            if (!GameWorld.ScreenSize.Intersects(CollisionBox))
            {
                GameWorld.RemoveGameObject(this);
            }

        }
        public bool IsColliding(ICollidable otherCollidable)
        {

            return otherCollidable.CollisionBox.Intersects(this.CollisionBox);

        }

        public void DoCollision(ICollidable otherCollidable)
        {
            if (otherCollidable is Enemy || otherCollidable is ObstacleTile)
            {
                GameWorld.RemoveGameObject(this);
            }
        }

        public Rectangle CollisionBox
        {
            get
            {
                var rect = animationRectanglesSheet[0, currentAnimationIndex];
                return new Rectangle((int)AdjustedPosition.X, (int)AdjustedPosition.Y, rect.Width,
                    rect.Height);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            var rect = animationRectanglesSheet[0, currentAnimationIndex];

            spriteBatch.Draw(sprite, AdjustedPosition, rect, Color.White);
        }
    }

}
