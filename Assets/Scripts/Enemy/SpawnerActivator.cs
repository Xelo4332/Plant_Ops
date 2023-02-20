using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField] private int _waveNumber;
    private EnemySpawner _spawner;

    //Will find Spawner script.
    private void Start()
    {
        _spawner = FindObjectOfType<EnemySpawner>();
    }

    //If player collides with spawner activater object, that it will activate a new spawn points. Wave number are bassicly a variable to show which room are spawn points located.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _spawner.ActiveWave(_waveNumber);
        }

    }

}
