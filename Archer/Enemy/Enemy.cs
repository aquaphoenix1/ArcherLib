using Archer.Player;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Archer.Enemy
{
    abstract class Enemy : Creature
    {
        protected Task AtackTask;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        private double agressionRadius;

        public Enemy(double agressionRadius, int attackSpeed, int maxLife, int speed, Vector position, double size) : base(maxLife, attackSpeed, speed, position, size)
        {
            this.agressionRadius = agressionRadius;
        }

        protected void StartAtackTask(Action action)
        {
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            AtackTask = new Task(action, cancellationToken);
            AtackTask.Start();
        }

        protected bool IsCancellationRequested()
        {
            return cancellationToken.IsCancellationRequested;
        }

        protected void ThrowIfCancellationRequested()
        {
            cancellationToken.ThrowIfCancellationRequested();
        }

        protected IPlayer IsEnemyNear()
        {
            return new HumanPlayer(12, 5, 7, new Vector(12, 12), 10);
        }

        protected new void Destroy()
        {
            cancellationTokenSource.Cancel(true);

            base.Destroy();
        }
    }
}
