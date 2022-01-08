using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneExit : MonoBehaviour
    {
        public string sceneToLoad;
        public string exitName;


        private void OnTriggerEnter(Collider other)
        {
            PlayerPrefs.SetString("LastExitName", exitName);

            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            var asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}