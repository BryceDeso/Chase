using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementBehaviour : MonoBehaviour
{
    //A reference to the rigidbody component
    private Rigidbody _rigidbody;

    //A variable used to store the value of the collectables
    private int score;

    //A reference to the UI Text
    public Text scoreCounter;

    //A varibale that handles the movement speed of the player
    public float moveSpeed;

    //A reference of a Vector3
    private Vector3 _velocity;

    /// <summary>
    /// A function that displays the number of collectables found
    /// </summary>
    void SetScoreCounter()
    {
        scoreCounter.text = "Total Score: " + score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        score = 0;
        SetScoreCounter();
    }

    public void Move(Vector3 direction)
    {
        _velocity = direction * moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _velocity);
    }

    /// <summary>
    /// A function that checks if the player has collided with the collectables and sets the collectables to false and collects them
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectables"))
        {
            other.gameObject.SetActive(false);
            score++;

            SetScoreCounter();
        }
    }
}
