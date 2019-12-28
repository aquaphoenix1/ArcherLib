using System;
using System.Timers;

namespace Archer.Attack.Effects
{
    abstract class OTEffect : Effect
    {
        public Action<IEffect> doOTAction;

        protected void DoOTEffect(object source, ElapsedEventArgs e)
        {
            EffectOfOT();

            CheckEndEffect();
        }

        protected abstract void EffectOfOT();
        
        protected const long PERIOD_OT_EFFECT = 1000;

        public override void Start()
        {
            if (effectTimer == null)
            {
                Timer timer = new Timer(PERIOD_OT_EFFECT);

                timer.AutoReset = true;

                timer.Elapsed += DoOTEffect;

                StartTimer(timer);
            }
            else
            {
                UpdateEffectTime();
            }
        }
    }
}
