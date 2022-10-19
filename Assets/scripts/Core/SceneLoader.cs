using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jam.Core 
{
    public class SceneLoader : MonoBehaviour
    {
        private List<AsyncOperation> loadingScenes = new List<AsyncOperation>();

        public void LoadLevel(List<string> scenes)
        {
            // reset the list of scenes that are loading
            loadingScenes = new List<AsyncOperation>();

            var activeScene = SceneManager.GetActiveScene();

            // add the scenes that we need to load to the loader array
            for (int i = 0; i < scenes.Count; i++)
            {
                var loadMode = LoadSceneMode.Additive;
                if (i == 0) loadMode = LoadSceneMode.Single;

                loadingScenes.Add(SceneManager.LoadSceneAsync(scenes[i], loadMode));
                Debug.Log(string.Format("Starting to load scene \"{0}\"", scenes[i]));
            }

            // start loading and show loading screen things
            StartCoroutine(LoadingScreen());

            Debug.Log("Done loading");
        }

        IEnumerator LoadingScreen()
        {
            float totalProgress = 0.0f;
            for (int i = 0; i < loadingScenes.Count; i++)
            {
                while (!loadingScenes[i].isDone)
                {
                    totalProgress += loadingScenes[i].progress;
                    yield return null;
                }
            }
        }
    }

}