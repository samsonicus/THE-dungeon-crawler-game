using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace THE_dungeon_crawler_game
{
    class Tiles : GameObject
    {
        /// <summary>
        /// Constructor for the Tiles class.
        /// </summary>
        /// <param name="starPosition">The position of the tile.</param>
        /// <param name="content">TODO Remove later.</param>
        /// <param name="spriteName">The string of the spritetexture name.</param>
        public Tiles(Vector2 starPosition, ContentManager content, string spriteName) : base(starPosition, content, spriteName)
        {
        }


    }
}
