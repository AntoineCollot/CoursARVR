using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Cette classe permet d'appeler des évenements avec une touche du clavier
public class KeyboardInputs : MonoBehaviour
{
    public UnityEvent onTriggerPressed = new UnityEvent();
    public UnityEvent onTriggerReleased = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            onTriggerPressed.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            onTriggerReleased.Invoke();
        }
    }
}
