using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the bullet")]
    public BulletBehavior _bullet;

    [Tooltip("Reference to the gun the emitter is attatched to")]
    [SerializeField]
    private PlayerBehavior _player;

    private float shootTimer;

    //Holds whether or not the timer is currently active.
    private bool activeTimer = false;

    //Holds a bool to determind wether or not you can shoot again.
    private bool canShoot = true;

    private void Update()
    {
    }

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

            activeTimer = true;

            Vector3 force = transform.forward * _player._bulletSpeed;

            GameObject bulletFired = Instantiate(_bullet.gameObject, transform.position, transform.rotation);

            BulletBehavior bulletscript = bulletFired.GetComponent<BulletBehavior>();
            if (bulletscript)
            {
                bulletscript.Rigidbody.AddForce(force, ForceMode.Impulse);
            }

            Invoke("CanShoot", _player.TimeBetweenShots);
        }
    }

    private void CanShoot()
    {
        canShoot = true;
    }
}