﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace THE_dungeon_crawler_game
{
    class Player : Entity
    {

        private const int playerSpeed = 100;
        private const float rotationSpeed = MathHelper.Pi;
        private Vector2 direction = new Vector2(0, 0);       
        private double lastShot = 0;

        private int health;
        public int Health
        {
            get { return health; }
        }

        /// <summary>
        /// The player constuctor
        /// </summary>
        /// <param name="speed">Speed of the player</param>
        /// <param name="direction">The direction the player is moving in</param>
        /// <param name="frameCount">The frame that the animation is curentley on(?)</param>
        /// <param name="animationFPS">The amount of frames needed for the animation</param>
        /// <param name="startPosition">The starting position for the player ovject</param>
        /// <param name="spriteName">the name of the sprite used for the player</param>
        public Player(int moveSpeed, Vector2 direction, int frameCount, int animationFPS, Vector2 startPosition, string spriteName) 
            : base(moveSpeed, direction, frameCount, animationFPS, startPosition, spriteName)
        {
            health = 100;
            moveSpeed = playerSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation += (float)(rotationSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation -= (float)(rotationSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }


            direction = new Vector2((float)Math.Cos(rotation - MathHelper.Pi * 0.5f), (float)Math.Sin(rotation - MathHelper.Pi * 0.5f));
            position += direction * (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;



            base.Update(gameTime);
        }



        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Projectile || otherObject is Enemy)
            {
                health--;
            }
        }

    }
}
