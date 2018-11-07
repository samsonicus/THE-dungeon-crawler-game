using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    internal class Entity : AnimatedGameObject
    {

        private int speed;
        public int Speed { get => speed; }
        private Vector2 direction;
        public Vector2 Direction { get => direction; }

        public Entity(int speed, Vector2 direction, int frameCount, int animationFPS, Vector2 startPosition, string spriteName) : 
            base(frameCount, animationFPS, startPosition, spriteName)
        {
            this.direction = direction;
            this.direction.Normalize();
            this.speed = speed;
            
        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
           
            position += speed * direction * (float)gameTime.ElapsedGameTime.TotalSeconds;





        }


        virtual protected void Die()
        {

        }





    }
}
