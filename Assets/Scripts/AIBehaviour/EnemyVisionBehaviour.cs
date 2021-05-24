using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionBehaviour : MonoBehaviour
{
    [Tooltip("The object that the enemy seeks")]
    [SerializeField]
    private GameObject _target;

    [Tooltip("Enemy's vision distance")]
    [SerializeField]
    private int _visionDistance;

    [Tooltip("Enemy's angle")]
    [SerializeField]
    private float _visionAngle;

    private float resetMovementSpeed;
    //getter and setter for the target
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
    private void Start()
    {
        //resets the movement speed of the enemy
        resetMovementSpeed = GetComponent<EnemyMovementBehvaiour>().MovementSpeed;
    }

    void Update()
    {
        //if the ai detects the target then it'll activate this sequince
        if(Target)
        {
            //the forward of the enemy
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            //the distance of the target
            Vector3 target = Target.transform.position - transform.position;
            //if the dot prod. is greater than the vision it'll trigger this sequence
            if (Vector3.Dot(target, forward) <= _visionDistance && Vector3.Dot(target, forward) >= 0)
            {
                //stops the enmey by setting it's speed to zero
                GetComponent<EnemyMovementBehvaiour>().MovementSpeed = 0;
                
            }
            else
                //resets the enemy's movement speed
                GetComponent<EnemyMovementBehvaiour>().MovementSpeed = resetMovementSpeed;

        }
    }
}
