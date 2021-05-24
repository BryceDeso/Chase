using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventBehaviour : MonoBehaviour
{
    //A refernce to the PlayerMovementBehaviour script
    private PlayerMovementBehaviour _movement;

    //Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<PlayerMovementBehaviour>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement.Move(context.ReadValue<Vector2>());
    }
}
