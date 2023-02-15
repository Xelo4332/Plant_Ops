using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStim : MonoBehaviour
{
    private Player _playerHealth;
    private bool HasHealthStim = false;
    private void Start()
    {
        _playerHealth = FindObjectOfType<Player>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.E) && HasHealthStim == false)
        {
            _playerHealth._health += 100;
            _playerHealth.RegenerationAmount += 10;
            HasHealthStim = true;
        }
    }
}
