using UnityEngine;

namespace Assets.Scripts
{
    public class SceneEntrance : MonoBehaviour
    {
        public string lastExitName;
        // Start is called before the first frame update
        private void Start()
        {
            if (PlayerPrefs.GetString("LastExitName") == lastExitName)
            {
                var playerTransform = PlayerScript.instance.transform;
                var sceneEntranceTransform = transform;
                playerTransform.position = sceneEntranceTransform.position;
                playerTransform.eulerAngles = sceneEntranceTransform.eulerAngles;
            }
        }
    }
}