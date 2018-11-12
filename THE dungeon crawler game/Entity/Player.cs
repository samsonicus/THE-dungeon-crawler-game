using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace THE_dungeon_crawler_game
{
    public class Player : Entity, ICombatEntity
    {
        private const int playerSpeed = 100;
        private const float rotationSpeed = MathHelper.Pi;
        private Vector2 pDirection = new Vector2(0, 0);    
        public Vector2 PlayerDirection
        {
            get { return direction; }
        }
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
        public Player(int moveSpeed, Vector2 pDirection, int frameCountWidth, int frameCountHeight, int animationFPS, Vector2 startPosition, string spriteName) : base(frameCountWidth, frameCountHeight,animationFPS,startPosition,spriteName,moveSpeed,pDirection)
        {
            health = 100;
            moveSpeed = playerSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
                ePlayerDirection = PlayerDirection.left;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
                ePlayerDirection = PlayerDirection.right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
                ePlayerDirection = PlayerDirection.up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
                ePlayerDirection = PlayerDirection.down;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation += (float)(rotationSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation -= (float)(rotationSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
            }


            pDirection = new Vector2((float)Math.Cos(rotation - MathHelper.Pi * 0.5f), (float)Math.Sin(rotation - MathHelper.Pi * 0.5f));
            //position += direction * (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;

                lastShot += gameTime.ElapsedGameTime.TotalSeconds;
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && lastShot > 0.3f)
            {
                GameWorld.AddGameObject(new Projectile(1,1, 1, position, "Player", 50, direction, 10, new Entity("Player2", position, 1, direction)));
                lastShot = 0;
                }


            base.Update(gameTime);
        }

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(sprite, position, animationRectangles[(int)ePlayerDirection, currentAnimationIndex], Color.White);
        //}


        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Projectile || otherObject is Enemy)
            {
                health--;
            }
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void GainHealth(int lifeGained)
        {
            //TODO;
        }

        public void LoseHealth(int lifeLost)
        {
            //TODO;
        }
    }
}
