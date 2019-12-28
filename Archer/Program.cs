using Archer.Attack;
using Archer.Attack.Effects;
using Archer.Attack.Projectile;
using Archer.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Archer
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticArcher a = new StaticArcher(new RangeAttack(), new Projectile(2), 12, 12, 5, 7, new BaseObject.Vector(10, 10), 10);

            Console.ReadKey();
        }
    }
}