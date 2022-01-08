using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Assets.Scripts
{
    public class KyleUIHook : WatchScript.UIHook
    {
        [FormerlySerializedAs("LeftUILineRenderer")] 
        public GameObject leftUILineRenderer;
        [FormerlySerializedAs("RightUILineRenderer")] 
        public GameObject rightUILineRenderer;
        public GameObject startObject;
        public Vector3 resetPosition;
        public Quaternion resetRotation;

        void Start()
        {
            startObject = GameObject.Find("XR Rig");
            resetPosition = startObject.GetComponent<Transform>().position;
            resetRotation = startObject.GetComponent<Transform>().rotation;
        }

        public override void GetHook(WatchScript watch)
        {
            watch.AddButton("Reset Position", () =>
            {
                startObject.GetComponent<Transform>().position = resetPosition;
                startObject.GetComponent<Transform>().rotation = resetRotation;
            });
            watch.AddButton("Back to Lobby", () =>
            {
                SceneManager.LoadSceneAsync("Lobby");
            });

            leftUILineRenderer.SetActive(false);
            rightUILineRenderer.SetActive(false);

            watch.UILineRenderer = leftUILineRenderer;
        }
    }
}
