using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private PlayerControls _playerControls;

    //Used tell which way the player is facing.
    private bool turnedRight = false;
    private bool turnedLeft = false;

    //A reference to the rigidbody component
    private Rigidbody _rigidbody;

    //A varibale that handles the movement speed of the player
    public float moveSpeed;

    //A reference of a Vector3
    private Vector3 _velocity;

    public Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _velocity = direction * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _velocity);
    }
}