using UnityEngine;

public class Beam : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            return;

        GameObject o;
        (o = gameObject).SetActive(false);

        Destroy(o);
    }
}
