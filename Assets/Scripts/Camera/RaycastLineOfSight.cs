using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastLineOfSight : MonoBehaviour
{
    public Vector3 hitPoint { get; private set; }
    public Vector3 hitNormal { get; private set; }
    public bool somethingIsInSight {get;private set;}
    public Vector3 SightDirection
    {
        get
        {
            return (hitPoint - transform.position).normalized;
        }
    }
    public float HitDistance
    {
        get
        {
            return Vector3.Distance(transform.position, hitPoint);
        }
    }
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray cameraRay = cam.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f));
        if (Physics.Raycast(cameraRay,out hit))
        {
            hitPoint = hit.point;
            hitNormal = hit.normal;
            somethingIsInSight = true;

            //Debug view
            Debug.DrawLine(transform.position, hitPoint,Color.red);
        }
        else
        {
            somethingIsInSight = false;
        }
    }
}
