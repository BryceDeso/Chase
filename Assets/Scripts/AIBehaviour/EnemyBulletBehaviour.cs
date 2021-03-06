using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBulletBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed;

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
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
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
