using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette classe permet de rendre un objet jetable.
public class ThrowableItem : InteractableItem
{
    protected List<Vector3> positions = new List<Vector3>();
    [Tooltip("Nombre de positions à prendre en compte dans le calcul de la vitesse")] public int sampleCount;

    //Retourne la vitesse moyenne entre le plus vielle élément de position et le plus récent
    public Vector3 AverageSpeed
    {
        get
        {
            //Vitesse = Déplacement / temps
            return (positions[positions.Count - 1] - positions[0]) / (Time.smoothDeltaTime * positions.Count);
        }
    }

    protected void Update()
    {
        //Ajoute la position a la queue
        positions.Add(transform.position);

        //Limite le nombre d'élément max à sampleCount
        if(positions.Count>sampleCount)
        {
            positions.RemoveAt(0);
        }
    }

    //Quand l'objet est relaché.
    public override void OnItemReleased()
    {
        //applique l'effet de base de itemInteractable.
        base.OnItemReleased();

        //Applique la vitesse au rigidbody
        rigidbody.velocity = AverageSpeed;
    }
}
