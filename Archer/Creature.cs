using Archer.Attack.Effects;
using System.Collections.Generic;
using System;
using System.Linq;
using Archer.Observers;
using Archer.Observers.HitPoints;

namespace Archer
{
    abstract class Creature : BaseObject
    {
        protected int maxLife;
        protected int currentLife;

        protected int speed;

        protected DateTime LastAtackTime = DateTime.MinValue;
        protected int attackSpeed;
        protected object atackLocker = new object();

        protected List<Effect> effects = new List<Effect>();

        public DamageObserver DamageObserver { get; private set; }
        public HealObserver HealObserver { get; private set; }
        public DeathObserver DeathObserver { get; private set; }


        public Creature(int maxLife, int attackSpeed, int speed, Vector position, double size) : base(position, size)
        {
            this.maxLife = maxLife;
            currentLife = maxLife;

            this.attackSpeed = attackSpeed;
            this.speed = speed;

            DamageObserver = new DamageObserver();
            HealObserver = new HealObserver();
            DeathObserver = new DeathObserver();
        }

        public void AddEffect(Type effectType)
        {
            Effect effect = effects.FirstOrDefault(x => x.GetType() == effectType);
            if (effect != null)
            {
                effect.UpdateEffectTime();
            }
            else
            {
                Effect newEffect = (Effect)Activator.CreateInstance(effectType);
                effects.Add(newEffect);

                newEffect.endEffectEvent += EndEffect;

                if (newEffect is OTEffect)
                {
                    (newEffect as OTEffect).doOTAction += GetOTEffect;
                }
                else if (newEffect is StaticEffect)
                {
                    StaticEffect eff = (newEffect as StaticEffect);
                    GetStaticEffect(eff);
                }
            }
        }

        private void GetStaticEffect(StaticEffect effect, bool isEndEffect = false)
        {
            switch (effect.GetType().ToString())
            {
                case "Frozen":
                    {
                        if (isEndEffect)
                        {
                            speed += effect.Power;
                        }
                        else
                        {
                            speed -= effect.Power;
                        }
                        break;
                    }
            }
        }

        private void GetOTEffect(IEffect effect)
        {
            var eff = effect as IOTEffect;

            if (eff is IDOTEffect)
            {
                GetDamage(eff.HealDamageValue);
            }
            else if (eff is IHOTEffect)
            {
                Heal(eff.HealDamageValue);
            }
        }

        public void EndEffect(Effect effect)
        {
            effects.Remove(effect);

            if (effect is StaticEffect)
            {
                GetStaticEffect(effect as StaticEffect, true);
            }
        }

        public void Heal(int heal)
        {
            currentLife = Math.Min(currentLife + heal, maxLife);

            HealObserver.NotifyAll();
        }

        public void GetDamage(int damage)
        {
            currentLife -= damage;

            DamageObserver.NotifyAll();

            if (currentLife <= 0)
            {
                DeathObserver.NotifyAll();
                Destroy();
            }
        }

        protected void Destroy()
        {
            effects.ForEach(x => x.Destroy());
        }

        protected void UpdateAtackTime()
        {
            lock (atackLocker)
            {
                LastAtackTime = DateTime.Now;
            }
        }

        protected bool IsCanAttack()
        {
            lock (atackLocker)
            {
                return LastAtackTime.AddSeconds(attackSpeed) < DateTime.Now;
            }
        }
    }
}
