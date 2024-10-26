namespace App.Scripts.Enemies
{
    public interface IEnemyAttack
    {
        public bool IsAttacking { get; }
        public void TryAttack();
    }
}