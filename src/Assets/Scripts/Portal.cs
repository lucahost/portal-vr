using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts;
using UnityEngine;

/// <summary>
/// Main portal class
/// </summary>
public class Portal : MonoBehaviour
{
    public bool isOrange;
    public Portal secondPortal;
    public Camera selfCamera;
    public Texture defaultTexture;

    private bool _isReady;
    private int _objLayer;
    private static readonly int Close1 = Animator.StringToHash("Close");
    private static readonly int Open1 = Animator.StringToHash("Open");

    private static bool _isTeleporting;
    private Transform _otherTransform;


    void LateUpdate()
    {
        if (_isReady && secondPortal != null)
        {
            // Position
            Vector3 lookerPosition = secondPortal.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
            lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);
            selfCamera.transform.localPosition = lookerPosition;

            // Rotation
            Quaternion difference = transform.rotation * Quaternion.Inverse(secondPortal.transform.rotation * Quaternion.Euler(0, 180, 0));
            selfCamera.transform.rotation = difference * Camera.main.transform.rotation;

            // Clipping
            selfCamera.nearClipPlane = lookerPosition.magnitude;
        }

        if (_isTeleporting)
        {
            Teleport(_otherTransform);
        }
    }

    /// <summary>
    /// Check is the second portal is available
    /// </summary>
    private void CheckSecondPortal()
    {
        if (GameObject.FindGameObjectWithTag(isOrange ? "Blue Portal" : "Orange Portal") != null)
        {
            SetCamera();
            secondPortal.SetCamera();
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = defaultTexture;
        }
    }

    /// <summary>
    /// Set camera properties
    /// </summary>
    private void SetCamera()
    {
        secondPortal = GameObject.FindGameObjectWithTag(isOrange ? "Blue Portal" : "Orange Portal").GetComponent<Portal>();
        secondPortal.selfCamera.stereoTargetEye = StereoTargetEyeMask.Both;
        secondPortal.selfCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = secondPortal.selfCamera.targetTexture;


        _isReady = true;
    }

    /// <summary>
    /// Play open portal animation
    /// </summary>
    public void Open()
    {
        GetComponent<Animator>().SetTrigger(Open1);
        CheckSecondPortal();
    }

    /// <summary>
    /// Play close portal animation
    /// </summary>
    public void Close()
    {
        tag = "Untagged";
        GetComponent<Animator>().SetTrigger(Close1);
        Destroy(gameObject, 0.5f);
    }

    
    /// <summary>
    /// Trigger teleporting process
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        float zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;
        
        // other.GetComponent<Rigidbody>().useGravity = false;

        if (zPos < 0 && !_isTeleporting && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _otherTransform = other.transform;
            _isTeleporting = true;
            other.gameObject.layer = LayerMask.NameToLayer("Teleporting");
        }
    }

    

    /// <summary>
    /// Teleport player to the second portal
    /// </summary>
    private void Teleport(Transform obj)
    {
        if (obj != null && secondPortal != null)
        {
            print(obj.ToString());
            print(isOrange ? "Teleporting from orange to blue" : "blue to orange");
            print(secondPortal.transform.position.ToString());
            print(secondPortal.ToString());


            Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
            localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
            obj.position = secondPortal.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);

            Quaternion difference = secondPortal.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
            difference.x = 0;
            difference.z = 0;
            obj.rotation = difference * obj.rotation;
            //obj.position +=  Vector3.back * 1.5f;
           
           
            //obj.position = secondPortal.transform.position;
            //Quaternion difference = secondPortal.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
            //difference.x = 0;
            //difference.z = 0;
            //obj.rotation = difference * obj.rotation;
            //obj.position +=  Vector3.back * 1.5f;

            
            _isTeleporting = false;
        }
    }

    /// <summary>
    /// Set proper layer
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Beam"))
            Destroy(other.gameObject);

    }

    /// <summary>
    /// Set proper layer
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(ResetIsTeleporting(other));
    }

    private IEnumerator ResetIsTeleporting(Collider col)
    {
        yield return new WaitForSeconds(2);
        col.gameObject.layer = LayerMask.NameToLayer("Player");
        _isTeleporting = false;
    }
}
