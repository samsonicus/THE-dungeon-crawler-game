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
    public class Player : Entity, ICollidable, ICombatEntity
    {
       
        private const float rotationSpeed = MathHelper.Pi;
        private Vector2 pDirection = new Vector2(0, 0);
        //This is the list of active powerups.
        public List<PowerUp> activePowerups = new List<PowerUp>();
        public int damage = 1;

        public Vector2 playerDirection
        {
            get { return eDirection; }
        }

        /// <summary>
        /// Applies a powerup to the player.
        /// Adds it to the activePowerUp list, and removes it from the GameWorld so it is no longer rendered.
        /// </summary>
        /// <param name="powerup">The powerup that is walked over</param>
        public void AddPowerUp(PowerUp powerup)
        {
            
            GameWorld.RemoveGameObject((GameObject)powerup);
            if (powerup.ApplyPowerup(this))
            {
                activePowerups.Add(powerup);
            }
            
        }


        private double lastShot = 0;

        private int health;
        public int Health
        {
            get { return health; }
        }

        /// <summary>
        /// The standart player constuctor
        /// </summary>
        /// <param name="speed">Speed of the player</param>
        /// <param name="direction">The direction the player is moving in</param>
        /// <param name="frameCount">The frame that the animation is curentley on(?)</param>
        /// <param name="animationFPS">The amount of frames needed for the animation</param>
        /// <param name="startPosition">The starting position for the player ovject</param>
        /// <param name="spriteName">the name of the sprite used for the player</param>
        public Player(int moveSpeed, Vector2 pDirection, int frameCountWidth, int frameCountHeight, int animationFPS, Vector2 startPosition, string spriteName) :
            base(frameCountWidth, frameCountHeight, animationFPS, startPosition, spriteName, moveSpeed, pDirection)
        {
            health = 10;
        }

        /// <summary>
        /// Updated Update for the player class
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            #region movement
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
                ePlayerDirection = PlayerDirection.left;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
                ePlayerDirection = PlayerDirection.right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
                ePlayerDirection = PlayerDirection.up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds) * GameWorld.updateSpeed;
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
            Vector2 mouseDirection = new Vector2(currentMousePosition.X - position.X - GameWorld.CameraPosition.X, currentMousePosition.Y - position.Y - GameWorld.CameraPosition.Y);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && lastShot > 0.2f)
            {

                GameWorld.AddGameObject(new SimpleProjectile(position + new Vector2(16), mouseDirection, this, this.damage));
                lastShot = 0;
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed && lastShot > 0.8f)
            {


                GameWorld.AddGameObject(new SinProjectile(3, 3, position + new Vector2(16), "bullet1", 100, mouseDirection, this.damage, this));
                GameWorld.AddGameObject(new CosProjectile(3, 3, position + new Vector2(16), "bullet1", 100, mouseDirection, this.damage, this));
                lastShot = 0;

            }


            //Update duration of all active powerups and collect the ones that are expired in a list.
            //and then remove all the expired ones from the active list.
            List<PowerUp> removePowerupList = new List<PowerUp>();
            foreach (PowerUp powerUp in activePowerups)
            {
                powerUp.duration -= gameTime.ElapsedGameTime.TotalSeconds;
                if (powerUp.duration <= 0)
                {
                    removePowerupList.Add(powerUp);
                    powerUp.RemovePowerup(this);
                }

            }

            foreach (PowerUp powerUp in removePowerupList)
            {
                activePowerups.Remove(powerUp);
            }
        }

        /// <summary>
        /// When colliding, makes you loose HP if the other object is an Enemy 
        /// </summary>
        /// <param name="otherCollidable">Another GameObject that is collidable</param>
        public void DoCollision(ICollidable otherCollidable)
        {
            if (otherCollidable is Enemy)
            {
                health--;
            }
        }

        /// <summary>
        /// checks if two objects are colliding
        /// </summary>
        /// <param name="otherCollidable">Another colliadable object (Has to have ICollidable)</param>
        /// <returns>Returns true if two ICollidable objects are colliding, and false if they are not</returns>
        public bool IsColliding(ICollidable otherCollidable)
        {
            return otherCollidable.CollisionBox.Intersects(this.CollisionBox);
        }

        public Rectangle CurrentAnimationRectangle { get => animationRectanglesSheet[(int)ePlayerDirection, currentAnimationIndex]; }

        /// <summary>
        /// Returns a new rectangle
        /// </summary>
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

        /// <summary>
        /// Updated Draw method for the player class
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, CurrentAnimationRectangle, Color.White);
        }

        /// <summary>
        /// Method for gaining life
        /// </summary>
        /// <param name="lifeGained">How much life is gained</param>
        public void GainHealth(int lifeGained)
        {
            this.health += lifeGained;
        }

        /// <summary>
        /// Method for losing life
        /// </summary>
        /// <param name="lifeLost">How much life is lost</param>
        public void LoseHealth(int lifeLost)
        {
            this.health -= lifeLost;
        }

        /// <summary>
        /// Attack function is found in the updated Update method
        /// </summary>
        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
