using Archer.Attack.Effects;
using Archer.Attack.Projectile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Archer.Attack
{
    class RangeAttack : IRangeAttack, IAttackComponent
    {
        public void ThrowProjectile(IProjectileComponent iProjectileComponent, Creature.Vector sourcePosition, Creature.Vector targetPosition)
        {
            iProjectileComponent.DoDamage();
        }

        public void Exec(IProjectileComponent iProjectileComponent, Creature.Vector sourcePosition, Creature.Vector targetPosition)
        {
            ThrowProjectile(iProjectileComponent, sourcePosition, targetPosition);
        }
    }
}
