using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlaneBehavior : MonoBehaviour
{
    public bool CompletedLevel = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CompletedLevel = true;
        }
    }
}
