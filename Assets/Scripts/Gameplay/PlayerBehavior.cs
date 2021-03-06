using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;

    //Used to say if a power up has been collected and which one was collected
    public bool canShootSpread = false;
    public bool canShootPierce = false;

    //Used tell which way the player is facing.
    private bool turnedRight = false;
    private bool turnedLeft = false;

    [HideInInspector]
    public int score = 0;
    [SerializeField]
    public int lifes = 3;

    private bool nearTeleporter = false;

    private InputDelegateBehavior _delegateBehavior;

    private TeleportBehavior _teleporter;

    //Used to tell if the player is in the air or on the ground.
    public bool onGround;

    [Tooltip("How fast the bullet wil move")]
    public float _bulletSpeed;

    [Tooltip("How long the player can shoot with a the spreadshot power up")]
    [SerializeField]
    private float _spreadShotMaxTime;
    //Holds the number from _pierceShotMaxTime and subtracts it by deltatime for a timer.
    [SerializeField]
    private float _spreadShotTimer;
    //Holds the rounded value of the spread shot timer for UI display.
    private float _spreadSeconds;

    [Tooltip("How long the player can shoot with a the pierceingShot power up")]
    [SerializeField]
    private float _pierceShotMaxTime;
    //Holds the number from _pierceShotMaxTime and subtracts it by deltatime for a timer.
    [SerializeField]
    private float _pierceShotTimer;
    //Holds the rounded value of the _pierceShotTimer for UI usage.
    private float _pierceSeconds;

    [Tooltip("The amount of time it takes to shoot again.")]
    [SerializeField]
    public float TimeBetweenShots = 0f;

    [Tooltip("A refernce to an empty gameobject, will set the player's position to the gameobject when the player dies.")]
    [SerializeField]
    private GameObject _spawnPoint;

    [Tooltip("Holds a refernce to the top bullet emitters")]
    public PlayerBulletEmitterBehavior TopEmitter;
    [Tooltip("Holds a refernce to the middle bullet emitters")]
    public PlayerBulletEmitterBehavior MiddleEmitter;
    [Tooltip("Holds a refernce to the bottom bullet emitters")]
    public PlayerBulletEmitterBehavior BottomEmitter;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _delegateBehavior = GetComponent<InputDelegateBehavior>();
    }

    private void Update()
    {
        PlayerActions();
        PowerUps();
    }

    //Funtions that holds player behaviors.
    private void PlayerActions()
    {
        PlayerRotate();
        PlayerTeleport();
    }

    //Funtions that holds behaviors for powerups.
    private void PowerUps()
    {
        SpreadShot();
        PiercingShot();
    }

    private void EnemyReset()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Wander");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
            GameObject.Destroy(bullet);
    }
    /// <summary>
    /// This gets if the player has pressed the A or D keys and will set the player 
    /// gameobject's rotation to 0 or 180 to simulate turning left or right.
    /// </summary>
    void PlayerRotate()
    {
        var keyboard = Keyboard.current;
        var gamePad = Gamepad.current;

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

        if(gamePad != null)
        {
            //If the left stick was moved right this frame and the player is not turned left, set y rotation 
            //to 180 degrees and set turnedLeft to true.
            if (gamePad.leftStick.left.wasPressedThisFrame && turnedLeft == false)
            {
                turnedLeft = true;

                _rigidbody.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);

                turnedRight = false;
            }
            //If the left stick was moved left this frame and the player is not turned right, set y rotation 
            //to 0 degrees and set turnedRight to true.
            else if (gamePad.leftStick.right.wasPressedThisFrame && turnedRight == false)
            {
                turnedRight = true;

                _rigidbody.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);

                turnedLeft = false;
            }
        }
    }

    //If the S key is pressed this frame and while nearTelporter is true, will set nearTeleporter
    //to false and set the player's position to the the teleporter's receiver.
    private void PlayerTeleport()
    {
        var keyboard = Keyboard.current;
        var gamePad = Gamepad.current;

        if (keyboard.wKey.wasPressedThisFrame && nearTeleporter == true || gamePad.buttonWest.wasPressedThisFrame && nearTeleporter == true)
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

    /// <summary>
    /// If canShootSpread is true, a timer will activate for the amount of time set by _spreadShotMaxTimer
    /// as well as allow the player to shoot from the two hidden bullet emitters.
    /// When the timer reaches zero it will turn off spreadshot.
    /// </summary>
    private void SpreadShot()
    {
        if (canShootSpread)
        {
            if (_spreadShotTimer >= 0)
            {
                _spreadShotTimer -= Time.deltaTime;
                _spreadSeconds = _spreadShotTimer % 60;

                if (_delegateBehavior._playerControls.Player.Shoot.triggered)
                {
                    TopEmitter.Shoot();
                    BottomEmitter.Shoot();
                }
            }

            if (_spreadShotTimer <= 0)
            {
                canShootSpread = false;
                _spreadShotTimer = 0;
            }
        }
    }

    /// <summary>
    /// If canShootPierce is true, this will set a variable called shootPierce in the bullet behavior to true, 
    /// disabling the bullets destroying themselves on collision with an enemy, and begins a timer for how long 
    /// the player will be able to shoot piering bullets When the timer ends it will disable piercing shot.. 
    /// </summary>
    private void PiercingShot()
    {
        _pierceSeconds = _pierceShotTimer;

        if (canShootPierce)
        {
            MiddleEmitter._bullet.shootPierce = true;

            if (_pierceShotTimer >= 0)
            {
                _pierceShotTimer -= Time.deltaTime;
                _pierceSeconds = _pierceShotTimer % 60;
            }

            if (_pierceShotTimer <= 0)
            {
                canShootPierce = false;
                MiddleEmitter._bullet.shootPierce = false;
                _pierceShotTimer = 0;
            }
        }
    }

    //Sets the player's position to the spawnpoints position;
    private void Respawn()
    {
        gameObject.transform.position = _spawnPoint.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player is in the trigger of a game object tagged teleporter, it will set 
        // nearTeleporter to true and get that teleporter's TeleportBehavior.
        if (other.CompareTag("Patrol Point"))
        {
            nearTeleporter = true;

            _teleporter = other.GetComponent<TeleportBehavior>();
        }
        //If the player collides with a gamobject tagged spreadshot, it will enable the spreadshot powerup
        else if (other.CompareTag("SpreadShot"))
        {
            canShootSpread = true;
            _spreadShotTimer = _spreadShotMaxTime;
        }
        //If the player collides with a gamobject tagged piercingshot, it will enable the piercingshot powerup.
        else if (other.CompareTag("PiercingShot"))
        {
            canShootPierce = true;
            _pierceShotTimer = _pierceShotMaxTime;
        }
        //If the player collides with a gamobject tagged bullet, it will Set the 
        //player back to its spawnpoint and deduct a life. 
        else if (other.CompareTag("Bullet"))
        {
            Respawn();
            EnemyReset();
            lifes -= 1;
        }
        else if (other.CompareTag("Collectables"))
        {
            other.gameObject.SetActive(false);
            score += 20;
        }
        else if (other.CompareTag("WinPlane"))
        {
            score += 200;
            Respawn();
            EnemyReset();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = false;
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