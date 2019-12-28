using System;
using System.Timers;

namespace Archer.Attack.Effects
{
    class Burn : OTEffect, IDOTEffect
    {
        public Burn()
        {
            Start();
        }

        public int HealDamageValue
        {
            get
            {
                return 5;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        protected override void EffectOfOT()
        {
            doOTAction?.Invoke(this);
        }
    }
}
