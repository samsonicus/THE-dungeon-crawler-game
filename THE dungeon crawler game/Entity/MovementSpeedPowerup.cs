using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THE_dungeon_crawler_game
{
    class MovementSpeedPowerup : PowerUp, ICollidable
    {

        private int speedAmount;
        /// <summary>
        /// Default constructor for MovementSpeedPowerup
        /// </summary>
        /// <param name="startPosition">Sets position of powerup</param>
        /// <param name="speedAmount">Determines how much speed the powerup gives</param>
        /// <param name="duration">Determines how long the powerup lasts on the player</param>
        public MovementSpeedPowerup(Vector2 startPosition, float duration) : base(1, 1, startPosition, "SpeedPowerUp", duration)
        {
            this.speedAmount = 50;
        }

        public Rectangle CollisionBox
        { get
            {
               // return new Rectangle((int)position.X, (int)position.Y, animationRectanglesSheet[0, 0].Width, animationRectanglesSheet[0, 0].Height);
                return new Rectangle((int)position.X, (int)position.Y, 32, 32); //Hardcoded the size of the sprite, because we don't yet have a way to retrieve the tile size
            }
        }

        public override string ShortName { get => "SPD"; }

        public override int PowerupValue { get => speedAmount; }

        public override bool ApplyPowerup(Player player)
        {

            foreach (PowerUp powerUp in player.activePowerups)
            {
                if (powerUp is MovementSpeedPowerup)
                {
                    powerUp.duration = 10;
                    return false;       
                }
                
            }
            player.Speed += speedAmount;
            return true;    
        }

        public override void RemovePowerup(Player player)
        {
            player.Speed -= speedAmount;
        }

        public bool IsColliding(ICollidable otherCollidable)
        {
            return otherCollidable.CollisionBox.Intersects(this.CollisionBox);
        }

        public void DoCollision(ICollidable otherCollidable)
        {
            if (otherCollidable is Player)
            {
                ((Player)otherCollidable).AddPowerUp(this);

            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, 32, 32), Color.White);     //Hardcoded the size here also.
        }

    }
}
