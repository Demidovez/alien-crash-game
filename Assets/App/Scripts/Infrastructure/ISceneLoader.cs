using System;

namespace App.Scripts.Infrastructure
{
    public interface ISceneLoader
    {
        public void Load(string name, Action onLoaded = null);
        public string GetCurrentScene();
    }
}