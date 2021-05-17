using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementBehvaiour : MonoBehaviour
{
    [Tooltip("rigidbody attached to the object")]
    [SerializeField]
    private Rigidbody _rigidbody;
    [Tooltip("the object the enemy will be seeking")]
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
    // Start is called before the first frame update
    void Start()
    {
        //intializes the rigidbody and nav mesh agent
        _rigidbody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //if the enemy doesn't have a target it will just return
        if (!_target)
            return;
        //the agents destination will be the targets transform
        _agent.SetDestination(_target.transform.position);
    }
}
