using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public static bool NoGravity
    {
        get
        {
            return Physics.gravity == Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("No Gravity")]
    public void SetNoGravity()
    {
        SetGravity(Vector3.zero);
    }

    public void SetGravity(Vector3 gravityForce)
    {
        Physics.gravity = gravityForce;
    }
}
