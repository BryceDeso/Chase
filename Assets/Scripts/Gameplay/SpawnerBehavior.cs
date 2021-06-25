using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [Tooltip("Refernce to script that contains game over behaviors")]
    [SerializeField]
    private GameManagerBehavior GameOverRef;
    [Tooltip("Reference to the object that you want to spawn")]
    [SerializeField]
    private GameObject _spawnRef;
    [Tooltip("The amount of time inbetween spawns")]
    [SerializeField]
    private float _timeInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCorutine());
    }

    /// <summary>
    /// Spawns gameobject then waits fot time specified in TimeInterval
    /// </summary>
    public IEnumerator SpawnCorutine()
    {
        while (GameOverRef.gameOver != true)
        {
            Instantiate(_spawnRef, transform.position, transform.rotation);

            yield return new WaitForSeconds(_timeInterval);
        }
    }
}