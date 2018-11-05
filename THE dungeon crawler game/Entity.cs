using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class Entity : GameObject
    {
        private int speed;
        private Vector2 direction;
        List<GameObject> gameObject;


        virtual protected void Die()
        {
         
            
        }

        public void Move()
        {



        }

        public void Generate(Vector2 startPosition, string spriteName)
        {



        }



    }
}
