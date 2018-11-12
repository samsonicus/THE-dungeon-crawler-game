using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    public abstract class GameObject
    {
        protected Texture2D sprite;
        private float animationFPS;
        protected float rotation;
        protected Vector2 position = new Vector2(32,0);
        public Vector2 Position { get => position; }
        protected PlayerDirection ePlayerDirection = PlayerDirection.down;
        
        
        protected double timeElapsed = 0;

        private Vector2 zero;
        private string spriteName;
        private float baseAnimationFPS;
        protected Rectangle[,] animationRectanglesSheet;
        protected Rectangle[] animationRectangles;
        //double timeElapsed = 0;
        protected int currentAnimationIndex = 0;
        

        #region collision
       
        /// <summary>
        /// CollisionBox for the Gameobject. Height and Width are based on the height and width of the sprite used. X and Y coordinates are based on the height and width of the sprite aswell.
        /// </summary>
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - sprite.Width * 0.5), (int)(position.Y - sprite.Height * 0.5), sprite.Width, sprite.Height);
            }
            
        }

        /// <summary>
        /// IsColliding checks wether a GameObject is colliding with another GameObject (here otherObject) 
        /// </summary>
        /// <param name="otherObject">The object that is tested agaisnt</param>
        /// <returns>If the objects are colliding, return true, else return felse.</returns>
        public bool IsColliding(GameObject otherObject)
        {
            return CollisionBox.Intersects(otherObject.CollisionBox);
        }

        public virtual void DoCollision(GameObject gameObject)
        {

        }

        #endregion

        /// <summary>
        /// The default constructor for a gameobject with name and position.
        /// </summary>
        /// <param name="spriteName">The name of the sprite used for the GameObject</param>
        /// <param name="position">Determines the position of the sprite</param>
        public GameObject(string spriteName, Vector2 position)
        {
            this.animationFPS = baseAnimationFPS;
            this.position = position;
            this.spriteName = spriteName;
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);

        }

        /// <summary>
        /// The constructor for a GameObject with animations. 
        /// </summary>
        /// <param name="startPosition">The start position for the GameObject</param>
        /// <param name="content">A referance for the ContentManager for loadingresources</param>
        /// <param name="spriteName">The name of the texture used for the GameObject</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(int frameCountWidth, float animationFPS, Vector2 startPosition, string spriteName) : this(spriteName, startPosition)
        {
            position = startPosition;
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCountWidth];
            int goDirection = (int)ePlayerDirection;

            for (int i = 0; i < frameCountWidth; i++)
            {
                animationRectanglesSheet[1, i] = new Rectangle((i * sprite.Width / frameCountWidth),0, (sprite.Width / frameCountWidth), sprite.Height);
            }

        }

        /// <summary>
        /// The constructor for a GameObject with animations and a spritesheet. 
        /// </summary>
        /// <param name="startPosition">The start position for the GameObject</param>
        /// <param name="content">A referance for the ContentManager for loadingresources</param>
        /// <param name="spriteName">The name of the texture used for the GameObject</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(int frameCountWidth,int frameCountHeight ,float animationFPS, Vector2 startPosition, string spriteName) : this(spriteName, startPosition)
        {
            position = startPosition;
            this.animationFPS = animationFPS;
            animationRectanglesSheet = new Rectangle[frameCountWidth,frameCountHeight];
            int goDirection = (int)ePlayerDirection;

            for (int i = 0; i < frameCountWidth; i++)
            {
                animationRectanglesSheet[1, i] = new Rectangle((i * sprite.Width / frameCountWidth), (goDirection * sprite.Height / frameCountHeight), (sprite.Width / frameCountWidth), (sprite.Height / frameCountHeight));
            }

        }

        public virtual void Update(GameTime gameTime) { 
        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
        currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectanglesSheet.GetLength(1)-1)
            {
                timeElapsed = 0;
                currentAnimationIndex = 0;
            }

        }

        /// <summary>
        /// Standart draw function for game objects. Simply draws the sprite given to it.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for the drawing</param>
        /// <param name="gameTime"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
             spriteBatch.Draw(sprite, position, animationRectanglesSheet[1,currentAnimationIndex], Color.White);

        }
    }
}
