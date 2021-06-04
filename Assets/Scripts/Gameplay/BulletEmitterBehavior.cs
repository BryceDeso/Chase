using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the bullet")]
    public BulletBehavior _bullet;

    [Tooltip("Reference to the gun the emitter is attatched to")]
    [SerializeField]
    private GunBehavior _gun;

    //Holds the amount of times the player has shot(This is used for power ups and is reset when max
    //amount of shots has been reached for a power up)
    public float timesShot;

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

<<<<<<< HEAD
            GameObject bulletFired = Instantiate(_bullet.gameObject, transform.position, transform.rotation);

=======
            GameObject bulletFired = Instantiate(_bullet, transform.position, transform.rotation);
>>>>>>> NoahEasleys-branch
            BulletBehavior bulletscript = bulletFired.GetComponent<BulletBehavior>();
            EnemyBulletBehaviour enemyBulletScript = bulletFired.GetComponent<EnemyBulletBehaviour>();
            if (bulletscript)
            {
                bulletscript.Rigidbody.AddForce(force, ForceMode.Impulse);
            }
<<<<<<< HEAD

            timesShot++;

            Invoke("CanShoot", _gun.TimeBetweenShots);
=======
            if(enemyBulletScript)
            {
                enemyBulletScript.Rigidbody.AddForce(force, ForceMode.Impulse);
            }
            Invoke("CanShoot", TimeBetweenShots);
>>>>>>> NoahEasleys-branch
        }
    }

    private void CanShoot()
    {
        canShoot = true;
    }
}