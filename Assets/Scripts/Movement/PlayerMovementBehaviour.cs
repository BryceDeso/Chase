using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _player;

    private InputDelegateBehavior _inputDelegate;

    //Good jump value is 3
    [Tooltip("How high the player can jump")]
    [SerializeField]
    private float _jumpForce;

    //A vector3 that is will be scaled by its Y axis for jumping.
    private Vector3 _jump = new Vector3(0, 1, 0);

    //A reference to the rigidbody component
    private Rigidbody _rigidbody;

    //A varibale that handles the movement speed of the player
    public float moveSpeed;

    //A reference of a Vector3
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _inputDelegate = GetComponent<InputDelegateBehavior>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _velocity = direction * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _velocity);
    }

    //If the player is on the ground and has pressed the jump button, it will apply an upward force.
    public void Jump()
    {
        if (_player.onGround == true && _inputDelegate._playerControls.Player.Jump.triggered)
        {
            _rigidbody.AddForce(_jump * _jumpForce, ForceMode.Impulse);
        }
    }
}
