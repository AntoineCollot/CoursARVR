using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableLever : MonoBehaviour,IInteractable
{
    public bool isInteracting { get; private set; }
    public Transform handle;

    public float maxAngleRange;
    [Range(0,1)]
    public float neutralZoneRange;

    public enum State { Up, Down, Neutral}
    public State state { get; private set; }

    [Header("State Events")]
    public UnityEvent onStateUp = new UnityEvent();
    public UnityEvent onStateDown = new UnityEvent();
    public UnityEvent onStateNeutral = new UnityEvent();

    public void OnItemPickedUp(Transform sender)
    {
        isInteracting = true;

        StartCoroutine(FollowHandY(sender));
    }

    public void OnItemReleased()
    {
        isInteracting = false;
    }

    IEnumerator FollowHandY(Transform hand)
    {
        Vector3 handDirection;
        Vector3 offset = handle.position + handle.forward - hand.position;
        while(isInteracting)
        {
            //On passe dans le reférenciel du levier
            handDirection = transform.InverseTransformDirection(hand.position - transform.position + offset);
            //On ignore la composante x du référentiel de la poignée, puisque la poignée tourne autour de cet axe x
            handDirection.x = 0;
            float angle = Vector3.SignedAngle(handDirection, Vector3.forward,Vector3.right);

            //Limite la rotation
            if (angle > 180)
                angle -= 360;
            else if(angle <-180)
                angle += 360;

            //On applique la rotation
            handle.localEulerAngles = Vector3.right * Mathf.Clamp(-angle,- maxAngleRange * 0.5f, maxAngleRange * 0.5f);

            //Trouve le nouvel état du levier
            State newState = FindState(angle);
            SetState(newState);

            yield return null;
        }
    }

    State FindState(float handleAngle)
    {
        if (Mathf.Abs(handleAngle) > neutralZoneRange * maxAngleRange * 0.5f)
        {
            if (handleAngle > 0)
                return State.Up;
            else
                return State.Down;
        }

        return State.Neutral;
    }

    void SetState(State newState)
    {
        //Envoie un événement si l'état à changé
        if (newState != state)
        {
            switch (newState)
            {
                case State.Up:
                    onStateUp.Invoke();
                    break;
                case State.Down:
                    onStateDown.Invoke();
                    break;
                case State.Neutral:
                default:
                    onStateNeutral.Invoke();
                    break;
            }
        }

        //Prend note de l'état actuel
        state = newState;
    }
}
