using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{   
    //recieveing end of the teleporter
    public Transform teleportReciever;
    //delay timer for the teleporter
    public float timer;
    //once an actor enters the area it'll teleport them to the recieveing teleporter
    private void OnTriggerEnter(Collider other)
    {
        float timedown = timer;
        if (!other.gameObject.CompareTag("Wander"))
            return;
        if (timedown == timer)
        {
            other.transform.position = teleportReciever.transform.position;
            timedown -= Time.deltaTime;
        }
        else if (timedown <= 0)
            timedown = timer;
    }
}
