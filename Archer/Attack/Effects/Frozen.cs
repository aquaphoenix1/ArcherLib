using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack.Effects
{
    class Frozen : StaticEffect
    {
        public Frozen(int power) : base(power)
        {
            Start();
        }
    }
}
