using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventBehaviour : MonoBehaviour
{
    //A refernce to the PlayerMovementBehaviour script
    [SerializeField]
    private PlayerMovementBehaviour _movement;

    //A reference to the BulletEmitterBehaviour
    [SerializeField]
    private BulletEmitterBehavior _bulletEmitterBehavior;

    //Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<PlayerMovementBehaviour>();

        _bulletEmitterBehavior = GetComponent<BulletEmitterBehavior>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement.Move(context.ReadValue<Vector2>());
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        _bulletEmitterBehavior.Shoot();
    }
}
