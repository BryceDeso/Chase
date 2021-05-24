﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private PlayerControls _playerControls;

    //Used tell which way the player is facing.
    private bool turnedRight = false;
    private bool turnedLeft = false;

    private bool nearTeleporter;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private TeleportBehavior _teleporter;

    /// <summary>
    /// This gets if the player has pressed the A or D keys and will set the player 
    /// gameobject's rotation to 0 or 180 to simulate turning left or right.
    /// </summary>
    void Update()
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
        if (keyboard.sKey.wasPressedThisFrame && nearTeleporter == true)
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