using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class DeathFloor : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                HandleResetPosition();
            }
        }

        private void HandleResetPosition()
        {
            var activeSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(activeSceneName);
        }
    }
}