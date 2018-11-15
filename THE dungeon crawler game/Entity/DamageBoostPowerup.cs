using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Class for the damageboost powerup
    /// </summary>
    class DamageBoostPowerup : PowerUp, ICollidable
    {
        int damageBoostAmount;

        public DamageBoostPowerup(Vector2 startPosition, float duration, int damageBoostAmount) :
            base(1, 1, startPosition, "DamageBoost", duration)
        {
            this.damageBoostAmount = damageBoostAmount;
        }

        /// <summary>
        /// Returns the  collisionbox
        /// </summary>
        public Rectangle CollisionBox
        {

            get
            {
                // return new Rectangle((int)position.X, (int)position.Y, animationRectanglesSheet[0, 0].Width, animationRectanglesSheet[0, 0].Height);
                return new Rectangle((int)position.X, (int)position.Y, 32, 32); //Hardcoded the size of the sprite, because we don't yet have a way to retrieve the tile size
            }

        }

        public override string ShortName { get => "DMG"; }

        public override int PowerupValue { get => damageBoostAmount; }

        public override bool ApplyPowerup(Player player)
        {

            foreach (PowerUp powerUp in player.activePowerups)
            {
                if (powerUp is DamageBoostPowerup)
                {
                    powerUp.duration = 10;
                    ((DamageBoostPowerup)powerUp).damageBoostAmount++;
                    return false;
                }

            }
            player.damage += damageBoostAmount;
            return true;
        }

        public void DoCollision(ICollidable otherCollidable)
        {
            if (otherCollidable is Player)
            {
                ((Player)otherCollidable).AddPowerUp(this);

            }
        }

        public bool IsColliding(ICollidable otherCollidable)
        {
            return otherCollidable.CollisionBox.Intersects(this.CollisionBox);
        }

        public override void RemovePowerup(Player player)
        {
            player.damage -= damageBoostAmount;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, 32, 32), Color.White);     //Hardcoded the size here also.
        }

    }

}
