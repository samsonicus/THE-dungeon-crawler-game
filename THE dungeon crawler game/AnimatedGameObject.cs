using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    class AnimatedGameObject:GameObject
    {
        protected Rectangle[] animationRectangles;
        

        private float animationFPS;
        int currentAnimationIndex;

        public AnimatedGameObject(int frameCount, float animationFPS, Vector2 startPosition, string spriteName):base(spriteName, startPosition)
        {
            position = startPosition;
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCount];

            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle((i * sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
            }
            currentAnimationIndex = 0;

        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - sprite.Width - animationRectangles[0].Width * 0.5), (int)(position.Y - sprite.Height - animationRectangles[0].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectangles.Count() - 1)
            {
                currentAnimationIndex = 0;
                timeElapsed = 0;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex],Color.White,rotation,new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f),1f,new SpriteEffects(), 0f);
        }
    }
}
