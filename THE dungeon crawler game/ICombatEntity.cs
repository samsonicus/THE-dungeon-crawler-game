using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_dungeon_crawler_game
{
    interface ICombatEntity
    {
        void Attack();
        void GainHealth();
        void LoseHealth();

    }
}
