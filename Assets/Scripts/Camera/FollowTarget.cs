using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public bool freezeY;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = target.position;
        if(freezeY)
            targetPos.y = transform.position.y;
        transform.position = targetPos;
    }
}
