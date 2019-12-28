using Archer.Attack.Effects;
using Archer.Attack.Projectile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack
{
    interface IAttackComponent
    {
        void Exec(IProjectileComponent iProjectileComponent, Creature.Vector sourcePosition, Creature.Vector targetPosition);
    }
}
