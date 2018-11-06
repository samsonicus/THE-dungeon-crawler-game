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
        protected Vector2 position;
        protected float rotation;
        public Vector2 Position { get => position; }
        
        
        protected double timeElapsed = 0;

        private Vector2 zero;
        private string spriteName;


        #region collision
        /// <summary>
        /// CollisionBox for the Gameobject. Height and Width are based on the height and width of the sprite used. X and Y coordinates are based on the height and width of the sprite aswell.
        /// </summary>
        public abstract Rectangle CollisionBox
        {
            get;
            
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






        public GameObject(string spriteName, Vector2 position) 
        {
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
            this.spriteName = spriteName;
            this.position = position;
            rotation = 0;
        }


        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Standart draw function for game objects. SImply draws the sprite given to it.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for the drawing</param>
        /// <param name="gameTime"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f),1f, new SpriteEffects(),0f);

        }
    }
}
