using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    internal class Entity : GameObject
    {

        private float speed;
        public float Speed { get => speed;}
        public Vector2 direction;

        /// <summary>
        /// Default constructor for Entity, without animation
        /// </summary>
        /// <param name="spriteName"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="direction"></param>
        public Entity(string spriteName, Vector2 position, float speed, Vector2 direction) : base(spriteName, position)
        {
            this.speed = speed;
            this.direction = direction;

        }

        /// <summary>
        /// Constructor for entity with animations.
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="starPosition"></param>
        /// <param name="spriteName"></param>
        /// <param name="speed"></param>
        /// <param name="direction"></param>
        public Entity(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) : 
        base(frameCount, animationFPS, starPosition, spriteName)
        {
            this.speed = speed;
            this.direction = direction;

        }      

        protected virtual void Die()
        {
           
        }
    }
}
