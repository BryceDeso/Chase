using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    //recieveing end of the teleporter
    public Transform teleportReciever;
    //actor that gets teleported
    public GameObject actor;
    //once an actor enters the area it'll teleport them to the recieveing teleporter
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Wander"))
            return;

        other.transform.position = teleportReciever.transform.position;
    }
}
