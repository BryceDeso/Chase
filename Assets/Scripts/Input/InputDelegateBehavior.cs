using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDelegateBehavior : MonoBehaviour
{
    private PlayerControls _playerControls;
    [SerializeField]
    private BulletEmitterBehavior _bulletEmitter;

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
        _playerControls.Gun.Shoot.performed += context => _bulletEmitter.Shoot();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = _playerControls.Player.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}
