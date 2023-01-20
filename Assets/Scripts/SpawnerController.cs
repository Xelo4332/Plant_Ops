using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
  
    [SerializeField] private GameObject[] _enemySpawner;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.name == "Player")
        {
            _enemySpawner[0].gameObject.SetActive(true);
        }
    }


}
