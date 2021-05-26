using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [Tooltip("Refernce to object that will collect powerups")]
    [SerializeField]
    private PlayerBehavior _powerUpCollected;

    [Tooltip("How fast the bullet wil move")]
    public float _bulletSpeed;

    [Tooltip("The amount of time it takes to shoot again.")]
    [SerializeField]
    public float TimeBetweenShots = 0f;

    [Tooltip("Holds a refernce to the top bullet emitters")]
    public BulletEmitterBehavior TopEmitter;
    [Tooltip("Holds a refernce to the middle bullet emitters")]
    public BulletEmitterBehavior MiddleEmitter;
    [Tooltip("Holds a refernce to the bottom bullet emitters")]
    public BulletEmitterBehavior BottomEmitter;

    /// <summary>
    /// When the spreadShot powerup is collected, activate the two extra bullet emitters
    /// </summary>
    private void SpreadShot()
    {
        if (_powerUpCollected.canShootSpread == true)
        {

        }
    }

    /// <summary>
    /// When the piercingShot powerup is collected, 
    /// </summary>
    private void PiercingShot()
    {
        if(_powerUpCollected.canShootPierce == true)
        {
            
        }
    }
}