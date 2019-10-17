using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSightPoint : MonoBehaviour
{
    ValidatePosition validatePosition;
    RaycastLineOfSight lineOfSight;

    // Start is called before the first frame update
    void Start()
    {
        validatePosition = FindObjectOfType<ValidatePosition>();
        lineOfSight = FindObjectOfType<RaycastLineOfSight>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && validatePosition.positionIsValid)
        {
            float height = transform.position.y;
            Vector3 target = lineOfSight.hitPoint;
            target.y = height;
            transform.position = target;
        }
    }
}
