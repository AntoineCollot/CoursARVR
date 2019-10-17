using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    void OnItemPickedUp(Transform holder);
    void OnItemReleased();
}
