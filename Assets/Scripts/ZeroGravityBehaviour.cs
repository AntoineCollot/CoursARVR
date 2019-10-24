using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityBehaviour : MonoBehaviour
{
    Rigidbody r;
    public float onCollisionRepulsionForce;
    public float zeroGravityWindForce;
    public float zeroGravityForceDistance;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GravityController.NoGravity)
            r.AddForceAtPosition(GetZeroGravityWind(r.position)* zeroGravityWindForce, r.position+Random.rotation.eulerAngles * zeroGravityForceDistance,ForceMode.Acceleration);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(GravityController.NoGravity)
            r.AddForce(collision.contacts[0].normal * onCollisionRepulsionForce,ForceMode.Acceleration);
    }

    public static Vector3 GetZeroGravityWind(Vector3 pos)
    {
        return new Vector3(Mathf.PerlinNoise(pos.x + Time.time, pos.y + Time.time * 0.3f) - 0.5f,
                            Mathf.PerlinNoise(pos.x + Time.time + 43, pos.y + Time.time * 0.3f + 34) - 0.5f,
                            Mathf.PerlinNoise(pos.x + Time.time + 77, pos.y + Time.time * 0.3f + 21) - 0.5f);
    }
}
