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

    //Appelée par le composant PickUpItems lorsque la main attrape un objet.
    public virtual void OnItemPickedUp(Transform sender)
    {
        //On peut mettre le rigidbody en kinematic pour éviter qu'il cogne contre l'environment lorsqu'on le tient.
        rigidbody.isKinematic = true;
        isPickedUp = true;

        //On le parente à la main tout en gardant sa position dans le monde.
        transform.SetParent(sender, true);
    }

    //Appelée par la main lorsqu'on relache l'objet.
    public virtual void OnItemReleased()
    {
        //On restore son rigidbody dans son état normal.
        rigidbody.isKinematic = false;
        isPickedUp = false;

        //On le déparente de la main tout en gardant sa position dans le monde.
        transform.SetParent(null, true);
    }
}
