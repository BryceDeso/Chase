using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVisionBehaviour : MonoBehaviour
{
    [Tooltip("The object that the enemy seeks")]
    [SerializeField]
    private GameObject _target;

    [Tooltip("Enemy's max vision distance")]
    [SerializeField]
    private float _maxVisionDistance;

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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _maxVisionDistance, layerMask))
        {
<<<<<<< Updated upstream
            //changes the ray to yellow if it hits the player
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //stops the enemy
=======
            //draws the ray
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //pops up a message on the debug menu stating that the enemy detected something
            Debug.Log("Did Hit");
            //stops the nav mesh once the enemy spots the player
>>>>>>> Stashed changes
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
<<<<<<< Updated upstream
            //enemy's raycast remains white
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //enemy continues pursuing the player
=======
            //draws the ray
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //resets teh nav mesh agent if the player leaves the enemy's view
>>>>>>> Stashed changes
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }
    
    }
}
