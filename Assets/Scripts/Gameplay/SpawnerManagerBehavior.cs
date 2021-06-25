using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawner;

    [HideInInspector]
    public bool resetSpawnTimers = false;

    // Update is called once per frame
    void Update()
    {
        if(resetSpawnTimers == true)
        {
            SetTimerToZero();
        }
    }

    private void SetTimerToZero()
    {
        for(int i = 0; i < _spawner.transform.childCount; i++)
        {
            _spawner.transform.GetChild(i).GetComponent<SpawnerBehavior>()._timeLeft = 0.5f;
        }

        resetSpawnTimers = false;
    }
}
