using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationBehaviour : MonoBehaviour
{
    private EnemyMovementBehvaiour _movementBehvaiour;
    [SerializeField]
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _movementBehvaiour = GetComponent<EnemyMovementBehvaiour>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _movementBehvaiour.MovementSpeed);
    }
}
