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
    public float _timeInterval;

    private float _maxTime;
    //Used to tell how much time is left until the next spawn.
    public float _timeLeft;

    private void Start()
    {
        _maxTime = _timeInterval;
        Instantiate(_spawnRef, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Update()
    {
        Timer();
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

    private void Timer()
    {
        if(GameOverRef.gameOver != true)
        {
            _maxTime -= Time.deltaTime;
            _timeLeft = _maxTime;

            if (_timeLeft <= 0)
            {
                Instantiate(_spawnRef, transform.position, transform.rotation);

                _maxTime = _timeInterval;
            }
        }
    }
}