using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehvaiour : MonoBehaviour
{
    [Tooltip("Patrol points for the enemy")]
    [SerializeField]
    public Transform[] Points;
    //indecator for the current point that the enemy is on
    int current;
    //speed of the Enemy
    public float MovementSpeed;
    //speed of the enemy's rotation
    public float RotationSpeed;
    //direction that the enemy looks at
    private Vector3 _direction;
    private Quaternion _lookRotation;


    // Start is called before the first frame update
    void Start()
    {
        //initalizes the point the enemy starts at
        current = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Patrol Point"))
            return;
        current = (current + 1) % Points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //if the position of the enemy does not equal the position of it's current point continue moving to the current point's transform
        if(transform.position != Points[current].position)
        {

            //sets the enemy's transform to move towards the transform of the current point
            transform.position = Vector3.MoveTowards(transform.position, Points[current].position, MovementSpeed * Time.deltaTime);
            
            //looks at the point it's moving towards
            _direction = (Points[current].position - transform.position).normalized;
            _lookRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        }
    }
}
