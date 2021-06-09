using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletEmitterBehaviour : MonoBehaviour
{
    [Tooltip("Refernce to the bullet")]
    [SerializeField]
    private GameObject _bullet;
    [Tooltip("How fast the bullet wil move")]
    public float _bulletSpeed;
    [Tooltip("The amount of time it takes to shoot again.")]
    [SerializeField]
    private float TimeBetweenShots = 0f;
    //Holds a bool to determind wether or not you can shoot again.
    private bool canShoot = true;


    public void Shoot()
    {
        if (canShoot == true)
        {
            canShoot = false;

            Vector3 force = transform.forward * _bulletSpeed;

            GameObject bulletFired = Instantiate(_bullet, transform.position, transform.rotation);
            EnemyBulletBehaviour enemyBulletScript = bulletFired.GetComponent<EnemyBulletBehaviour>();
            if (enemyBulletScript)
            {
                enemyBulletScript.Rigidbody.AddForce(force, ForceMode.Impulse);
            }
            Invoke("CanShoot", TimeBetweenShots);
        }
    }

    private void CanShoot()
    {
        canShoot = true;
    }
}
