﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Entity : GameObject
    {

        private int speed;
        public int Speed { get => speed;}
        public Vector2 direction;
        #region Constructors    
        /// <summary>
        /// Default constructor for Entity, without animation
        /// </summary>
        /// <param name="spriteName"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="direction"></param>
        public Entity(string spriteName, Vector2 position, int speed, Vector2 direction) : base(spriteName, position)
        {
            this.direction = direction;
            this.direction.Normalize();
            this.speed = speed;
            
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
        public Entity(int frameCount, float animationFPS, Vector2 starPosition, string spriteName, int speed, Vector2 direction) : 
            base(frameCount, animationFPS, starPosition, spriteName)
        {
            this.speed = speed;
            this.direction = direction;

        }
        #endregion  
        /// <summary>
        /// Enables the Entity to have defined game logic.
        /// </summary>
        /// <param name="gameTime">Amount of time elapsed since last Update()</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        virtual protected void Die()
        {

        }





    }
}