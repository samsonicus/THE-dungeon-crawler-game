using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Interface for entities involved combat
    /// </summary>
    interface ICombatEntity
    {
        int Health { get;}
        void Attack();
        void GainHealth(int lifeGained);
        void LoseHealth(int lifeLost);
    }
}
