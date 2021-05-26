using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the bullet")]
    [SerializeField]
    private GameObject _bullet;

    [Tooltip("Reference to the gun the emitter is attatched to")]
    [SerializeField]
    private GunBehavior _gun;

    //Holds a bool to determind wether or not you can shoot again.
    private bool canShoot = true;

    /// <summary>
    /// Creates an instance of the bullet and applies a force thats multiplied by _bulletSpeed, once the player has shot, 
    /// canShoot is set to false and a timer is set using Invoke and after a certain amount of time the 
    /// funtion canShoot is invoked and sets canShoot to true enabling the player to shoot again.
    /// </summary>
    public void Shoot()
    {
        if(canShoot == true)
        {
            canShoot = false;

            Vector3 force = transform.forward * _gun._bulletSpeed;

            GameObject bulletFired = Instantiate(_bullet, transform.position, transform.rotation);

            BulletBehavior bulletscript = bulletFired.GetComponent<BulletBehavior>();
            if (bulletscript)
            {
                bulletscript.Rigidbody.AddForce(force, ForceMode.Impulse);
            }

            Invoke("CanShoot", _gun.TimeBetweenShots);
        }
    }

    private void CanShoot()
    {
        canShoot = true;
    }
}