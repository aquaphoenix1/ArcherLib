using Archer.Attack.Projectile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack
{
    interface IRangeAttack : IAttackAble
    {
        void ThrowProjectile(IProjectileComponent iProjectileComponent, Creature.Vector sourcePosition, Creature.Vector targetPosition);
    }
}
