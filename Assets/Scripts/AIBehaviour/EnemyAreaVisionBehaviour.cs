using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaVisionBehaviour : MonoBehaviour
{
    int current;
    [Tooltip("List of enemies within the vision Area")]
    [SerializeField]
    List<GameObject> list = new List<GameObject>();
    
    [Tooltip("Target that the enemies will look at and shoot")]
    [SerializeField]
    public GameObject Target;
    //Once the enemy enters the trigger it'll be added to the list
    private void OnTriggerEnter(Collider other)
    {
        //checks the objects tag to see if it's an enemy
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Wander"))
            return;
        //if it's an enemy it'll be added to the list of enemies in the area
        list.Add(other.gameObject);
    }
    //once an enemy leaves the area they will be removed from the list
    private void OnTriggerExit(Collider other)
    {
        //checks the tag to see if it's an enemy
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Wander"))
            return;
        //removes the enemy from the list
        list.Remove(other.gameObject);
    }

    private void Update()
    {
        
    }
}
