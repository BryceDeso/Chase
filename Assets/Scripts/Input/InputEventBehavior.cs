﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventBehavior : MonoBehaviour
{
    [SerializeField]
    private BulletEmitterBehavior _bulletEmitterBehavior;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        _bulletEmitterBehavior.Shoot();
    }
}
