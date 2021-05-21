using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{   
    //recieveing end of the teleporter
    public Transform teleportReciever;
    //actor that gets teleported
    public GameObject actor;
    //delay timer for the teleporter
    public float timer;
    //Checks the gameobject's tag that entered the trigger and if tag matches, 
    //teleports the gameobject to the reciveing teleporter
    private void OnTriggerEnter(Collider other)
    {
        float timedown = timer;
        if (other.gameObject.CompareTag("Wander") || other.gameObject.CompareTag("Player"))
        {
            if (timedown == timer)
            {
                other.transform.position = teleportReciever.transform.position;
                timedown -= Time.deltaTime;
            }
            else if (timedown <= 0)
                timedown = timer;
        }
    }
}
