using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRControllerInputs : MonoBehaviour
{
    SteamVR_Action_Boolean booleanAction;

    private void Start()
    {
        //On récupère l'action voulue
        booleanAction = SteamVR_Actions._default.GrabPinch;

        //on s'abonne à l'événement invoqué lorsque le bouton est appuyé
        booleanAction[SteamVR_Input_Sources.Any].onStateDown += TriggerPressed;
    }

    void TriggerPressed(SteamVR_Action_Boolean action, SteamVR_Input_Sources source)
    {
        //Faire l'action voulue avec le bouton
    }
}
