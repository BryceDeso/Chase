using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    private PlayerMovementBehaviour _movementBehvaiour;
    [SerializeField]
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _movementBehvaiour = GetComponent<PlayerMovementBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _movementBehvaiour.Velocity.magnitude);
    }
}
