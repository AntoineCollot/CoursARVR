using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControllerInputs : MonoBehaviour
{
    SteamVR_TrackedController controller;

    // Use this for initialization
    void Start()
    {
        controller = GetComponentInParent<SteamVR_TrackedController>();

        //Subscribe to the trigger clicked event of the controller
        controller.TriggerClicked += OnTriggerPressedEvent;
        controller.TriggerUnclicked += OnTriggerReleasedEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
