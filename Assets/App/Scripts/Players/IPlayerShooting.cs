using System;

namespace App.Scripts.Players
{
    public interface IPlayerShooting
    {
        public event Action OnShootEvent;
    }
}