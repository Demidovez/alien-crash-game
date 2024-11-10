using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure
{
    public class SceneLoader: ISceneLoader
    {
        private readonly IGameObjectHolder _gameObjectHolder;

        public SceneLoader(IGameObjectHolder gameObjectHolder)
        {
            _gameObjectHolder = gameObjectHolder;
        }
        
        public void Load(string name, Action onLoaded = null)
        {
            _gameObjectHolder.LoadCoroutine(LoadScene(name, onLoaded));
        }

        public string GetCurrentScene()
        {
            return SceneManager.GetActiveScene().name;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            yield return null;

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            if (waitNextScene == null)
            {
                yield break;
            }
            
            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}