using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Archer.Attack.Effects
{
    abstract class StaticEffect : Effect
    {
        public Action<IEffect> endEffect;

        public int Power { get; internal set; }

        public StaticEffect(int power)
        {
            Power = power;
        }

        private void EndEffectTimer(object source, ElapsedEventArgs e)
        {
            lock (lockTimer)
            {
                endEffect?.Invoke(this);
            }
        }

        public override void Start()
        {
            if (effectTimer == null)
            {
                Timer timer = new Timer(NEW_EFFECT_TIME);

                timer.AutoReset = false;

                timer.Elapsed += EndEffectTimer;

                StartTimer(timer);
            }
            else
            {
                UpdateEffectTime();
            }
        }

        protected new void UpdateEffectTime()
        {
            lock (lockTimer)
            {
                effectTimer.Interval += NEW_EFFECT_TIME;
            }
        }
    }
}
