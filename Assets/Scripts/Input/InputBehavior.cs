using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehavior : MonoBehaviour
{
    [Tooltip("Refernce to the bullet")]
    [SerializeField]
    private BulletEmitterBehavior _bulletEmitter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _bulletEmitter.Shoot();
        }
    }
}
