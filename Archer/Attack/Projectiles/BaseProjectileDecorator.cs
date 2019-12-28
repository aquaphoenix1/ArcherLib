using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack.Projectile
{
    class BaseProjectileDecorator : IProjectileComponent
    {
        protected IProjectileComponent iProjectileComponent;

        public BaseProjectileDecorator(IProjectileComponent iProjectileComponent)
        {
            this.iProjectileComponent = iProjectileComponent;
        }

        public int Damage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual void DoDamage()
        {
            iProjectileComponent.DoDamage();
        }
    }
}
