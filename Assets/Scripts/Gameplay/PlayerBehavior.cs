﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private PlayerControls _playerControls;

    //Used to say if a power up has been collected and which one was collected
    public bool canShootSpread = false;
    public bool canShootPierce = false;

    //Used tell which way the player is facing.
    private bool turnedRight = false;
    private bool turnedLeft = false;

    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public int lifes = 0;

    private bool nearTeleporter;

    private InputDelegateBehavior _delegateBehavior;

    private TeleportBehavior _teleporter;

    [Tooltip("How fast the bullet wil move")]
    public float _bulletSpeed;

    [Tooltip("How many times the player can shoot with a the spreadshot power up")]
    [SerializeField]
    private float _spreadPowerTimer;

    [Tooltip("How many times the player can shoot with a the spreadshot power up")]
    [SerializeField]
    private float _piercePowerTimer;

    [Tooltip("The amount of time it takes to shoot again.")]
    [SerializeField]
    public float TimeBetweenShots = 0f;

    [Tooltip("Holds a refernce to the top bullet emitters")]
    public BulletEmitterBehavior TopEmitter;
    [Tooltip("Holds a refernce to the middle bullet emitters")]
    public BulletEmitterBehavior MiddleEmitter;
    [Tooltip("Holds a refernce to the bottom bullet emitters")]
    public BulletEmitterBehavior BottomEmitter;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _delegateBehavior = GetComponent<InputDelegateBehavior>();
    }

    private void Update()
    {
        PlayerRotate();
        SpreadShot();
        PiercingShot();
    }

    /// <summary>
    /// This gets if the player has pressed the A or D keys and will set the player 
    /// gameobject's rotation to 0 or 180 to simulate turning left or right.
    /// </summary>
    void PlayerRotate()
    {
        var keyboard = Keyboard.current;

        //If the A key was pressed this frame and the player is not turned left, set y rotation 
        //to 180 degrees and set turnedLeft to true.
        if (keyboard.aKey.wasPressedThisFrame && turnedLeft == false)
        {
            turnedLeft = true;

            _rigidbody.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);

            turnedRight = false;
        }
        //If the D key was pressed this frame and the player is not turned right, set y rotation 
        //to 0 degrees and set turnedRight to true.
        else if (keyboard.dKey.wasPressedThisFrame && turnedRight == false)
        {
            turnedRight = true;

            _rigidbody.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);

            turnedLeft = false;
        }
        //If the S key is pressed this frame and while nearTelporter is true, will set nearTeleporter
        //to false and set the player's position to the the teleporter's receiver.
        if (keyboard.wKey.wasPressedThisFrame && nearTeleporter == true)
        {
            nearTeleporter = false;

            gameObject.transform.position = new Vector3
                (
                _teleporter.teleportReciever.transform.position.x,
                _teleporter.teleportReciever.transform.position.y,
                _teleporter.teleportReciever.transform.position.z
                );
        }
    }

    //Function that controls whether or not the spreadshot powerup should still be active.
    private void SpreadShot()
    {
        //Spread Behavior
        if (canShootSpread)
        {
            if (_spreadPowerTimer >= 0)
            {
                _spreadPowerTimer -= Time.deltaTime;

                if (_delegateBehavior._playerControls.Player.Shoot.triggered)
                {
                    TopEmitter.Shoot();
                    BottomEmitter.Shoot();
                }
            }

            if (_spreadPowerTimer <= 0)
            {
                canShootSpread = false;
                _spreadPowerTimer = 0;
            }
        }
    }

    /// <summary>
    /// If canShootPierce is true, this will set a variable called shootPierce in the bullet behavior to true, 
    /// disabling the bullets destroying themselves on collision with an enemy, and begins a timer for how long 
    /// the player will be able to shoot piering bullets. Afer the timer is done it will set both varibles to 
    /// false and the timer to 0.
    /// </summary>
    private void PiercingShot()
    {
        if(canShootPierce)
        {
            MiddleEmitter._bullet.shootPierce = true;

            if (_piercePowerTimer >= 0)
            {
                _piercePowerTimer -= Time.deltaTime;
            }

            if (_piercePowerTimer <= 0)
            {
                canShootPierce = false;
                MiddleEmitter._bullet.shootPierce = false;
                _piercePowerTimer = 0;
            }
        }
    }

    /// <summary>
    /// //If the player is in the trigger of a game object tagged teleporter, it will set 
    /// nearTeleporter to true and get that teleporter's TeleportBehavior.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            nearTeleporter = true;

            _teleporter = other.GetComponent<TeleportBehavior>();
        }
        else if (other.CompareTag("SpreadShot"))
        {
            canShootSpread = true;
            _spreadPowerTimer = 15;
        }
        else if (other.CompareTag("PiercingShot"))
        {
            canShootPierce = true;
            _piercePowerTimer = 15;
        }
        else if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    //If the player exits the trigger of a game object tagged teleporter it will set nearTeleporter to false.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            nearTeleporter = false;
        }
    }
}