using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItem : InteractableItem
{
    protected List<Vector3> positions = new List<Vector3>();
    public int sampleCount;

    public Vector3 AverageSpeed
    {
        get
        {
            return (positions[positions.Count - 1] - positions[0]) / (Time.smoothDeltaTime * positions.Count);
        }
    }

    protected void Update()
    {
        positions.Add(transform.position);

        if(positions.Count>sampleCount)
        {
            positions.RemoveAt(0);
        }
    }

    public override void OnItemReleased()
    {
        base.OnItemReleased();

        rigidbody.velocity = AverageSpeed;
    }
}
