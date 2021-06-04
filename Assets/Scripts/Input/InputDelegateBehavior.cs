using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehavior : MonoBehaviour
{
    public PlayerControls _playerControls;
    [SerializeField]
    private GunBehavior _gun;

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
<<<<<<< HEAD
        _playerControls.Player.Shoot.performed += context => _gun.MiddleEmitter.Shoot();
=======
        _playerControls.Player.Shoot.performed += context => _bulletEmitter.Shoot();
>>>>>>> NoahEasleys-branch
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = _playerControls.Player.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}