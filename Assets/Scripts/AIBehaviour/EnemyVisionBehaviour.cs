using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVisionBehaviour : MonoBehaviour
{
    [Tooltip("The object that the enemy seeks")]
    [SerializeField]
    private GameObject _target;

    private NavMeshAgent _agent;

    public GameObject Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }
    void FixedUpdate()
    {
        // Bit shift the index of the player layer
        LayerMask layerMask = LayerMask.GetMask("Player");
        //the raycast hit
        RaycastHit hit;
        // If the ray intersects an obect stop the enemy
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            //changes the ray to yellow if it hits the player
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //stops the enemy
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
            //enemy's raycast remains white
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //enemy continues pursuing the player
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }
    
    }
}
