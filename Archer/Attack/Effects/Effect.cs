using System;
using System.Timers;

namespace Archer.Attack.Effects
{
    abstract class Effect : IEffect
    {
        public delegate void EndEffectHandler(Effect effect);
        public event EndEffectHandler endEffectEvent;

        protected object lockTimer;

        protected const long NEW_EFFECT_TIME = 5000;

        protected Timer effectTimer = null;

        public DateTime CreateEffectTime { private get; set; }

        public abstract void Start();

        protected void StartTimer(Timer timer)
        {
            lockTimer = new object();

            effectTimer = timer;

            CreateEffectTime = DateTime.Now;

            effectTimer.Start();
        }

        public void UpdateEffectTime()
        {
            lock (lockTimer)
            {
                CreateEffectTime = DateTime.Now;
            }
        }

        public void Destroy()
        {
            effectTimer.Stop();
            effectTimer = null;
        }

        public void CheckEndEffect()
        {
            lock (lockTimer)
            {
                if (CreateEffectTime.AddMilliseconds(NEW_EFFECT_TIME) < DateTime.Now)
                {
                    Destroy();
                    endEffectEvent?.Invoke(this);
                }
            }
        }
    }
}
