using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    public float speedTreshold = 0.1f;
    [Range(0, 1)]
    public float smoothing = 0.2f;

    private Animator animator;

    private Vector3 previousPos;

    private VRRig vrRig;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();
        previousPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Compute the speed
        Vector3 headSetSpeed = (vrRig.head.vrTarget.position - previousPos) / Time.deltaTime;
        headSetSpeed.y = 0;

        // Local Speed
        Vector3 headSetLocalSpeed = transform.InverseTransformDirection(headSetSpeed);
        previousPos = vrRig.head.vrTarget.position;

        // Set animator values
        float previousDirectionX = animator.GetFloat("directionX");
        float previousDirectionY = animator.GetFloat("directionY");
        bool isMoving = headSetLocalSpeed.magnitude > speedTreshold;
        //print($"IsMoving: {isMoving}. magnitude: {headSetLocalSpeed.magnitude}");
        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("directionX", Mathf.Lerp(previousDirectionX, Mathf.Clamp(headSetLocalSpeed.x, -1 , 1), smoothing));
        animator.SetFloat("directionY", Mathf.Lerp(previousDirectionY, Mathf.Clamp(headSetLocalSpeed.z, -1 , 1), smoothing));

        
    }
}
