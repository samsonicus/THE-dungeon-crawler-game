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
    class GameObject
    {
        protected Texture2D sprite;
        protected Vector2 position;
        public Vector2 Position { get => position; }

        Rectangle[] animationRectangles;

        float animationFPS = 10;
        int currentAnimationIndex = 0;
        double timeElapsed = 0;

        protected ContentManager content;



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
        public bool isColliding(GameObject otherObject)
        {
            return CollisionBox.Intersects(otherObject.CollisionBox);
        }



        /// <summary>
        /// The constructor for a GameObject without animations. 
        /// </summary>
        /// <param name="starPosition">The start position for the GameObject</param>
        /// <param name="content">A referance for the ContentManager for loadingresources</param>
        /// <param name="spriteName">The name of the texture used for the GameObject</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(Vector2 starPosition, ContentManager content, string spriteName)
        {
            position = starPosition;
            sprite = content.Load<Texture2D>(spriteName);
        }





        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }
    }
}
