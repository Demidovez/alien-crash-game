using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace App.Scripts.Infrastructure
{
    public class SceneLoader
    {
        private readonly AsyncProcessor _asyncProcessor;

        public SceneLoader(AsyncProcessor asyncProcessor)
        {
            _asyncProcessor = asyncProcessor;
        }
        
        public void Load(string name, Action onLoaded = null)
        {
            _asyncProcessor.StartCoroutine(LoadScene(name, onLoaded));
        }

        public string GetCurrentScene()
        {
            return SceneManager.GetActiveScene().name;
        }
        
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