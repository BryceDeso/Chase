using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [Tooltip("Object ref to be spawned in")]
    [SerializeField]
    private GameObject _spawnObject;

    [Tooltip("Set the enemy's target")]
    [SerializeField]
    private Transform _target;

    [Tooltip("Set's the patrol points for the enemy")]
    [SerializeField]
    private Transform[] _points;

    [Tooltip("Attach the game manager in order to determine if the game is over or not")]
    [SerializeField]
    private GameManagerBehavior _gameMan;

    [Tooltip("Timer to determin when enemies can spawn or not")]
    [SerializeField]
    private float _timer;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    public IEnumerator SpawnObject()
    {
        while (_gameMan.gameOver != true)
        {
            //makes a new enemy in the scene
            GameObject spawnedEnemy = Instantiate(_spawnObject, transform.position, new Quaternion());
            //initalizes the target and patrol points for the enemy
            spawnedEnemy.GetComponent<EnemyVisionBehaviour>().Target = _target;
            spawnedEnemy.GetComponent<EnemyMovementBehvaiour>().Points = _points;
            //wait till timer is done till it cycles the process again
            yield return new WaitForSeconds(_timer);
        }
    }
}
