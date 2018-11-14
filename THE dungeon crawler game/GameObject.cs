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
        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }
        protected PlayerDirection ePlayerDirection = PlayerDirection.down;
        
        
        protected double timeElapsed = 0;

        
        private string spriteName;
        private float baseAnimationFPS;
        protected Rectangle[,] animationRectanglesSheet;
        
        //double timeElapsed = 0;
        protected int currentAnimationIndex = 0;
        

 
        
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
            
            this.animationFPS = 1;
            animationRectanglesSheet = new Rectangle[1, 1];
            int goDirection = (int)ePlayerDirection;

          
            
            animationRectanglesSheet[0, 0] = new Rectangle(0,0,sprite.Width, sprite.Height);
            

        }

        /// <summary>
        /// The constructor for a GameObject with animations. 
        /// </summary>
        /// <param name="startPosition">The start position for the GameObject</param>
        /// <param name="spriteName">The name of the texture used for the GameObject</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(int frameCountWidth, float animationFPS, Vector2 startPosition, string spriteName) : this(spriteName, startPosition)
        {
            position = startPosition;
            this.animationFPS = animationFPS;
            animationRectanglesSheet = new Rectangle[1, frameCountWidth];
            int goDirection = (int)ePlayerDirection;

            for (int i = 0; i < frameCountWidth; i++)
            {
                animationRectanglesSheet[0, i] = new Rectangle((i * sprite.Width / frameCountWidth),0, (sprite.Width / frameCountWidth), sprite.Height);
            }

        }

        /// <summary>
        /// The constructor for a GameObject with animations and a spritesheet. 
        /// </summary>
        /// <param name="startPosition">The start position for the GameObject</param>
        /// <param name="spriteName">The name of the texture used for the GameObject</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(int frameCountWidth,int frameCountHeight ,float animationFPS, Vector2 startPosition, string spriteName) : this(spriteName, startPosition)
        {
            position = startPosition;
            this.animationFPS = animationFPS;
            animationRectanglesSheet = new Rectangle[frameCountWidth,frameCountHeight];
            int goDirection = (int)ePlayerDirection;
            int width = sprite.Width / frameCountWidth;
            int height = sprite.Height / frameCountHeight;


            for (int i = 0; i < frameCountHeight; i++)
            {
                for (int j = 0; j < frameCountWidth; j++)
                {
                    animationRectanglesSheet[i, j] = new Rectangle(j * width, i * height, width, height);
                }
            }

        }

        /// <summary>
        /// Updated Update method for GameObject
        /// </summary>
        public virtual void Update(GameTime gameTime) {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectanglesSheet.GetLength(0)-1)
            {
                timeElapsed = 0;
                currentAnimationIndex = 0;
            }

        }

        /// <summary>
        /// Standart draw function for game objects. Simply draws the sprite given to it.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for the drawing</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, animationRectanglesSheet[0,currentAnimationIndex], Color.White);
        }
    }
}
