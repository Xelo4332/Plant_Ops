using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DoorBuying : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _scoreNeededToBuyDoor;
    [SerializeField] private int _scoreRemovalAfterBuy;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            if (_player._score >= _scoreNeededToBuyDoor)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    this.gameObject.SetActive(false);
                    _player.UpdateScore(-_scoreNeededToBuyDoor);

  
                    Debug.Log(_player);
                }
            }
        }
    }






}
