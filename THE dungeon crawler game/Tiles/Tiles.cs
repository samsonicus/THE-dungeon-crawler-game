using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THE_dungeon_crawler_game
{
    class Tiles : GameObject
    {
        public const int tileSize = 50;
        
        public Tiles(Vector2 starPosition, string spriteName) : base(1,1,starPosition,spriteName)
        {
            
        }

        /// <summary>
        /// Draws the the tile.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used for drawing the sprite.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, Vector2.Zero, 1f, new SpriteEffects(), 0.5f);
            
        }
    }
}
