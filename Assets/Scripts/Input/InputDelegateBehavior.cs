using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehavior : MonoBehaviour
{
    public PlayerControls _playerControls;
    [SerializeField]
    private PlayerBehavior _player;

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

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
        _playerControls.Player.Shoot.performed += context => _player.MiddleEmitter.Shoot();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = _playerControls.Player.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}