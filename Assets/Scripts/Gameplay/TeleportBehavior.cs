using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{
    [Tooltip("reciever that takes in the object once it enters the teleporter")]
    [SerializeField]
    public Transform teleportReciever;

    [Tooltip("list of game objects that can't use the teleporter")]
    [SerializeField]
    public GameObject[] blacklist;

    private int current = 0;

    //once an actor enters the area it'll teleport them to the recieveing teleporter
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject == blacklist[current])
            return;

        other.transform.position = teleportReciever.transform.position;

    }
}
