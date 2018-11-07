using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Player : Entity
    {
        new Vector2 startPos;
        private const int moveSpeed = 100;
        private int health;
        public int Health
        {
            get { return health; }
        }

        public Player():base(moveSpeed,"test" )
        {

        }


        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Projectile || otherObject is Enemy)
            {
                health--;
            }
        }

    }
}
