using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnSpots;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnIntervals;
    private Game _game;
    private int _enemiesCount;
    private int _aliveEnemiesCount;

    private void Start()
    {
        _game = FindObjectOfType<Game>();
        StartCoroutine(SpawnRoutine());
    }

    private Transform GetRandomSpawnSpot()
    {
        var index = Random.Range(0, _spawnSpots.Length);
        return _spawnSpots[index];

    }

    private Enemy GetRandomEnemy()
    {
        var index = Random.Range(0, _enemies.Length);
        return _enemies[index];
    }

    private IEnumerator SpawnRoutine()
    {
        _enemiesCount = _game.Round * 10;
        _aliveEnemiesCount = _enemiesCount;
        while (_enemiesCount > 0)
        {
            SpawnEnemy();
            _enemiesCount--;
            yield return new WaitForSeconds(_spawnIntervals);
        }
        yield return new WaitForSeconds(10);
       
    }

    private void SpawnEnemy()
    {
        var spawnPoint = GetRandomSpawnSpot();
        var enemy = GetRandomEnemy();
        var enemyInstance = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        enemyInstance.Ondie += OnEnemyDie;
    }

    private void OnEnemyDie()
    {
        _aliveEnemiesCount--;
        if (_aliveEnemiesCount == 0)
        {
            _game.CompleteRound();
            StartCoroutine(SpawnRoutine());
        }
    }

}
