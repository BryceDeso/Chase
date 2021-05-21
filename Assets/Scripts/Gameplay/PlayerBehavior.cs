using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private PlayerControls _playerControl;

    private bool turnedRight = false;
    private bool turnedLeft = false;

    // Start is called before the first frame update
    void Start()
    {

        _playerControl = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.aKey.wasPressedThisFrame && turnedLeft == false)
        {
            turnedLeft = true;

            _rigidbody.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);

            turnedRight = false;
        }
        else if(keyboard.dKey.wasPressedThisFrame && turnedRight == false)
        { 
            turnedRight = true;

            _rigidbody.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);

            turnedLeft = false;
        }
    }
}
