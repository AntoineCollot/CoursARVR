using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    new protected Rigidbody rigidbody;
    protected bool isPickedUp;

    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnItemPickedUp(Transform holder)
    {
        rigidbody.isKinematic = true;
        isPickedUp = true;
        transform.SetParent(holder, true);
        //StartCoroutine(FollowHolder(holder));
    }

    public virtual void OnItemReleased()
    {
        isPickedUp = false;
        rigidbody.isKinematic = false;
        transform.SetParent(null, true);
    }

    //protected IEnumerator FollowHolder(Transform holder)
    //{
    //    Vector3 offsetPosition = transform.position - holder.position;

    //    while(isPickedUp)
    //    {
    //        transform.position = holder.position + offsetPosition;

    //        yield return null;
    //    }
    //}
}
