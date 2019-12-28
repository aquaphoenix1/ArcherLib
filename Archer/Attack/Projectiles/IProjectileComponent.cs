using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack.Projectile
{
    interface IProjectileComponent
    {
        void DoDamage();

        int Damage { get; set; }
    }
}
