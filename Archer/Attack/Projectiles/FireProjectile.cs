using Archer.Attack.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack.Projectile
{
    class FireProjectile : BaseProjectileDecorator
    {
        public FireProjectile(IProjectileComponent iProjectileComponent) : base(iProjectileComponent)
        {
        }

        public override void DoDamage()
        {
            base.DoDamage();

            DoFireDamage();
        }

        public void DoFireDamage()
        {
            //TODO add target fire
            Console.WriteLine("fire target");
        }
    }
}
