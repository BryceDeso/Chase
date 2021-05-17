using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehaviour : MonoBehaviour
{
    //A refernce of the PlayerControls
    private PlayerControls _playerControls;

    //A reference of the PlayerMovementBehaviour script
    private PlayerMovementBehaviour _playerMovement;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    //Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = _playerControls.Player.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}
