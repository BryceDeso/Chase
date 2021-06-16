using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionBehaviour : MonoBehaviour
{
    //ref for the bullet emitter clas
    private GameObject _bulletEmitter;

    [Tooltip("The object that the enemy seeks")]
    [SerializeField]
    private Transform _target;

    [Tooltip("Enemy's vision distance")]
    [SerializeField]
    private int _maxDistance;

    [Tooltip("Enemy's angle")]
    [SerializeField]
    private float _maxAngle;

    private float resetMovementSpeed;
    //getter and setter for the target
    public Transform Target
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
        _bulletEmitter = GameObject.FindWithTag("Gun");
    }
    
    void Update()
    {
        //if the ai detects the target then it'll activate this sequince
        if(_target)
        {
            
            //the forward of the enemy
            Vector3 forward = transform.forward;
            //the distance of the target
            Vector3 target = (Target.transform.position - transform.position);
            //distance of the target from the enemy
            float distance = target.magnitude;
            //angle of the enemy's vision
            float DotPro = Vector3.Dot(forward, target.normalized);
            float angle = Mathf.Acos(DotPro);
            
            if(float.IsNaN(angle))
            {
                angle = 0.25f;
            }
            //if the dot prod. is greater than the vision it'll trigger this sequence
            if (angle <= _maxAngle && distance <= _maxDistance)
            {
                //stops the enmey by setting it's speed to zero
                GetComponent<EnemyMovementBehvaiour>().MovementSpeed = 0;
                GetComponent<EnemyAttackBehaviour>().Attack();
                transform.LookAt(Target.transform);
            }
            else
                //resets the enemy's movement speed
                GetComponent<EnemyMovementBehvaiour>().MovementSpeed = resetMovementSpeed;

        }
    }
}
