using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDelegateBehavior : MonoBehaviour
{
    private PlayerControls _playerControls;
    [SerializeField]
    private BulletEmitterBehavior _bulletEmitter;

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
        _playerControls.Gun.Shoot.performed += context => _bulletEmitter.Shoot();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
