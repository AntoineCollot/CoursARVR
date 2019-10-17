using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidatePosition : MonoBehaviour
{
    public float maxValidAngle;
    public Color validColor;
    public Color invalidColor;
    public bool positionIsValid { get; private set; }
    Material particleMaterial;

    // Start is called before the first frame update
    void Start()
    {
        particleMaterial = GetComponent<ParticleSystemRenderer>().material;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        positionIsValid = Vector3.Angle(Vector3.up, -transform.forward) <= maxValidAngle;

        if (particleMaterial != null)
        {
            if (positionIsValid)
                particleMaterial.color = validColor;
            else
                particleMaterial.color = invalidColor;
        }
    }
}
