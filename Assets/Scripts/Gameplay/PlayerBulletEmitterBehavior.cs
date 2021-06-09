using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletEmitterBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the bullet")]
    public BulletBehavior _bullet;

    [Tooltip("Reference to the gun the emitter is attatched to")]
    [SerializeField]
    private PlayerBehavior _player;

    [SerializeField]
    private float shootTimer;

    //Holds a bool to determind wether or not you can shoot again.
    [SerializeField]
    private bool canShoot = true;

    [SerializeField]
    private bool activeTimer = false;

    private void Update()
    {
        if(activeTimer)
        {
            Timer();
        }
    }

    /// <summary>
    /// Creates an instance of the bullet and applies a force thats multiplied by _bulletSpeed
    /// then sets the timer to active, disabling player shooting for the timer duration.
    /// </summary>
    public void Shoot()
    {
        if(canShoot == true)
        {
            shootTimer = _player.TimeBetweenShots;

            canShoot = false;

            Vector3 force = transform.forward * _player._bulletSpeed;

            GameObject bulletFired = Instantiate(_bullet.gameObject, transform.position, transform.rotation);

            BulletBehavior bulletscript = bulletFired.GetComponent<BulletBehavior>();

            if (bulletscript)
            {
                bulletscript.Rigidbody.AddForce(force, ForceMode.Impulse);
            }

            activeTimer = true;
        }
    }

    //Sets a timer for the amount set by TimeBetweenShots, disabling player shooting during that time.
    //Then when the timer is up, it will allow the player to shoot again.
    private void Timer()
    {
        if (shootTimer >= 0)
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                canShoot = true;
                activeTimer = false;
                shootTimer = 0;
            }
        }
    }
}