using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float interactionRadius;
    [SerializeField] LayerMask interactionLayer;

    Rigidbody pickedUpItem;

    public void PickUp()
    {
        Collider[] hitItems = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);
        if (hitItems.Length == 0)
            return;

        Collider item = FindClosestItem(hitItems);

        pickedUpItem = item.attachedRigidbody;
        pickedUpItem.SendMessage("OnItemPickedUp", transform);
    }

    public void Release()
    {
        if (pickedUpItem == null)
            return;

        pickedUpItem.SendMessage("OnItemReleased");
        pickedUpItem = null;
    }

    Collider FindClosestItem(Collider[] items)
    {
        float minDist = Mathf.Infinity;
        Collider closestItem = null;
        foreach(Collider item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);
            if(distance<minDist)
            {
                minDist = distance;
                closestItem = item;
            }
        }

        return closestItem;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
