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

        /// <summary>
        /// Enemy constructor with a sprite sheet
        /// </summary>
        /// <param name="frameCountWidth">number of diferent poses in the animation</param>
        /// <param name="frameCountHeight">Vertical changes (going up/down/left/right, having taken more or less dmg)</param>
        /// <param name="animationFPS">The amount of frames in the animation</param>
        /// <param name="starPosition">The start position of the enemy</param>
        /// <param name="spriteName">the name of the sprite used</param>
        /// <param name="speed">The enemies speed</param>
        /// <param name="direction">The direction the enemy is facing</param>
        public Enemy(int frameCountWidth,int frameCountHeight, float animationFPS, Vector2 starPosition, string spriteName, int speed, Vector2 direction) : 
            base(frameCountWidth, frameCountHeight, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.eDirection = direction;
        }

        /// <summary>
        /// Enemy constructor with a sprite sheet
        /// </summary>
        /// <param name="frameCountWidth">number of diferent poses in the animation</param>
        /// <param name="animationFPS">The amount of frames in the animation</param>
        /// <param name="starPosition">The start position of the enemy</param>
        /// <param name="spriteName">the name of the sprite used</param>
        /// <param name="speed">The enemies speed</param>
        /// <param name="direction">The direction the enemy is facing</param>
        public Enemy(int frameCountWidth, float animationFPS, Vector2 starPosition, string spriteName, int speed, Vector2 direction) :
            base(frameCountWidth, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.eDirection = direction;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            


        }



    }
}
