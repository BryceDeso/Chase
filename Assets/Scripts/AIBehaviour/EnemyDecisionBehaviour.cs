using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDecisionBehaviour : MonoBehaviour
{
    [Tooltip("Timer for the enemy")]
    [SerializeField]
    public float timer;

    //speed of the Enemy
    public float MovementSpeed;
    //speed of the enemy's rotation
    public float RotationSpeed;
    //bool to determine if the player is spotted or not
    public bool spotted = false;

    EnemyPatrolBehaviour patrol;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<EnemyPatrolBehaviour>().PatrolingState();
        if (spotted == true)
        {
            GetComponent<EnemyPursueBehaviour>().PursueTarget();
        }
    }
}
