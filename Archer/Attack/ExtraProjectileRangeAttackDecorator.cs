using Archer.Attack.Effects;
using Archer.Attack.Projectile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Archer.Attack
{
    class ExtraProjectileRangeAttackDecorator : BaseRangeAttackDecorator
    {
        public ExtraProjectileRangeAttackDecorator(IAttackComponent iAttackComponent) : base(iAttackComponent)
        {
        }

        public override void Exec(IProjectileComponent iProjectileComponent, Creature.Vector sourcePosition, Creature.Vector targetPosition)
        {
            base.Exec(iProjectileComponent, sourcePosition, targetPosition);

            Thread.Sleep(100);

            base.ThrowProjectile(iProjectileComponent, sourcePosition, targetPosition);
        }
    }
}
