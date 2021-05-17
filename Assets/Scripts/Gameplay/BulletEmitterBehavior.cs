using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the bullet")]
    [SerializeField]
    private GameObject _bullet;
    [Tooltip("How fast the bullet wil move")]
    public float _bulletSpeed;

    /// <summary>
    /// Creates an instance of the bullet and applies a force thats multiplied by _bulletSpeed
    /// </summary>
    public void Shoot()
    {
        Vector3 force = transform.forward * _bulletSpeed;

        GameObject bulletFired = Instantiate(_bullet, transform.position, transform.rotation);

        BulletBehavior bulletscript = bulletFired.GetComponent<BulletBehavior>();
        if (bulletscript)
        {
            bulletscript.Rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }
}