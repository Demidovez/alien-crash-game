namespace App.Scripts.Enemies
{
    public interface IAttackMode
    {
        public void SetReady(bool isReady);
        public void Attack();
    }
}