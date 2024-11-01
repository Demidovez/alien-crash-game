using System;

namespace App.Scripts.Teleports
{
    public interface ITeleport
    {
        public event Action OnTeleportedEvent;
        public void SetActiveStatus(bool isActive);
    }
}