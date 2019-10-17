using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardButtons : MonoBehaviour
{
    public UnityEvent onTriggerPressed = new UnityEvent();
    public UnityEvent onTriggerReleased = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
