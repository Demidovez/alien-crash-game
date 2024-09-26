using App.Scripts.Tools.WayPoints;

namespace App.Scripts.Entity
{
    public interface IEntityNavigation
    {
        public void SetCurrentWayPoint(WayPoint wayPoint);

        public void SetDirection(int direction);

        public void SetDestination(WayPoint wayPoint);
    }
}