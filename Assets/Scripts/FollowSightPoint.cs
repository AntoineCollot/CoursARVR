using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSightPoint : MonoBehaviour
{
    RaycastLineOfSight lineOfSight;

    public float smooth = 0.1f;
    Vector3 refPosition;

    // Start is called before the first frame update
    void Start()
    {
        lineOfSight = FindObjectOfType<RaycastLineOfSight>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, lineOfSight.hitPoint, ref refPosition, smooth);
        transform.forward = -lineOfSight.hitNormal;
    }
}
