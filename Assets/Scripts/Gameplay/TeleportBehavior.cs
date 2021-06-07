using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{
    [Tooltip("reciever that takes in the object once it enters the teleporter")]
    [SerializeField]
    public Transform teleportReciever;

    //once an actor enters the area it'll teleport them to the recieveing teleporter
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Wander"))
            return;

        other.transform.position = teleportReciever.transform.position;

    }
}
