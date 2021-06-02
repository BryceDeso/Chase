using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [Tooltip("Refernce to object that will collect powerups")]
    [SerializeField]
    private PlayerBehavior _player;

    private InputDelegateBehavior _delegateBehavior;

    [Tooltip("How fast the bullet wil move")]
    public float _bulletSpeed;

    [Tooltip("How many times the player can shoot with a the spreadshot power up")]
    [SerializeField]
    private float spreadShotMax;

    [Tooltip("The amount of time it takes to shoot again.")]
    [SerializeField]
    public float TimeBetweenShots = 0f;

    [Tooltip("Holds a refernce to the top bullet emitters")]
    public BulletEmitterBehavior TopEmitter;
    [Tooltip("Holds a refernce to the middle bullet emitters")]
    public BulletEmitterBehavior MiddleEmitter;
    [Tooltip("Holds a refernce to the bottom bullet emitters")]
    public BulletEmitterBehavior BottomEmitter;

    private void Start()
    {
        _delegateBehavior = _player.GetComponent<InputDelegateBehavior>();
    }

    private void Update()
    {
        SpreadShot();
        PiercingShot();
    }

    /// <summary>
    /// When the spreadShot powerup is collected, activate the two extra bullet emitters and
    /// when the player has shot shot the max amount of times, it will disable the extra emitters until a 
    /// another power up is collected.
    /// </summary>
    private void SpreadShot()
    {
        if (_player.canShootSpread == true)
        {
            if(_delegateBehavior._playerControls.Player.Shoot.triggered)
            {
                TopEmitter.Shoot();
                BottomEmitter.Shoot();
            }
        }
        if(TopEmitter.timesShot == spreadShotMax)
        {
            TopEmitter.timesShot = 0;
            BottomEmitter.timesShot = 0;

            _player.canShootSpread = false;
        }
    }

    /// <summary>
    /// When the piercingShot powerup is collected, 
    /// </summary>
    private void PiercingShot()
    {
        if(_player.canShootPierce == true)
        {
            
        }
    }
}