using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Levels
{
    public class LevelsData: ILevelsData
    {
        public List<Level> Levels { get; private set; }
        public Level LastUnlocked { get; private set; }

        public LevelsData(List<LevelSO> levelsSo)
        {
            var levels = levelsSo.OrderBy(level => level.Order).ToArray();

            Levels = new List<Level>();

            for (int i = 0; i < levels.Length; i++)
            {
                var levelSo = levels[i];
                var isFirst = i == 0;
                var isLast = i == levels.Length - 1;
                
                var level = new Level(levelSo, isFirst, isLast);
                
                if (i != 0)
                {
                    Levels[i - 1].SetNext(level);
                }

                if (level.IsUnlocked)
                {
                    LastUnlocked = level;
                }
                
                Levels.Add(level);
            }
        }
    }
}