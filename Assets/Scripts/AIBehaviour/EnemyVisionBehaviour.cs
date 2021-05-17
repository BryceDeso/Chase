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
        // Bit shift the index of the layer (8) to get a bit mask
        LayerMask layerMask = LayerMask.GetMask("Player");

        RaycastHit hit;
        // If the ray intersects an obect stop the enemy
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Hit");
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }
    
    }
}
