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
        /// Default constructor for entity
        /// </summary>
        /// <param name="spriteName"></param>
        /// <param name="startPosition"></param>
        public Entity(string spriteName, Vector2 startPosition, float speed)
        {

        }


        /// <summary>
        /// Constructor for entity with animations
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="spriteName"></param>
        /// <param name="startPosition"></param>
        public Entity(int frameCount, float animationFPS, string spriteName, Vector2 startPosition):base(frameCount, animationFPS, startPosition, "tesrr")
        {

        }

      

        /// <summary>
        /// Enables the Entity to have defined game logic.
        /// </summary>
        /// <param name="gameTime">Amount of time elapsed since last Update()</param>
        public virtual void Update(GameTime gameTime)
        {

        }


        virtual protected void Die()
        {
           
        }

      

        

    }
}
