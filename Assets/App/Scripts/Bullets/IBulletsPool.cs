namespace App.Scripts.Bullets
{
    public interface IBulletsPool
    {
        public void FillBy(string bulletPrefabPath);
        public Bullet GetBullet();
    }
}