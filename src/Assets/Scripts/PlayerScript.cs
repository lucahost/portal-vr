using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerScript : MonoBehaviour
    {
        public static PlayerScript instance;
        // Start is called before the first frame update
        private void Start()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}