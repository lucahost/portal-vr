using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HandleResetPosition();
        }
    }

    void HandleResetPosition()
    {
        var activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(activeSceneName);
    }
}
