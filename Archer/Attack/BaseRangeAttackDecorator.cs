using Archer.Attack.Effects;
using Archer.Attack.Projectile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack
{
    abstract class BaseRangeAttackDecorator : IRangeAttack, IAttackComponent
    {
        protected IAttackComponent iAttackComponent;

        public BaseRangeAttackDecorator(IAttackComponent iAttackComponent)
        {
            this.iAttackComponent = iAttackComponent;
        }

        public void ThrowProjectile(IProjectileComponent iProjectileComponent, Creature.Vector sourcePosition, Creature.Vector targetPosition)
        {
            (iAttackComponent as IRangeAttack)?.ThrowProjectile(iProjectileComponent, sourcePosition, targetPosition);
        }

        public virtual void Exec(IProjectileComponent iProjectileComponent, Creature.Vector sourcePosition, Creature.Vector targetPosition)
        {
            iAttackComponent.Exec(iProjectileComponent, sourcePosition, targetPosition);
        }
    }
}
