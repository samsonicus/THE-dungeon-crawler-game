using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Base class for powerups. 
    /// All powerups have a duration for how long they last on the player. 
    /// All subclassees to powerups also need to implement the ApplyPowerup and RemovePowerup methods.
    /// ApplyPowerUp should modify the player's statstics based on the powerup.
    /// RemovePowerUp should remove the changes made by the ApplyPowerUp method, so that applying a powerup and removing it results in the same state as before applying.
    /// </summary>
    public abstract class PowerUp : GameObject
    {

        
        public double duration;

        public abstract string ShortName { get; }
        public abstract int PowerupValue { get; }

        /// <summary>
        /// Base constructor for powerups
        /// </summary>
        /// <param name="frameCountWidth"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPosition"></param>
        /// <param name="spriteName"></param>
        /// <param name="duration"></param>
        public PowerUp(int frameCountWidth, float animationFPS, Vector2 startPosition, string spriteName, float duration) : base(frameCountWidth, animationFPS, startPosition, spriteName)
        {
            this.duration = duration;
        }


        public abstract bool ApplyPowerup(Player player);
        public abstract void RemovePowerup(Player player);
    }
}
