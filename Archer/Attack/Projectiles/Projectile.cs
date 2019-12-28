using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Attack.Projectile
{
    class Projectile : BaseObject, IProjectileComponent
    {
        public Projectile(double size) : base(size)
        {
        }

        public int Damage
        {
            get
            {
                return 10;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void DoDamage()
        {
            Console.WriteLine("do damage");
        }
    }
}
