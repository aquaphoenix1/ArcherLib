using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Player
{
    class HumanPlayer : Creature, IPlayer
    {
        public HumanPlayer(int maxLife, int attackSpeed, int speed, Vector position, double size) : base(maxLife, attackSpeed, speed, position, size)
        {
        }
    }
}
