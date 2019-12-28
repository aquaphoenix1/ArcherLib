using System;
using Archer.Attack;
using Archer.Player;
using Archer.Attack.Projectile;

namespace Archer.Enemy
{
    class StaticArcher : Enemy
    {
        public IAttackComponent iAtackComponent { private get; set; }
        public IProjectileComponent iProjectileComponent { private get; set; }

        public StaticArcher(IAttackComponent iAtackComponent, IProjectileComponent iProjectileComponent, int maxLife, double agressionRadius, int attackSpeed, int speed, Vector position, double size) : base(agressionRadius, attackSpeed, maxLife, speed, position, size)
        {
            this.iAtackComponent = iAtackComponent;
            this.iProjectileComponent = iProjectileComponent;

            StartAtackTask(ExecuteAtack);            
        }

        public void ExecuteAtack()
        {
            ThrowIfCancellationRequested();

            while (true)
            {
                if (IsCancellationRequested())
                {
                    ThrowIfCancellationRequested();
                }

                var enemy = IsEnemyNear();
                if (enemy != null)
                {
                    if (IsCanAttack())
                    {
                        UpdateAtackTime();
                        iAtackComponent.Exec(iProjectileComponent, Position, (enemy as HumanPlayer).Position);
                    }
                }
            }
        }
    }
}
