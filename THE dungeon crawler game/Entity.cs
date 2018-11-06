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

        public Entity(string spriteName, Vector2 position, float speed, Vector2 direction) : base(spriteName, position)
        {
            this.speed = speed;
            this.direction = direction;

        }

        public Entity(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, float speed, Vector2 direction) : 
            base(frameCount, animationFPS, starPosition, spriteName)
        {
            this.speed = speed;
            this.direction = direction;

        }


        /// <summary>
        /// Enables the Entity to have defined game logic.
        /// </summary>
        /// <param name="gameTime">Amount of time elapsed since last Update()</param>
        public override void Update(GameTime gameTime)
        {
            position += speed * direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }


        virtual protected void Die()
        {
           
        }

      

        

    }
}
