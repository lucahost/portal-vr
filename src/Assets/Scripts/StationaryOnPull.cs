using UnityEngine;

namespace Assets.Scripts
{
    public class StationaryOnPull : MonoBehaviour
    {
        public void MakeKinematic()
        {
            gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
