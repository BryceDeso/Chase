﻿using System.Collections;
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

    private UnityEngine.AI.NavMeshAgent _agent;

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
            //changes the ray to yellow if it hits the player
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            //enemy's raycast remains white
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    
    }
}
