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
    public class GameObject
    {
        protected Texture2D sprite;
        protected Vector2 position;
        protected float rotation;
        public Vector2 Position { get => position; }
        public List<GameObject> gameObjects;
        protected Rectangle[] animationRectangles;

        private int baseFrameCount = 1;
        private float baseAnimationFPS = 1;

        float animationFPS = 10;
        int currentAnimationIndex = 0;
        double timeElapsed = 0;

        protected ContentManager content;
        private Vector2 zero;
        private string spriteName;


        #region collision
        /// <summary>
        /// CollisionBox for the Gameobject. Height and Width are based on the height and width of the sprite used. X and Y coordinates are based on the height and width of the sprite aswell.
        /// </summary>
        public virtual Rectangle CollisionBox
        {
            get
            {
               return new Rectangle((int)(position.X - sprite.Width- animationRectangles[0].Width * 0.5), (int)(position.Y - sprite.Height-animationRectangles[0 ].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
            }
        }

        /// <summary>
        /// IsColliding checks wether a GameObject is colliding with another GameObject (here otherObject) 
        /// </summary>
        /// <param name="otherObject">The object that is tested agaisnt</param>
        /// <returns>If the objects are colliding, return true, else return felse.</returns>
        public bool isColliding(GameObject otherObject)
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
        public GameObject(int frameCount, float animationFPS, Vector2 startPosition, string spriteName) : this(spriteName, startPosition)
        {
            position = startPosition;
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCount];

            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle((i * sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
            }
            currentAnimationIndex = 0;

        }



        public virtual void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectangles.Length-1)
            {
                timeElapsed = 0;
                currentAnimationIndex = 0;
            }

        }

        /// <summary>
        /// Standart draw function for game objects. SImply draws the sprite given to it.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for the drawing</param>
        /// <param name="gameTime"></param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f),1f, new SpriteEffects(),0f);

        }
    }
}
