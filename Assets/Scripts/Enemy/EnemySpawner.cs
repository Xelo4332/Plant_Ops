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

    //We will find our Game script component, create new List that will have transform type, make current or active wave zero and start the spawn courtine.
    private void Start()
    {
        _game = FindObjectOfType<Game>();
        _activeSpawnSpots = new List<Transform>();
        ActiveWave(0);
        StartCoroutine(SpawnRoutine());
    }

    //The zombies will spawn randomly. With help of random range, the script will range between 0 to the spawnSpots count depends how much spawnpoints are added.
    private Transform GetRandomSpawnSpot()
    {
        var index = Random.Range(0, _activeSpawnSpots.Count);
        return _activeSpawnSpots[index];
        
    }

    //This script works same as upper, but now we will spawn random enemy types
    private Enemy GetRandomEnemy()
    {
        var index = Random.Range(0, _enemies.Length);
        return _enemies[index];
    }

    //The spawncourtine that will bassicly spawn enemies in the scene. 
    //Enemy Count will increase with game round mutliple with 2.
    //We counting how much enemies are current alive.
    //While enemies are more than 0, they will spawn.
    //Everytime enemy spawn it will remove enemy count to know how much enemies left.
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
    //Here we will get randomspawnspot
    //Here we will get too random enemy type to spawn
    //Here is the core method to spawn the enemy
    //Every enemy has event ondie to know did enemy die or not so we will start to know when new round to be started.
    private void SpawnEnemy()
    {
        var spawnPoint = GetRandomSpawnSpot();
        var enemy = GetRandomEnemy();
        var enemyInstance = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        enemyInstance.Ondie += OnEnemyDie;
       
    }

    //Here we will check if all enemies are dead  to start round coldown and start new round.
    private void OnEnemyDie()
    {
        _aliveEnemiesCount--;
        if (_aliveEnemiesCount == 0)
        {

            StartCoroutine(CompleteRoundColdown());

        }
    }
    //Here is coldown for the spawner and comple round activator method.
    private IEnumerator CompleteRoundColdown()
    {

        yield return new WaitForSeconds(4);
        _game.CompleteRound();
        StartCoroutine(SpawnRoutine());
    }
    //We use this method for activation all spawnspots in current wave.
    private void ActiveSpawnPoints(int waveNumber)
    {
        foreach (Transform spawnSpots in _waves[waveNumber].spawnSpots)
        {
            spawnSpots.gameObject.SetActive(true);
        }

    }
    //Here we will activate our waves from our list.
    public void ActiveWave(int waveNumber)
    {
        ActiveSpawnPoints(waveNumber);
        _activeSpawnSpots.AddRange(_waves[waveNumber].spawnSpots);
    }
}

[System.Serializable]
public class Wave
{
    //We will use to divide spawnspots to needed wave number.
    public Transform[] spawnSpots;
}

