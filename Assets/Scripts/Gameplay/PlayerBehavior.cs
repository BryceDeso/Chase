using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _delegateBehavior = GetComponent<InputDelegateBehavior>();
    }

    private void Update()
    {
        SpreadShot();
        PiercingShot();
        PlayerRotate();
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

    /// <summary>
    /// When the spreadShot powerup is collected, activate the two extra bullet emitters and
    /// when the player has shot shot the max amount of times, it will disable the extra emitters until a 
    /// another power up is collected.
    /// </summary>
    private void SpreadShot()
    {
        if (TopEmitter.timesShot == spreadShotMax)
        {
            TopEmitter.timesShot = 0;
            BottomEmitter.timesShot = 0;

            canShootSpread = false;
        }
        else if (canShootSpread == true)
        {
            if (_delegateBehavior._playerControls.Player.Shoot.triggered)
            {
                TopEmitter.Shoot();
                BottomEmitter.Shoot();
            }
        }
    }

    /// <summary>
    /// When the piercingShot powerup is collected, will set a bool in the bullet behavior to true enabling the bullet to pass
    /// through any gameobject tagged with Enemy and when shot it will set the bool to false as well as setting that the player
    /// had collected the powerup to false.
    /// </summary>
    private void PiercingShot()
    {
        if (canShootPierce == true)
        {
            MiddleEmitter._bullet.canShootPierce = true;

            if (_delegateBehavior._playerControls.Player.Shoot.triggered)
            {
                canShootPierce = false;
                MiddleEmitter._bullet.canShootPierce = false;
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
        }
        else if (other.CompareTag("PiercingShot"))
        {
            canShootPierce = true;
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