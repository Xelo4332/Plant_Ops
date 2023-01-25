using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField] private int _waveNumber;
    private EnemySpawner _spawner;

    private void Start()
    {
        _spawner = FindObjectOfType<EnemySpawner>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _spawner.ActiveWave(_waveNumber);
        }

    }

}
