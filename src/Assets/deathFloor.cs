using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathFloor : MonoBehaviour
{
    private GameObject startObject;
    private Vector3 resetPosition;
    private Quaternion resetRotation;
    
    void Start()
    {
        startObject = GameObject.Find("XR Rig");
        resetPosition = startObject.GetComponent<Transform>().position;
        resetRotation = startObject.GetComponent<Transform>().rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HandleResetPosition();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        startObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void HandleResetPosition()
    {
        startObject.GetComponent<Transform>().position = resetPosition;
        startObject.GetComponent<Transform>().rotation = resetRotation;
        startObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
