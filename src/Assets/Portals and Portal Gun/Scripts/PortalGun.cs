using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Main class for portal gun
/// </summary>
public class PortalGun : MonoBehaviour
{
    public GameObject orangePortalPrefab;
    public GameObject bluePortalPrefab;

    public Material orangeColorMat;
    public Material blueColorMat;

    public AudioClip shootClip;
    public AudioClip resetClip;

    public GameObject beamPrefab;

    public LayerMask portalLayers;

    public bool isOrangeAvailable = true;
    public bool isBlueAvailable = true;

    public MeshRenderer gunColorfulPart;

    public Animator animator;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private List<InputDevice> GetGameControllers()
    {
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);

        var gameControllers = new List<InputDevice>();
        InputDevices.GetDevicesWithRole(InputDeviceRole.LeftHanded, gameControllers);
        
        return gameControllers;
    }
    private bool IsTriggerPressed(InputDevice gameController)
    {
        return gameController
                   .TryGetFeatureValue(CommonUsages.triggerButton, out var triggerButtonValue) &&
               triggerButtonValue;
    }

    private bool IsGripButtonPressed(InputDevice gameController)
    {
        return gameController.TryGetFeatureValue(CommonUsages.gripButton, out var triggerValue) && triggerValue;
    }

    void Update()
    {
        var gameControllers = GetGameControllers();
        if (gameControllers.Count <= 0)
            return;
        var gameController = gameControllers[0];

        if (IsTriggerPressed(gameController) || IsGripButtonPressed(gameController))
        {
            
            RaycastHit hit;
            bool isPortalAvailable = false;
            Ray ray = new Ray(transform.position, -transform.forward );
            
            if (Physics.Raycast(ray, out hit))
            {
                if (portalLayers == (portalLayers | (1 << hit.collider.gameObject.layer)))
                    isPortalAvailable = true;

                animator.SetTrigger("Shoot");
                audioSource.PlayOneShot(shootClip);

                if (IsTriggerPressed(gameController) && isBlueAvailable)
                {
                    if (isPortalAvailable)
                    {
                        RemovePortals(true, false);
                        CreatePortal(bluePortalPrefab, hit.point, hit.normal);
                        gunColorfulPart.material = blueColorMat;
                    }

                    CreateBeam(hit.point, blueColorMat);
                }
                else if (IsGripButtonPressed(gameController) && isOrangeAvailable)
                {
                    if (isPortalAvailable)
                    {
                        RemovePortals(false, true);
                        CreatePortal(orangePortalPrefab, hit.point, hit.normal);
                        gunColorfulPart.material = orangeColorMat;
                    }

                    CreateBeam(hit.point, orangeColorMat);
                }
            }
        }
    }

    /// <summary>
    /// Create portal at the ray hit point
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    private void CreatePortal(GameObject prefab, Vector3 position, Vector3 rotation)
    {
        var portal = Instantiate(prefab, position, Quaternion.LookRotation(rotation));
        portal.transform.position += portal.transform.forward * 0.6f;
        portal.GetComponent<Portal>().Open();
    }

    /// <summary>
    /// Remove all portals from the level
    /// </summary>
    /// <param name="blue"></param>
    /// <param name="orange"></param>
    private void RemovePortals(bool blue, bool orange)
    {
        if (blue)
        {
            if (GameObject.FindGameObjectWithTag("Blue Portal") != null)
                GameObject.FindGameObjectWithTag("Blue Portal").GetComponent<Portal>().Close();
        }

        if (orange)
        {
            if (GameObject.FindGameObjectWithTag("Orange Portal") != null)
                GameObject.FindGameObjectWithTag("Orange Portal").GetComponent<Portal>().Close();
        }
    }

    /// <summary>
    /// Create a beam that flies from the gun
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="color"></param>
    private void CreateBeam(Vector3 direction, Material color)
    {
        var beam = Instantiate(beamPrefab, transform.position + transform.forward, Quaternion.identity);
        beam.GetComponent<MeshRenderer>().material = color;
        beam.GetComponent<TrailRenderer>().material = color;
        beam.transform.LookAt(direction);
        beam.GetComponent<Rigidbody>().AddForce(beam.transform.forward * 200, ForceMode.Impulse);
    }
}