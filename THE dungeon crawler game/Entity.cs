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

        private int speed;
        public int Speed { get => speed;}
        public Vector2 direction;
        

        
        
        /// <summary>
        /// Default constructor for Entity
        /// </summary>
        /// <param name="spriteName"></param>
        public Entity(int speed, string spriteName):this(new Vector2(new Random().Next(GameWorld.ScreenSize.Width), new Random().Next(GameWorld.ScreenSize.Height)), spriteName, speed)
        {

        }

        /// <summary>
        /// Concstructor with position and animation
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="spriteName"></param>

        public Entity(Vector2 startPosition, string spriteName, int speed) : base()
        {
            this.speed = speed;
            position = startPosition;

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

        virtual public void Move()
        {

        }

        

    }
}
