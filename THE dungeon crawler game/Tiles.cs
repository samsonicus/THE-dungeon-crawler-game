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
        public Tiles(Vector2 starPosition, ContentManager content, string spriteName) : base(starPosition, content, spriteName)
        {
        }
    }
}
