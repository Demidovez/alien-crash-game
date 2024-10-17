namespace App.Scripts.Enemies
{
    public interface IAttackMode
    {
        public bool IsAttacking { get; set; }
        public void SetReady(bool isReady);
        public void Attack();
    }
}