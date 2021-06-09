using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    [Tooltip("Enemy's weapon")]
    [SerializeField]
    public GameObject weapon;

    public void Start()
    {

    }

    public void Attack()
    {
        weapon.GetComponent<EnemyBulletEmitterBehaviour>().Shoot();
    }
}
