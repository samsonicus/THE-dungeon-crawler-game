using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    interface ICombatEntity
    {
        int Health { get;}
        void Attack();
        void GainHealth(int lifeGained);
        void LoseHealth(int lifeLost);
    }
}
