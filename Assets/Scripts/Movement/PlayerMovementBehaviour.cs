using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementBehaviour : MonoBehaviour
{
    //A reference to the rigidbody component
    private Rigidbody _rigidbody;

    //A varibale that handles the movement speed of the player
    public float moveSpeed;

    //A reference of a Vector3
    private Vector3 _velocity;

    public int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
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
    /// A function that displays the number of collectables found
    /// </summary>
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        score += 5;
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
            Destroy(other);
            SetScoreText();
        }
    }
}
