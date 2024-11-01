namespace App.Scripts.Enemies
{
    public interface IAttackMode
    {
        public bool IsAttacking { get; }
        public void SetReady(bool isReady);
        public void Attack();
    }
}