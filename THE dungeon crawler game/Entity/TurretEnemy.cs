using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    class TurretEnemy : Enemy, ICombatEntity

    {
        


        //public Rectangle CurrentAnimationRectangle { get => animationRectanglesSheet[(int), currentAnimationIndex]}

        public TurretEnemy(Vector2 position, Vector2 direction) : 
            base(10, 500, 1, 0.5f, 1, 5, 5, position, "treadbot1sheet", 0, direction)
        {
            
            
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 shootAtPlayer = GameWorld.Player.Position - position;
            double sinceLastAttack = gameTime.TotalGameTime.TotalSeconds - lastAttack;
            if (sinceLastAttack >= attackDelay)
            {
                GameWorld.AddGameObject(new SimpleProjectile(position, shootAtPlayer, this, 1)); 
                lastAttack = gameTime.TotalGameTime.TotalSeconds;
            }

        }



    }
}
