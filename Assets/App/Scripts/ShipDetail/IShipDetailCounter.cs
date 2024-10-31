using System;

namespace App.Scripts.ShipDetail
{
    public interface IShipDetailCounter
    {
        public event Action OnShipDetailsCollectedEvent;
        public void SetCountAll(int value);
        public void CollectedDetail();
    }
}