using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _spawner.gameObject.SetActive(true);
        }

    }

}
