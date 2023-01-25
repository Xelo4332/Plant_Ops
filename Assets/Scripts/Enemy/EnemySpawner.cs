using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnIntervals;
    private List<Transform> _activeSpawnSpots;
    private Game _game;
    private int _enemiesCount;
    private int _aliveEnemiesCount;


    private void Start()
    {
        _game = FindObjectOfType<Game>();
        _activeSpawnSpots = new List<Transform>();
        ActiveWave(0);
        StartCoroutine(SpawnRoutine());
    }

    private Transform GetRandomSpawnSpot()
    {
        var index = Random.Range(0, _activeSpawnSpots.Count);
        return _activeSpawnSpots[index];
        
    }

    private Enemy GetRandomEnemy()
    {
        var index = Random.Range(0, _enemies.Length);
        return _enemies[index];
    }

    private IEnumerator SpawnRoutine()
    {
        _enemiesCount = _game.Round * 2;
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

            StartCoroutine(CompleteRoundColdown());

        }
    }

    private IEnumerator CompleteRoundColdown()
    {

        yield return new WaitForSeconds(8);
        _game.CompleteRound();
        StartCoroutine(SpawnRoutine());
    }

    private void ActiveSpawnPoints(int waveNumber)
    {
        foreach (Transform spawnSpots in _waves[waveNumber].spawnSpots)
        {
            spawnSpots.gameObject.SetActive(true);
        }

    }

    public void ActiveWave(int waveNumber)
    {
        ActiveSpawnPoints(waveNumber);
        _activeSpawnSpots.AddRange(_waves[waveNumber].spawnSpots);
    }
}

[System.Serializable]
public class Wave
{
    public Transform[] spawnSpots;
}

