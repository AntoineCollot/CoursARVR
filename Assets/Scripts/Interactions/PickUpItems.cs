using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette classe sert à prendre des objets. A mettre sur le Gameobjet qui doit tenir l'objet.
public class PickUpItems : MonoBehaviour
{
    [Tooltip("La taille de la zone d'attrapage d'objet"), SerializeField] float interactionRadius;
    [Tooltip("le layer des objets intéractifs"),SerializeField] LayerMask interactionLayer;

    //Objet que l'on tient actuelement
    Rigidbody pickedUpItem;

    //Prendre un object
    public void PickUp()
    {
        //Trouve tous les objets à porté de la main
        Collider[] hitItems = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);

        //Si rien n'a été touché, on s'arrete
        if (hitItems.Length == 0)
            return;

        Collider item = FindClosestItem(hitItems);

        //On note l'objet pris
        pickedUpItem = item.attachedRigidbody;

        //Envoie un message à l'objet qui appelera toutes méthodes appelées OnItemPickedUp en s'envoyant en argument (pour que l'objet sache qui l'a pris)
        pickedUpItem.SendMessage("OnItemPickedUp", transform);
    }

    //Relacher l'objet
    public void Release()
    {
        //Vérifie que l'on tient bien un objet avant de continuer
        if (pickedUpItem == null)
            return;

        //Envoie un message à l'objet qui appelera toutes méthodes appelées OnItemReleased
        pickedUpItem.SendMessage("OnItemReleased");

        //On note que l'on ne tient plus cet objet
        pickedUpItem = null;
    }

    //Retourne le collider le plus proche dans le tableau
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

    //Dessine la zone d'attrapage autour de la main
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
