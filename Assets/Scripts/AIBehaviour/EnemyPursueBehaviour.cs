using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursueBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

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

    public void PursueTarget()
    {
        transform.position += new Vector3(GetComponent<EnemyMovementBehvaiour>().MovementSpeed, 0, 0) * Time.deltaTime; 
    }
}
