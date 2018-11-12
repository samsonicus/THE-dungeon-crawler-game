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
    class Player : Entity, ICollidable
    {
        private const int playerSpeed = 100;
        private const float rotationSpeed = MathHelper.Pi;
        private Vector2 pDirection = new Vector2(0, 0);
        public Vector2 playerDirection
        {
            get { return eDirection; }
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
        public Player(int moveSpeed, Vector2 pDirection, int frameCountWidth, int frameCountHeight, int animationFPS, Vector2 startPosition, string spriteName) : 
            base(frameCountWidth, frameCountHeight,animationFPS,startPosition,spriteName,moveSpeed,pDirection)
        {
            health = 100;
            moveSpeed = playerSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            #region movement
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
            #endregion

            pDirection = new Vector2((float)Math.Cos(rotation - MathHelper.Pi * 0.5f), (float)Math.Sin(rotation - MathHelper.Pi * 0.5f));
            //position += direction * (float)(playerSpeed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;

            lastShot += gameTime.ElapsedGameTime.TotalSeconds;

            Point currentMousePosition = Mouse.GetState().Position;
            Vector2 mouseDirection = new Vector2(currentMousePosition.X - position.X, currentMousePosition.Y - position.Y);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && lastShot > 0.3f)
            {
                
                GameWorld.AddGameObject(new SimpleProjectile(3, 3, position, "bullet1", 100, mouseDirection, 10, this));
                lastShot = 0;
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed && lastShot > 0.3f)
            {

                
                GameWorld.AddGameObject(new SinProjectile(3, 3, position, "bullet1", 100, mouseDirection, 10, this));
                GameWorld.AddGameObject(new CosProjectile(3, 3, position, "bullet1", 100, mouseDirection, 10, this));
                lastShot = 0;
                
            }

        }



        public void DoCollision(ICollidable otherCollidable)
        {
            if (otherCollidable is Projectile || otherCollidable is Enemy)
            {
                health--;
            }
        }

        public bool IsColliding(ICollidable otherCollidable)
        {
            return otherCollidable.CollisionBox.Intersects(this.CollisionBox);
        }

        public Rectangle CurrentAnimationRectangle { get => animationRectanglesSheet[(int)ePlayerDirection, currentAnimationIndex]; }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, CurrentAnimationRectangle.Width, CurrentAnimationRectangle.Height);

                //return new Rectangle((int)(position.X - sprite.Width - animationRectangles[currentAnimationIndex].Width * 0.5),
                //  (int)(position.Y - sprite.Height - animationRectangles[currentAnimationIndex].Height * 0.5),
                //animationRectangles[currentAnimationIndex].Width, animationRectangles[currentAnimationIndex].Height);
            }
        }

        

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(sprite, position, CurrentAnimationRectangle, Color.White);
        }
    }
}
