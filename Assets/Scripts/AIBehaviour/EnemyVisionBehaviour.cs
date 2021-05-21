using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionBehaviour : MonoBehaviour
{
    [Tooltip("The object that the enemy seeks")]
    [SerializeField]
    private GameObject _target;

    [Tooltip("Enemy's max vision distance")]
    [SerializeField]
    private float _maxVisionDistance;

    [Tooltip("Enemy's max angle")]
    [SerializeField]
    private float _maxVisionAngle;

    private float resetMovementSpeed;

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
        resetMovementSpeed = GetComponent<EnemyMovementBehvaiour>().MovementSpeed;
    }

    void Update()
    {
        if(Target)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 target = Target.transform.position - transform.position;
            if (Vector3.Dot(target, forward) >= 5)
            {
                GetComponent<EnemyMovementBehvaiour>().MovementSpeed = 0;
                //Debug.Log(target);
            }
            else
                GetComponent<EnemyMovementBehvaiour>().MovementSpeed = resetMovementSpeed;
        }
    }
}
