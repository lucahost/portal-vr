using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This will be picked up automatically by the wrist watch when it get spawn in the scene by the Interaction toolkit
/// and setup the buttons and the linked events on the canvas
/// </summary>
public class WitchHouseUIHook : WatchScript.IUIHook
{
    public GameObject LeftUILineRenderer;
    public GameObject RightUILineRenderer;
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
            SceneManager.LoadScene("Lobby");
        });

        LeftUILineRenderer.SetActive(false);
        RightUILineRenderer.SetActive(false);

        watch.UILineRenderer = LeftUILineRenderer;
    }
}
