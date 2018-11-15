using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// A ranged turret Enemy
    /// </summary>
    class TurretEnemy : Enemy, ICombatEntity
    {
        /// <summary>
        /// Main consttructor for the turretEnemy
        /// </summary>
        /// <param name="position"> position of the enemy</param>
        /// <param name="direction">direction of the enemy</param>
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
                GameWorld.AddGameObject(new SimpleProjectile(position + new Vector2(16), shootAtPlayer, this, 1)); 
                lastAttack = gameTime.TotalGameTime.TotalSeconds;
            }

        }



    }
}
