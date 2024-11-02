using System.Collections.Generic;

namespace App.Scripts.Levels
{
    public interface ILevelsData
    {
        public List<Level> Levels { get; }
        public Level LastUnlocked { get; }
    }
}