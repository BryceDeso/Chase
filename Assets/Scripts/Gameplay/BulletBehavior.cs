using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed;
    [HideInInspector]
    public bool canShootPierce;

    public Rigidbody Rigidbody
    {
        get
        {
            return _rigidbody;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Checks the object that entered the bullets collision radius then checks the objects tags.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        //Checks if the player has collected the piercing shot powerup
        if(!canShootPierce)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Sets the speed of the bullet and just moves in a strait line
    /// </summary>
    void Update()
    {
        transform.position += new Vector3(_speed, 0, 0) * Time.deltaTime;
    }
}