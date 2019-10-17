using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInCamDirection : MonoBehaviour
{
    Transform camT;

    private void Start()
    {
        camT = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = transform.position + camT.forward;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}
